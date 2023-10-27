using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IStudentService
    {
        Result Add(Student student);

        Result Update(Student student);

        Result Delete(int id);

        IEnumerable<Student> GetAll();

        IEnumerable<Student> GetAllByActive(bool active);

        IEnumerable<Student> GetByOtherGrade(int scholastic, int grade);

        Student GetByCode(string code);

        Student GetById(int id);

        Student GetByFullNameAndBirthday(string fullName, DateTime birthday);

        Result Save();
    }

    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository;
        IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            this._studentRepository = studentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Student student)
        {
            try
            {
                student.Active = true;
                student.CreateDate = DateTime.Now;
                _studentRepository.Add(student);
                _unitOfWork.Commit();
                
                return new Result() { Status = true, ID = student.ID, Notication = "Thêm thành công" };

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
                _studentRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

       
        public IEnumerable<Student> GetAllByActive(bool active)
        {
            return _studentRepository.GetMulti(x => x.Active == active);
        }

        public Student GetByCode(string code)
        {
            return _studentRepository.GetSingleByCondition(x => x.Code.Trim().ToLower() == code.Trim().ToLower());
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetSingleById(id);
        }

        public IEnumerable<Student> GetByOtherGrade(int scholastic, int grade)
        {
            return _studentRepository.GetByOtherGrade(scholastic, grade);
        }

        public Student GetByFullNameAndBirthday(string fullName, DateTime birthday)
        {
            return _studentRepository.GetSingleByCondition(x => x.FullName.Trim().ToLower() == fullName.Trim().ToLower() && x.BirthDay.Day == birthday.Day && x.BirthDay.Month == birthday.Month && x.BirthDay.Year == birthday.Year);
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

        public Result Update(Student student)
        {
            try
            {
                student.UpdateDate = DateTime.Now;
                _studentRepository.Update(student);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = student.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
