using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IAnswerService
    {
        Result Add(Answer answer);

        Result Update(Answer answer);

        Result Delete(int id);

        IEnumerable<Answer> GetAll();

        IEnumerable<Answer> GetAllByActive(bool active);

        IEnumerable<Answer> GetAllByQuestion(int question);

        IEnumerable<Answer> GetAllByListQuestion(List<int> questions);

        Answer GetById(int id);

        Answer GetByName(string name);

        Result Save();
    }

    public class AnswerService : IAnswerService
    {
        IAnswerRepository _answerRepository;
        IUnitOfWork _unitOfWork;

        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            this._answerRepository = answerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Answer answer)
        {
            try
            {
                answer.Active = true;
                answer.ActiveDate = DateTime.Now;
                answer.CreateDate = DateTime.Now;
                _answerRepository.Add(answer);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = answer.ID, Notication = "Thêm thành công" };

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
                _answerRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Answer> GetAll()
        {
            return _answerRepository.GetAll();
        }


        public IEnumerable<Answer> GetAllByActive(bool active)
        {
            return _answerRepository.GetMulti(x => x.Active == active);
        }

        public IEnumerable<Answer> GetAllByQuestion(int question)
        {
            return _answerRepository.GetMulti(x => x.Active == true && x.QuestionId == question);
        }

        public IEnumerable<Answer> GetAllByListQuestion(List<int> questions)
        {
            return _answerRepository.GetMulti(x => x.Active == true && questions.Contains(x.QuestionId));
        }

        public Answer GetById(int id)
        {
            string[] includeData = new string[] { "Question" };
            return _answerRepository.GetSingleByCondition(x => x.ID == id, includeData);
        }

        public Answer GetByName(string name)
        {
            return _answerRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
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

        public Result Update(Answer answer)
        {
            try
            {
                answer.UpdateDate = DateTime.Now;
                _answerRepository.Update(answer);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = answer.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

    }
}
