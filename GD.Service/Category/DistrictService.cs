using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IDistrictService
    {
        Result Add(District district);

        Result Update(District district);

        Result Delete(int id);

        IEnumerable<District> GetAll();

        IEnumerable<District> GetAllByActive(bool active);

        IEnumerable<District> GetByProvince(int provinceId);

        District GetById(int id);

        District GetByCode(string code);

        District GetByNameAndProvince(string name, int provinceId);

        District GetByContainName(string name, int province);

        Result Save();
    }

    public class DistrictService : IDistrictService
    {
        IDistrictRepository _districtRepository;
        IUnitOfWork _unitOfWork;

        public DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            this._districtRepository = districtRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(District district)
        {
            try
            {
                district.Active = true;
                district.CreateDate = DateTime.Now;
                _districtRepository.Add(district);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = district.ID, Notication = "Thêm thành công" };

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
                _districtRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<District> GetAll()
        {
            return _districtRepository.GetAll();
        }


        public IEnumerable<District> GetAllByActive(bool active)
        {
            return _districtRepository.GetByActive(active);
        }

        public District GetById(int id)
        {
            return _districtRepository.GetSingleById(id);
        }

        public District GetByContainName(string name, int province)
        {
            return _districtRepository.GetSingleByCondition(x => x.Active == true && x.Name.ToLower().Trim().Contains(name.ToLower().Trim()) && x.ProvinceId == province);
        }

        public District GetByCode(string code)
        {
            return _districtRepository.GetSingleByCondition(x => x.Code.Trim().ToLower() == code.Trim().ToLower());
        }

        public District GetByNameAndProvince(string name, int provinceId)
        {
            return _districtRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.ProvinceId == provinceId);
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

        public Result Update(District district)
        {
            try
            {
                district.UpdateDate = DateTime.Now;
                _districtRepository.Update(district);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = district.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<District> GetByProvince(int provinceId)
        {
            return _districtRepository.GetMulti(x => x.Active == true && x.ProvinceId == provinceId);
        }
    }
}
