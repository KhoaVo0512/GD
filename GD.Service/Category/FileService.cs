using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IFileService
    {
        Result Add(File file);

        Result Update(File file);

        Result Delete(int id);

        IEnumerable<File> GetAll();

        IEnumerable<File> GetAllByActive(bool active);

        File GetById(int id);

        File GetByNameAndCourseTopic(string name, int courseId, int topicId);

        IEnumerable<File> GetByCourseTopicCategory(int courseId, int topicId, int category);

        IEnumerable<File> GetByCourseTopicCategoryType(int courseId, int topicId, int category, int type);

        IEnumerable<File> GetByCourseTopicCategorySearch(int courseId, int topicId, int category, string search);

        IEnumerable<File> GetByCourseTopicCategoryTypeSearch(int courseId, int topicId, int category, int type, string search);

        IEnumerable<File> GetAllByCategory(int category);

        IEnumerable<File> GetByCategoryAndSearch(int category, string search);

        IEnumerable<File> GetByCourseAndCategory(int courseId, int category);

        IEnumerable<File> GetByCourseCategoryAndSearch(int courseId, int category, string search);

        Result Save();
    }

    public class FileService : IFileService
    {
        IFileRepository _fileRepository;
        IUnitOfWork _unitOfWork;

        public FileService(IFileRepository fileRepository, IUnitOfWork unitOfWork)
        {
            this._fileRepository = fileRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(File file)
        {
            try
            {
                file.Active = true;
                file.CreateDate = DateTime.Now;
                _fileRepository.Add(file);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = file.ID, Notication = "Thêm thành công" };

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
                _fileRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<File> GetAll()
        {
            return _fileRepository.GetAll();
        }


        public IEnumerable<File> GetAllByActive(bool active)
        {
            return _fileRepository.GetMulti(x => x.Active == active);
        }

        public File GetById(int id)
        {
            return _fileRepository.GetSingleById(id);
        }

        public File GetByNameAndCourseTopic(string name, int courseId, int topicId)
        {
            return _fileRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.CourseId == courseId && x.TopicId == topicId && x.Active == true);
        }

        public IEnumerable<File> GetByCourseTopicCategory(int courseId, int topicId, int category)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.CourseId == courseId && x.TopicId == topicId && x.Category == category && x.Active == true, includeData);
        }

        public IEnumerable<File> GetByCourseTopicCategoryType(int courseId, int topicId, int category, int type)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.CourseId == courseId && x.TopicId == topicId && x.Category == category && x.Type == type && x.Active == true, includeData);
        }

        public IEnumerable<File> GetByCourseTopicCategorySearch(int courseId, int topicId, int category, string search)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.CourseId == courseId && x.TopicId == topicId && x.Category == category && x.Name.ToLower().Contains(search.ToLower().Trim()) && x.Active == true, includeData);
        }

        public IEnumerable<File> GetByCourseTopicCategoryTypeSearch(int courseId, int topicId, int category, int type, string search)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.CourseId == courseId && x.TopicId == topicId && x.Category == category && x.Name.ToLower().Contains(search.ToLower().Trim()) && x.Type == type && x.Active == true, includeData);
        }


        public IEnumerable<File> GetAllByCategory(int category)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.Category == category && x.Active == true, includeData);
        }

        public IEnumerable<File> GetByCategoryAndSearch(int category, string search)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.Category == category && x.Active == true && x.Name.IndexOf(search) > -1, includeData);
        }

        public IEnumerable<File> GetByCourseAndCategory(int courseId, int category)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.Category == category && x.Active == true && x.CourseId == courseId, includeData);
        }

        public IEnumerable<File> GetByCourseCategoryAndSearch(int courseId, int category, string search)
        {
            string[] includeData = new string[] { "Topic", "Course" };
            return _fileRepository.GetMulti(x => x.Category == category && x.Active == true && x.CourseId == courseId && x.Name.ToLower().Contains(search.ToLower().Trim()), includeData);
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

        public Result Update(File file)
        {
            try
            {
                file.UpdateDate = DateTime.Now;
                _fileRepository.Update(file);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = file.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
