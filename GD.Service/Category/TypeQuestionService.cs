using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ITypeQuestionService
    {
        Result Add(TypeQuestion typeQuestion);

        Result Update(TypeQuestion typeQuestion);

        Result Delete(int id);

        IEnumerable<TypeQuestion> GetAll();

        IEnumerable<TypeQuestion> GetAllByChoiceAndActive(bool choice, bool active);

        IEnumerable<TypeQuestion> GetAllByActive(bool active);

        TypeQuestion GetById(int id);

        TypeQuestion GetByName(string name);

        Result Save();
    }

    public class TypeQuestionService : ITypeQuestionService
    {
        ITypeQuestionRepository _typeQuestionRepository;
        IUnitOfWork _unitOfWork;

        public TypeQuestionService(ITypeQuestionRepository typeQuestionRepository, IUnitOfWork unitOfWork)
        {
            this._typeQuestionRepository = typeQuestionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(TypeQuestion typeQuestion)
        {
            try
            {
                typeQuestion.Active = true;
                typeQuestion.CreateDate = DateTime.Now;
                _typeQuestionRepository.Add(typeQuestion);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = typeQuestion.ID, Notication = "Thêm thành công" };

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
                _typeQuestionRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<TypeQuestion> GetAll()
        {
            return _typeQuestionRepository.GetAll();
        }

        public IEnumerable<TypeQuestion> GetAllByChoiceAndActive(bool choice, bool active)
        {
            return _typeQuestionRepository.GetMulti(x => x.Active == active && x.Choice == choice);
        }

        public IEnumerable<TypeQuestion> GetAllByActive(bool active)
        {
            return _typeQuestionRepository.GetMulti(x => x.Active == active);
        }

        public TypeQuestion GetById(int id)
        {
            return _typeQuestionRepository.GetSingleById(id);
        }

        public TypeQuestion GetByName(string name)
        {
            return _typeQuestionRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
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

        public Result Update(TypeQuestion typeQuestion)
        {
            try
            {
                typeQuestion.UpdateDate = DateTime.Now;
                _typeQuestionRepository.Update(typeQuestion);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = typeQuestion.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
