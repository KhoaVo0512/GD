using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ISchoolService
    {
        Result Add(School school);

        Result Update(School school);

        Result Delete(int id);

        IEnumerable<School> GetAll();

        IEnumerable<School> GetAllByActive(bool active);

        School GetByCode(string code);

        School GetById(int id);

        School GetByName(string name);

        School GetByCourse(int course);

        Result Save();
    }

    public class SchoolService : ISchoolService
    {
        ISchoolRepository _schoolRepository;
        IUnitOfWork _unitOfWork;

        public SchoolService(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
        {
            this._schoolRepository = schoolRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(School school)
        {
            try
            {
                school.Active = true;
                school.CreateDate = DateTime.Now;
                _schoolRepository.Add(school);
                _unitOfWork.Commit();
                
                return new Result() { Status = true, ID = school.ID, Notication = "Thêm thành công" };

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
                _schoolRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<School> GetAll()
        {
            return _schoolRepository.GetAll();
        }

       
        public IEnumerable<School> GetAllByActive(bool active)
        {
            return _schoolRepository.GetMulti(x => x.Active == active);
        }

        public School GetByCode(string code)
        {
            return _schoolRepository.GetSingleByCondition(x => x.Code.Trim().ToLower() == code.Trim().ToLower());
        }

        public School GetById(int id)
        {
            return _schoolRepository.GetSingleById(id);
        }

        public School GetByCourse(int course)
        {
            return _schoolRepository.GetByCourse(course);
        }

        public School GetByName(string name)
        {
            return _schoolRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
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

        public Result Update(School school)
        {
            try
            {
                school.UpdateDate = DateTime.Now;
                _schoolRepository.Update(school);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = school.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
