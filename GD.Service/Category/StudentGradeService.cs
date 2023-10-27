using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IStudentGradeService
    {
        Result Add(StudentGrade studentGrade);

        Result Update(StudentGrade studentGrade);

        Result Delete(int id);

        IEnumerable<StudentGrade> GetAll();

        IEnumerable<StudentGrade> GetAllByActive(bool active);

        IEnumerable<StudentGrade> GetAllByScholasticAndGrade(int scholastic, int grade);

        StudentGrade GetById(int id);

        StudentGrade GetByStudentAndScholastic(int student, int scholastic);

        IEnumerable<StudentGrade> GetByStudent(int student, bool active);

        IEnumerable<StudentGrade> GetByGrade(int grade, bool active);

        IEnumerable<Student> GetStudentByGrade(int grade, bool active);

        IEnumerable<Student> GetAllByListStudentAndScholastic(List<int> student, int scholastic);

        IEnumerable<StudentGrade> GetAllByStudent(int student);

        Result Save();

        Result DeleteList(List<int> ids);
    }

    public class StudentGradeService : IStudentGradeService
    {
        IStudentGradeRepository _studentGradeRepository;
        IUnitOfWork _unitOfWork;

        public StudentGradeService(IStudentGradeRepository studentGradeRepository, IUnitOfWork unitOfWork)
        {
            this._studentGradeRepository = studentGradeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(StudentGrade studentGrade)
        {
            try
            {
                studentGrade.Active = true;
                studentGrade.CreateDate = DateTime.Now;
                _studentGradeRepository.Add(studentGrade);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = studentGrade.ID, Notication = "Thêm thành công" };

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
                _studentGradeRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public Result DeleteList(List <int> ids)
        {
            try
            {
                foreach(var item in ids)
                {
                    _studentGradeRepository.Delete(item);
                }
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<StudentGrade> GetAll()
        {
            return _studentGradeRepository.GetAll();
        }

        public IEnumerable<StudentGrade> GetAllByScholasticAndGrade(int scholastic, int grade)
        {
            string[] includeData = new string[] { "Scholastic", "Student", "Grade" };
            return _studentGradeRepository.GetMulti(x => x.ScholasticId == scholastic && x.GradeId == grade, includeData);
        }

        public IEnumerable<StudentGrade> GetAllByActive(bool active)
        {
            return _studentGradeRepository.GetMulti(x => x.Active == active);
        }

        public StudentGrade GetById(int id)
        {
            return _studentGradeRepository.GetSingleById(id);
        }

        public IEnumerable<StudentGrade> GetByStudent(int student, bool active)
        {
            return _studentGradeRepository.GetMulti(x => x.Active == active && x.StudentId == student);
        }

        public IEnumerable<StudentGrade> GetByGrade(int grade, bool active)
        {
            return _studentGradeRepository.GetMulti(x => x.Active == active && x.GradeId == grade);
        }

        public StudentGrade GetByStudentAndScholastic(int student, int scholastic)
        {
            return _studentGradeRepository.GetSingleByCondition(x => x.StudentId == student && x.ScholasticId == scholastic);
        }

        public IEnumerable<Student> GetStudentByGrade(int grade, bool active)
        {
            return _studentGradeRepository.GetStudentByGrade(grade, active);
        }

        public IEnumerable<StudentGrade> GetAllByStudent(int student)
        {
            string[] includeData = new string[] { "Scholastic", "Student", "Grade" };
            return _studentGradeRepository.GetMulti(x => x.Active == true && x.StudentId == student, includeData);
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

        public Result Update(StudentGrade studentGrade)
        {
            try
            {
                studentGrade.UpdateDate = DateTime.Now;
                _studentGradeRepository.Update(studentGrade);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = studentGrade.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<Student> GetAllByListStudentAndScholastic(List<int> student, int scholastic)
        {
            return _studentGradeRepository.GetAllByListStudentAndScholastic(student, scholastic);
        }
    }
}
