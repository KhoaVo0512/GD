using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IWardService
    {
        Result Add(Ward ward);

        Result Update(Ward ward);

        Result Delete(int id);

        IEnumerable<Ward> GetAll();

        IEnumerable<Ward> GetAllByActive(bool active);

        IEnumerable<Ward> GetAllByDistrict(int district);

        Ward GetById(int id);

        Ward GetByCode(string code);

        Ward GetByNameAndDistrict(string name, int district);

        Ward GetByContainName(string name, int district);

        Result Save();
    }

    public class WardService : IWardService
    {
        IWardRepository _wardRepository;
        IUnitOfWork _unitOfWork;

        public WardService(IWardRepository wardRepository, IUnitOfWork unitOfWork)
        {
            this._wardRepository = wardRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Ward ward)
        {
            try
            {
                ward.Active = true;
                ward.CreateDate = DateTime.Now;
                _wardRepository.Add(ward);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = ward.ID, Notication = "Thêm thành công" };

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
                _wardRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Ward> GetAll()
        {
            return _wardRepository.GetAll();
        }


        public IEnumerable<Ward> GetAllByActive(bool active)
        {
            return _wardRepository.GetMulti(x => x.Active == active);
        }

        public Ward GetById(int id)
        {
            return _wardRepository.GetSingleById(id);
        }

        public Ward GetByContainName(string name, int district)
        {
            return _wardRepository.GetSingleByCondition(x => x.Active == true && x.Name.ToLower().Trim().Contains(name.ToLower().Trim()) && x.DistrictId == district);
        }

        public Ward GetByCode(string code)
        {
            return _wardRepository.GetSingleByCondition(x => x.Code.Trim().ToLower() == code.Trim().ToLower());
        }

        public Ward GetByNameAndDistrict(string name, int district)
        {
            return _wardRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.DistrictId == district);
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

        public Result Update(Ward ward)
        {
            try
            {
                ward.UpdateDate = DateTime.Now;
                _wardRepository.Update(ward);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = ward.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<Ward> GetAllByDistrict(int district)
        {
            return _wardRepository.GetMulti(x => x.Active == true && x.DistrictId == district);
        }
    }
}
