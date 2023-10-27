using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GD.Service
{
    public interface IQuestionService
    {
        Result Add(Question question);

        Result Update(Question question);

        Result Delete(int id);

        IEnumerable<Question> GetAll();

        IEnumerable<Question> GetAllByActive(bool active);

        IEnumerable<Question> GetAllByActiveAndCourseTopic(bool active, int course, int topic);

        IEnumerable<Question> GetUserByActiveAndCourseTopic(bool active, int course, int topic, string user, bool by);

        IEnumerable<Question> GetAllByActiveAndCourseTopicLevel(bool active, int course, int topic, int level);

        IEnumerable<Question> GetUserByActiveAndCourseTopicLevel(bool active, int course, int topic, int level, string user, bool by);

        Question GetById(int id);

        Question GetByNameAndTopic(string name, int topic);

        IEnumerable<Question> GetQuestionByTest(int test);

        Result Save();
    }

    public class QuestionService : IQuestionService
    {
        IQuestionRepository _questionRepository;
        ITestQuestionRepository _testQuestionRepository;
        IUnitOfWork _unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, ITestQuestionRepository testQuestionRepository, IUnitOfWork unitOfWork)
        {
            this._questionRepository = questionRepository;
            this._testQuestionRepository = testQuestionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Question question)
        {
            try
            {
                question.Active = true;
                question.ActiveDate = DateTime.Now;
                question.CreateDate = DateTime.Now;
                _questionRepository.Add(question);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = question.ID, Notication = "Thêm thành công" };

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
                _questionRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }


        public IEnumerable<Question> GetAllByActive(bool active)
        {
            return _questionRepository.GetMulti(x => x.Active == active);
        }

        public IEnumerable<Question> GetAllByActiveAndCourseTopic(bool active, int course, int topic)
        {
            string[] includeData = new string[] { "Topic", "TypeQuestion", "LevelQuestion" };
            return _questionRepository.GetMulti(x => x.Active == active && x.TopicId == topic, includeData);
        }

        public IEnumerable<Question> GetUserByActiveAndCourseTopic(bool active, int course, int topic, string user, bool by)
        {
            string[] includeData = new string[] { "Topic", "TypeQuestion", "LevelQuestion" };
            if (by)
            {
                return _questionRepository.GetMulti(x => x.Active == active && x.TopicId == topic && x.CreateBy == user, includeData);
            }
            else
            {
                return _questionRepository.GetMulti(x => x.Active == active && x.TopicId == topic && x.CreateBy != user, includeData);
            }
            
        }

        public IEnumerable<Question> GetAllByActiveAndCourseTopicLevel(bool active, int course, int topic, int level)
        {
            string[] includeData = new string[] { "Topic", "TypeQuestion", "LevelQuestion" };
            return _questionRepository.GetMulti(x => x.Active == active && x.TopicId == topic && x.LevelId == level, includeData);
        }

        public IEnumerable<Question> GetUserByActiveAndCourseTopicLevel(bool active, int course, int topic, int level, string user, bool by)
        {
            string[] includeData = new string[] { "Topic", "TypeQuestion", "LevelQuestion" };
            if (by)
            {
                return _questionRepository.GetMulti(x => x.Active == active && x.TopicId == topic && x.LevelId == level && x.CreateBy == user, includeData);
            }
            else
            {
                return _questionRepository.GetMulti(x => x.Active == active && x.TopicId == topic && x.LevelId == level && x.CreateBy != user, includeData);
            }
        }

        public IEnumerable<Question> GetQuestionByTest(int test)
        {
            var listTestQuestion = _testQuestionRepository.GetMulti(x => x.Active == true && x.TestId == test).ToList().Select(x => x.QuestionId).ToList();
            string[] includeData = new string[] { "Topic", "TypeQuestion", "LevelQuestion" };
            return _questionRepository.GetMulti(x => x.Active == true && listTestQuestion.Contains(x.ID), includeData);
        }

        public Question GetById(int id)
        {
            string[] includeData = new string[] { "Topic", "TypeQuestion", "LevelQuestion" };
            return _questionRepository.GetSingleByCondition(x => x.ID == id, includeData);
        }

        public Question GetByNameAndTopic(string name, int topic)
        {
            return _questionRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.TopicId == topic && x.Active == true);
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

        public Result Update(Question question)
        {
            try
            {
                question.UpdateDate = DateTime.Now;
                _questionRepository.Update(question);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = question.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
