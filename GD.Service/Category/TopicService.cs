using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ITopicService
    {
        Result Add(Topic topic);

        Result Update(Topic topic);

        Result Delete(int id);

        IEnumerable<Topic> GetAll();

        IEnumerable<Topic> GetAllByActive(bool active);

        IEnumerable<Topic> GetByCourse(int courseId);

        Topic GetById(int id);

        Topic GetByNameAndCourse(string name, int courseId);

        Result Save();
    }

    public class TopicService : ITopicService
    {
        ITopicRepository _topicRepository;
        IUnitOfWork _unitOfWork;

        public TopicService(ITopicRepository topicRepository, IUnitOfWork unitOfWork)
        {
            this._topicRepository = topicRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Topic topic)
        {
            try
            {
                topic.Active = true;
                topic.CreateDate = DateTime.Now;
                _topicRepository.Add(topic);
                _unitOfWork.Commit();
                
                return new Result() { Status = true, ID = topic.ID, Notication = "Thêm thành công" };

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
                _topicRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Topic> GetAll()
        {
            return _topicRepository.GetAll();
        }

       
        public IEnumerable<Topic> GetAllByActive(bool active)
        {
            return _topicRepository.GetMulti(x => x.Active == active);
        }

        public IEnumerable<Topic> GetByCourse(int courseId)
        {
            return _topicRepository.GetMulti(x => x.CourseId == courseId && x.Active == true);
        }

        public Topic GetById(int id)
        {
            return _topicRepository.GetSingleById(id);
        }

        public Topic GetByNameAndCourse(string name, int courseId)
        {
            return _topicRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.CourseId == courseId);
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

        public Result Update(Topic topic)
        {
            try
            {
                topic.UpdateDate = DateTime.Now;
                _topicRepository.Update(topic);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = topic.ID, Notication = "Cập nhật thành công" };
            }
            catch(Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
