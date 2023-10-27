using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IProvinceService
    {
        Result Add(Province province);

        Result Update(Province province);

        Result Delete(int id);

        IEnumerable<Province> GetAll();

        IEnumerable<Province> GetAllByActive(bool active);

        Province GetById(int id);

        Province GetByContainName(string name);

        Province GetByCode(string code);

        Province GetByName(string name);

        Result Save();
    }

    public class ProvinceService : IProvinceService
    {
        IProvinceRepository _provinceRepository;
        IUnitOfWork _unitOfWork;

        public ProvinceService(IProvinceRepository provinceRepository, IUnitOfWork unitOfWork)
        {
            this._provinceRepository = provinceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Province province)
        {
            try
            {
                province.Active = true;
                province.CreateDate = DateTime.Now;
                _provinceRepository.Add(province);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = province.ID, Notication = "Thêm thành công" };

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
                _provinceRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Province> GetAll()
        {
            return _provinceRepository.GetAll();
        }


        public IEnumerable<Province> GetAllByActive(bool active)
        {
            return _provinceRepository.GetMulti(x => x.Active == active);
        }

        public Province GetById(int id)
        {
            return _provinceRepository.GetSingleById(id);
        }

        public Province GetByContainName(string name)
        {
            return _provinceRepository.GetSingleByCondition(x => x.Active == true && x.Name.ToLower().Trim().Contains(name.ToLower().Trim()));
        }

        public Province GetByCode(string code)
        {
            return _provinceRepository.GetSingleByCondition(x => x.Code.Trim().ToLower() == code.Trim().ToLower());
        }
        public Province GetByName(string name)
        {
            return _provinceRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
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

        public Result Update(Province province)
        {
            try
            {
                province.UpdateDate = DateTime.Now;
                _provinceRepository.Update(province);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = province.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
