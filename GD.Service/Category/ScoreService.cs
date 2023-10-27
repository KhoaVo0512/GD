using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GD.Service
{
    public interface IScoreService
    {
        Result Add(Score score);

        Result Update(Score score);

        Result Delete(int id);

        IEnumerable<Score> GetAll();

        IEnumerable<Score> GetAllByActive(bool active);

        Result UpdateInformationStudent(int id, string code, string fullName, DateTime birthDay, string user);

        IEnumerable<Student> GetExistByListStudent(List<int> student, int scholastic, int grade, int course, int type);

        IEnumerable<Score> GetAllByScholasticAndGradeCourseType(int scholastic, int grade, int course, int type);

        bool DeleteAllByScholasticAndGradeStudent(int scholastic, int grade, int student);

        bool DeleteAllByScholasticAndCourse(int scholastic, int course);

        Score GetByScholasticAndGradeCourseStudentType(int scholastic, int grade, int course, int student, int type);

        Score GetById(int id);

        Result Save();
    }

    public class ScoreService : IScoreService
    {
        IScoreRepository _scoreRepository;
        IUnitOfWork _unitOfWork;

        public ScoreService(IScoreRepository scoreRepository, IUnitOfWork unitOfWork)
        {
            this._scoreRepository = scoreRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Score score)
        {
            try
            {
                score.Active = true;
                score.CreateDate = DateTime.Now;
                _scoreRepository.Add(score);
                _unitOfWork.Commit();
                
                return new Result() { Status = true, ID = score.ID, Notication = "Thêm thành công" };

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
                _scoreRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Score> GetAll()
        {
            return _scoreRepository.GetAll();
        }

       
        public IEnumerable<Score> GetAllByActive(bool active)
        {
            return _scoreRepository.GetMulti(x => x.Active == active);
        }

        public IEnumerable<Student> GetExistByListStudent(List<int> student, int scholastic, int grade, int course, int type)
        {
            return _scoreRepository.GetExistByListStudent(student, scholastic, grade, course, type);
        }

        public IEnumerable<Score> GetAllByScholasticAndGradeCourseType(int scholastic, int grade, int course, int type)
        {
            string[] includeData = new string[] { "Scholastic", "Course", "Grade", "Student" };
            return _scoreRepository.GetMulti(x => x.Active == true && x.ScholasticId == scholastic && x.GradeId == grade && x.CourseId == course && x.Type == type, includeData);
        }

        public bool DeleteAllByScholasticAndGradeStudent(int scholastic, int grade, int student)
        {
            try
            {
                _scoreRepository.DeleteMulti(x => x.ScholasticId == scholastic && x.GradeId == grade && x.StudentId == student);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            

        }

        public bool DeleteAllByScholasticAndCourse(int scholastic, int course)
        {
            try
            {
                _scoreRepository.DeleteMulti(x => x.ScholasticId == scholastic && x.CourseId == course);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Score GetById(int id)
        {
            return _scoreRepository.GetSingleById(id);
        }

        public Result UpdateInformationStudent(int id, string code, string fullName, DateTime birthDay, string user)
        {
            try
            {
                var scoreByStudent = _scoreRepository.GetMulti(x => x.StudentId == id).ToList();
                if (scoreByStudent.Count() > 0)
                {
                    foreach (var item in scoreByStudent)
                    {
                        item.Code = code;
                        item.FullName = fullName.ToUpper();
                        item.BirthDay = birthDay;

                        item.UpdateBy = user;
                        item.UpdateDate = DateTime.Now;
                        _scoreRepository.Update(item);
                    }
                    _unitOfWork.Commit();

                }

                return new Result() { Status = true, ID = 0, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
            
        }

        public Score GetByScholasticAndGradeCourseStudentType(int scholastic, int grade, int course, int student, int type)
        {
            string[] includeData = new string[] { "Scholastic", "Course", "Grade", "Student" };
            return _scoreRepository.GetSingleByCondition(x => x.Active == true && x.ScholasticId == scholastic && x.GradeId == grade && x.CourseId == course && x.StudentId == student && x.Type == type, includeData);
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

        public Result Update(Score score)
        {
            try
            {
                score.UpdateDate = DateTime.Now;
                _scoreRepository.Update(score);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = score.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
