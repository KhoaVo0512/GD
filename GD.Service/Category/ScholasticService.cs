using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IScholasticService
    {
        Result Add(Scholastic scholastic);

        Result Update(Scholastic scholastic);

        Result Delete(int id);

        IEnumerable<Scholastic> GetAll();

        IEnumerable<Scholastic> GetAllByActive(bool active);

        Scholastic GetById(int id);

        Scholastic GetByName(string name);

        Scholastic GetByTime(DateTime fromTime, DateTime toTime);

        Result Save();
    }

    public class ScholasticService : IScholasticService
    {
        IScholasticRepository _scholasticRepository;
        IUnitOfWork _unitOfWork;

        public ScholasticService(IScholasticRepository scholasticRepository, IUnitOfWork unitOfWork)
        {
            this._scholasticRepository = scholasticRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Scholastic scholastic)
        {
            try
            {
                scholastic.Active = true;
                scholastic.CreateDate = DateTime.Now;
                _scholasticRepository.Add(scholastic);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = scholastic.ID, Notication = "Thêm thành công" };

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
                _scholasticRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Scholastic> GetAll()
        {
            return _scholasticRepository.GetAll();
        }


        public IEnumerable<Scholastic> GetAllByActive(bool active)
        {
            return _scholasticRepository.GetMulti(x => x.Active == active);
        }

        public Scholastic GetById(int id)
        {
            return _scholasticRepository.GetSingleById(id);
        }

        public Scholastic GetByName(string name)
        {
            return _scholasticRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public Scholastic GetByTime(DateTime fromTime, DateTime toTime)
        {
            return _scholasticRepository.GetSingleByCondition(x => x.FromTime.Year == fromTime.Year && x.ToTime.Year == toTime.Year);
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

        public Result Update(Scholastic scholastic)
        {
            try
            {
                scholastic.UpdateDate = DateTime.Now;
                _scholasticRepository.Update(scholastic);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = scholastic.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
