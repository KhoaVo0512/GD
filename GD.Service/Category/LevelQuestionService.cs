using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ILevelQuestionService
    {
        Result Add(LevelQuestion levelQuestion);

        Result Update(LevelQuestion levelQuestion);

        Result Delete(int id);

        IEnumerable<LevelQuestion> GetAll();

        IEnumerable<LevelQuestion> GetAllByActive(bool active);

        IEnumerable<LevelQuestion> GetAllByType(bool active, int type);

        LevelQuestion GetById(int id);

        LevelQuestion GetByNameAndType(string name, int type);

        Result Save();
    }

    public class LevelQuestionService : ILevelQuestionService
    {
        ILevelQuestionRepository _levelQuestionRepository;
        IUnitOfWork _unitOfWork;

        public LevelQuestionService(ILevelQuestionRepository levelQuestionRepository, IUnitOfWork unitOfWork)
        {
            this._levelQuestionRepository = levelQuestionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(LevelQuestion levelQuestion)
        {
            try
            {
                levelQuestion.Active = true;
                levelQuestion.CreateDate = DateTime.Now;
                _levelQuestionRepository.Add(levelQuestion);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = levelQuestion.ID, Notication = "Thêm thành công" };

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
                _levelQuestionRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<LevelQuestion> GetAll()
        {
            return _levelQuestionRepository.GetAll();
        }

        public IEnumerable<LevelQuestion> GetAllByType(bool active, int type)
        {
            string[] includeData = new string[] { "TypeQuestion" };
            return _levelQuestionRepository.GetMulti(x => x.Active == active && x.TypeId == type, includeData);
        }

        public IEnumerable<LevelQuestion> GetAllByActive(bool active)
        {
            string[] includeData = new string[] { "TypeQuestion" };
            return _levelQuestionRepository.GetMulti(x => x.Active == active, includeData);
        }

        public LevelQuestion GetById(int id)
        {
            return _levelQuestionRepository.GetSingleById(id);
        }

        public LevelQuestion GetByNameAndType(string name, int type)
        {
            string[] includeData = new string[] { "TypeQuestion" };
            return _levelQuestionRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.TypeId == type, includeData);
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

        public Result Update(LevelQuestion levelQuestion)
        {
            try
            {
                levelQuestion.UpdateDate = DateTime.Now;
                _levelQuestionRepository.Update(levelQuestion);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = levelQuestion.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
