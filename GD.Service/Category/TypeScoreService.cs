using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ITypeScoreService
    {
        Result Add(TypeScore typeScore);

        Result Update(TypeScore typeScore);

        Result Delete(int id);

        IEnumerable<TypeScore> GetAll();

        IEnumerable<TypeScore> GetAllByActive(bool active);

        TypeScore GetById(int id);

        TypeScore GetByName(string name);

        Result Save();
    }

    public class TypeScoreService : ITypeScoreService
    {
        ITypeScoreRepository _typeScoreRepository;
        IUnitOfWork _unitOfWork;

        public TypeScoreService(ITypeScoreRepository typeScoreRepository, IUnitOfWork unitOfWork)
        {
            this._typeScoreRepository = typeScoreRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(TypeScore typeScore)
        {
            try
            {
                typeScore.Active = true;
                typeScore.CreateDate = DateTime.Now;
                _typeScoreRepository.Add(typeScore);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = typeScore.ID, Notication = "Thêm thành công" };

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
                _typeScoreRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<TypeScore> GetAll()
        {
            return _typeScoreRepository.GetAll();
        }


        public IEnumerable<TypeScore> GetAllByActive(bool active)
        {
            return _typeScoreRepository.GetMulti(x => x.Active == active);
        }

        public TypeScore GetById(int id)
        {
            return _typeScoreRepository.GetSingleById(id);
        }

        public TypeScore GetByName(string name)
        {
            return _typeScoreRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
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

        public Result Update(TypeScore typeScore)
        {
            try
            {
                typeScore.UpdateDate = DateTime.Now;
                _typeScoreRepository.Update(typeScore);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = typeScore.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
