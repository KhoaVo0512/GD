using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ILevelService
    {
        Result Add(Level level);

        Result Update(Level level);

        Result Delete(int id);

        IEnumerable<Level> GetAll();

        Level GetMinValue();

        IEnumerable<Level> GetAllByActive(bool active);

        Level GetById(int id);

        Level GetByValue(int value);

        Level GetByName(string name);

        Result Save();
    }

    public class LevelService : ILevelService
    {
        ILevelRepository _levelRepository;
        IUnitOfWork _unitOfWork;

        public LevelService(ILevelRepository levelRepository, IUnitOfWork unitOfWork)
        {
            this._levelRepository = levelRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Level level)
        {
            try {
                level.Active = true;
                level.CreateDate = DateTime.Now;
                _levelRepository.Add(level);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = level.ID, Notication = "Thêm thành công" };
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
                _levelRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<Level> GetAll()
        {
            return _levelRepository.GetAll();
        }

        public Level GetMinValue()
        {
            return _levelRepository.GetMinValue();
        }

        public IEnumerable<Level> GetAllByActive(bool active)
        {
            return _levelRepository.GetMulti(x => x.Active == active);
        }

        public Level GetById(int id)
        {
            return _levelRepository.GetSingleById(id);
        }

        public Level GetByValue(int value)
        {
            return _levelRepository.GetByValue(value);
        }

        public Level GetByName(string name)
        {
            return _levelRepository.GetByName(name);
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

        public Result Update(Level level)
        {
            try
            {
                level.UpdateDate = DateTime.Now;
                _levelRepository.Update(level);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = level.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
               return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
