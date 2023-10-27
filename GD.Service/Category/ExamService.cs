using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IExamService
    {
        Result Add(Exam exam);

        Result AddExamLevel(ExamLevel examLevel);

        Result Update(Exam exam);

        Result UpdateExamLevel(ExamLevel examLevel);

        Result Delete(int id);

        Result DeleteExamLevel(int id);

        IEnumerable<Exam> GetAll();

        IEnumerable<Exam> GetAllByActive(bool active);

        IEnumerable<Exam> GetAllByActiveAndTopic(bool active, int topic);

        IEnumerable<Exam> GetUserByActiveAndTopic(bool active, int topic, string user, bool by);

        IEnumerable<ExamLevel> GetAllExamLevelByExam(bool active, int exam);

        ExamLevel GetExamLevelByExam(bool active, int exam, int level);

        Result GetCode(int topic);

        Exam GetById(int id);

        ExamLevel GetExamLevelById(int id);

        Exam GetByName(string name);

        Result Save();

        bool ClearExamLevelToExam(int exam);
    }

    public class ExamService : IExamService
    {
        IExamRepository _examRepository;
        IExamLevelRepository _examLevelRepository;
        IUnitOfWork _unitOfWork;

        public ExamService(IExamRepository examRepository, IExamLevelRepository examLevelRepository, IUnitOfWork unitOfWork)
        {
            this._examRepository = examRepository;
            this._examLevelRepository = examLevelRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Exam exam)
        {
            try
            {
                exam.Active = true;
                exam.CreateDate = DateTime.Now;
                _examRepository.Add(exam);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = exam.ID, Notication = "Thêm thành công" };

            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public Result AddExamLevel(ExamLevel examLevel)
        {
            try
            {
                examLevel.Active = true;
                examLevel.CreateDate = DateTime.Now;
                _examLevelRepository.Add(examLevel);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = examLevel.ID, Notication = "Thêm thành công" };

            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public Result GetCode(int topic)
        {
            try
            {
                var count = _examRepository.Count(x => x.Active == true || x.Active == false);
                string Code = "";
                bool checkNull = false;
                int number = count;
                while (checkNull == false)
                {
                    number++;
                    Code = string.Format("{0}{1}{2}", "GD", DateTime.Now.Day.ToString("00"), number.ToString("000000"));
                    var checkData = _examRepository.GetSingleByCondition(x => x.Code == Code);
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
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public Result Delete(int id)
        {
            try
            {
                _examRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public Result DeleteExamLevel(int id)
        {
            try
            {
                _examLevelRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<Exam> GetAll()
        {
            return _examRepository.GetAll();
        }


        public IEnumerable<Exam> GetAllByActive(bool active)
        {
            return _examRepository.GetMulti(x => x.Active == active);
        }

        public IEnumerable<Exam> GetAllByActiveAndTopic(bool active, int topic)
        {
            string[] includeData = new string[] { "Topic" };
            return _examRepository.GetMulti(x => x.Active == active && x.TopicId == topic, includeData);
        }

        public IEnumerable<Exam> GetUserByActiveAndTopic(bool active, int topic, string user, bool by)
        {
            string[] includeData = new string[] { "Topic" };
            if (by)
            {
                return _examRepository.GetMulti(x => x.Active == active && x.TopicId == topic && x.CreateBy == user, includeData);
            }
            else
            {
                return _examRepository.GetMulti(x => x.Active == active && x.TopicId == topic && x.CreateBy != user, includeData);
            }

        }

        public IEnumerable<ExamLevel> GetAllExamLevelByExam(bool active, int exam)
        {
            string[] includeData = new string[] { "Exam", "LevelQuestion" };
            return _examLevelRepository.GetMulti(x => x.Active == active && x.ExamId == exam, includeData);
        }

        public Exam GetById(int id)
        {
            return _examRepository.GetSingleById(id);
        }

        public ExamLevel GetExamLevelById(int id)
        {
            return _examLevelRepository.GetSingleById(id);
        }


        public Exam GetByName(string name)
        {
            return _examRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public Result Save()
        {
            try
            {
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Lưu thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public Result Update(Exam exam)
        {
            try
            {
                exam.UpdateDate = DateTime.Now;
                _examRepository.Update(exam);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = exam.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public Result UpdateExamLevel(ExamLevel examLevel)
        {
            try
            {
                examLevel.UpdateDate = DateTime.Now;
                _examLevelRepository.Update(examLevel);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = examLevel.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public bool ClearExamLevelToExam(int exam)
        {
            try
            {
                _examLevelRepository.DeleteMulti(x => x.ExamId == exam);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ExamLevel GetExamLevelByExam(bool active, int exam, int level)
        {
            return _examLevelRepository.GetSingleByCondition(x => x.Active == active && x.ExamId == exam && x.LevelId == level);
        }
    }
}
