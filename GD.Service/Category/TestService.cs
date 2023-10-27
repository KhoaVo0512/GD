using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ITestService
    {
        Result Add(Test test);

        Result Update(Test test);

        Result Delete(int id);

        IEnumerable<Test> GetAll();

        IEnumerable<Test> GetAllByActive(bool active);

        Test GetById(int id);

        Test GetByName(string name);

        Result GetCode(int exam, string codeExam);

        Result Save();

        IEnumerable<Test> GetTestByExam(int exam);

        IEnumerable<ExamTest> GetAllByExam(int exam);

        bool AddTestToExam(IEnumerable<ExamTest> examTests, int exam);

        bool ClearTestToExam(int examId);

        bool ClearAllTestByExam(int examId);

        bool AddQuestionToTest(IEnumerable<TestQuestion> testQuestions, int test);

        bool ClearQuestionToTest(int test);

        bool ClearAllByTest(int exam, int test);
    }

    public class TestService : ITestService
    {
        ITestRepository _testRepository;
        IExamTestRepository _examTestRepository;
        ITestQuestionRepository _testQuestionRepository;
        IUnitOfWork _unitOfWork;

        public TestService(ITestRepository testRepository, IExamTestRepository examTestRepository, ITestQuestionRepository testQuestionRepository, IUnitOfWork unitOfWork)
        {
            this._testRepository = testRepository;
            this._examTestRepository = examTestRepository;
            this._testQuestionRepository = testQuestionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Test test)
        {
            try
            {
                test.Active = true;
                test.CreateDate = DateTime.Now;
                _testRepository.Add(test);
                _unitOfWork.Commit();
                
                return new Result() { Status = true, ID = test.ID, Notication = "Thêm thành công" };

            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
            
        }

        public Result Delete(int id)
        {
            try
            {
                _testRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public Result GetCode(int exam, string codeExam)
        {
            try
            {
                var count = _examTestRepository.Count(x => x.ExamId == exam);
                string Code = "";
                bool checkNull = false;
                int number = count;
                while (checkNull == false)
                {
                    number++;
                    Code = string.Format("{0}{1}", codeExam + "-", number.ToString("000"));
                    var checkData = _testRepository.GetSingleByCondition(x => x.Name == Code);
                    if (checkData == null)
                    {

                        checkNull = true;
                        break;
                    }
                }

                if (checkNull)
                {
                    return new Result() { Status = true, IDString = Code, Notication = "Tạo thành công" };
                }
                else
                {
                    return new Result() { Status = false, ID = 0, Notication = "Mã đề bị trùng" };
                }
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<Test> GetAll()
        {
            return _testRepository.GetAll();
        }

       
        public IEnumerable<Test> GetAllByActive(bool active)
        {
            return _testRepository.GetMulti(x => x.Active == active);
        }

        public Test GetById(int id)
        {
            return _testRepository.GetSingleById(id);
        }

        public Test GetByName(string name)
        {
            return _testRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public Result Save()
        {
            try
            {
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Lưu thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
            
        }

        public Result Update(Test test)
        {
            try
            {
                test.UpdateDate = DateTime.Now;
                _testRepository.Update(test);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = test.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public bool AddTestToExam(IEnumerable<ExamTest> examTests, int exam)
        {
            try
            {
                _examTestRepository.DeleteMulti(x => x.ExamId == exam);
                foreach (var examTest in examTests)
                {
                    examTest.Active = true;
                    examTest.ActiveDate = DateTime.Now;
                    examTest.CreateDate = DateTime.Now;
                    _examTestRepository.Add(examTest);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClearTestToExam(int examId)
        {
            try
            {
                _examTestRepository.DeleteMulti(x => x.ExamId == examId);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Test> GetTestByExam(int exam)
        {
            return _testRepository.GetTestByExam(exam);
        }

        public IEnumerable<ExamTest> GetAllByExam(int exam)
        {
            string[] includeData = new string[] { "Exam", "Test" };
            return _examTestRepository.GetMulti(x => x.ExamId == exam, includeData);
        }

        public bool ClearAllTestByExam(int examId)
        {
            try
            {
                var examTests = _examTestRepository.GetMulti(x => x.ExamId == examId);

                foreach (var examTest in examTests)
                {
                    
                    _testQuestionRepository.DeleteMulti(x => x.TestId == examTest.TestId);
                   
                    _testRepository.Delete(examTest.TestId);
                }

                _examTestRepository.DeleteMulti(x => x.ExamId == examId);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool ClearAllByTest(int exam, int test)
        {
            try
            {
                _testQuestionRepository.DeleteMulti(x => x.TestId == test);

                _testRepository.Delete(test);

                var examTestModel = _examTestRepository.GetSingleByCondition(x => x.ExamId == exam && x.TestId == test);

                if(examTestModel != null)
                {
                    _examTestRepository.Delete(examTestModel.ID);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddQuestionToTest(IEnumerable<TestQuestion> testQuestions, int test)
        {
            try
            {
                _testQuestionRepository.DeleteMulti(x => x.TestId == test);
                foreach (var testQuestion in testQuestions)
                {
                    testQuestion.Active = true;
                    testQuestion.ActiveDate = DateTime.Now;
                    testQuestion.CreateDate = DateTime.Now;
                    _testQuestionRepository.Add(testQuestion);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClearQuestionToTest(int test)
        {
            try
            {
                _testQuestionRepository.DeleteMulti(x => x.TestId == test);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
