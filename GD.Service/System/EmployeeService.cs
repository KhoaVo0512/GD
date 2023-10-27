using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IEmployeeService
    {
        Result Add(Employee employee);

        Result Update(Employee employee);

        Result Delete(int id);

        IEnumerable<Employee> GetAll();

        IEnumerable<Employee> GetAllByActive(bool active);

        Employee GetByCode(string code);

        Employee GetById(int id);

        Employee GetByFullNameAndBirthday(string fullName, DateTime birthday);

        Result Save();
    }

    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this._employeeRepository = employeeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Employee employee)
        {
            try
            {
                employee.Active = true;
                employee.CreateDate = DateTime.Now;
                _employeeRepository.Add(employee);
                _unitOfWork.Commit();
                
                return new Result() { Status = true, ID = employee.ID, Notication = "Thêm thành công" };

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
                _employeeRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

       
        public IEnumerable<Employee> GetAllByActive(bool active)
        {
            return _employeeRepository.GetMulti(x => x.Active == active);
        }

        public Employee GetByCode(string code)
        {
            return _employeeRepository.GetSingleByCondition(x => x.Code.Trim().ToLower() == code.Trim().ToLower());
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetSingleById(id);
        }

        public Employee GetByFullNameAndBirthday(string fullName, DateTime birthday)
        {
            return _employeeRepository.GetSingleByCondition(x => x.FullName.Trim().ToLower() == fullName.Trim().ToLower() && x.BirthDay.Day == birthday.Day && x.BirthDay.Month == birthday.Month && x.BirthDay.Year == birthday.Year);
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

        public Result Update(Employee employee)
        {
            try
            {
                employee.UpdateDate = DateTime.Now;
                _employeeRepository.Update(employee);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = employee.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
