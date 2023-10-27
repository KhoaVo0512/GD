using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface ICourseService
    {
        Result Add(Course course);

        Result Update(Course course);

        Result Delete(int id);

        IEnumerable<Course> GetAll();

        IEnumerable<Course> GetAllByActive(bool active);

        IEnumerable<Course> GetAllByListID(List<int> listID);

        IEnumerable<Course> GetAllByGradeGroups(List<int> gradeGroups);

        IEnumerable<Course> GetListCourseByUserId(string userId);

        Course GetById(int id);

        Course GetByNameAndGradeGroup(string name, int GradeGroupId);

        Result Save();

        bool AddCoursesToUser(IEnumerable<UserCourse> userCourses, string userId);

        bool ClearCoursesToUser(string userId);
    }

    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;
        IUserCourseRepository _userCourseRepository;
        IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepository, IUserCourseRepository userCourseRepository, IUnitOfWork unitOfWork)
        {
            this._courseRepository = courseRepository;
            this._userCourseRepository = userCourseRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Course course)
        {
            try
            {
                course.Active = true;
                course.CreateDate = DateTime.Now;
                _courseRepository.Add(course);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = course.ID, Notication = "Thêm thành công" };

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
                _courseRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }


        public IEnumerable<Course> GetAllByActive(bool active)
        {
            string[] includeData = new string[] { "GradeGroup" };
            return _courseRepository.GetMulti(x => x.Active == active, includeData);
        }

        public IEnumerable<Course> GetAllByListID(List<int> listID)
        {
            string[] includeData = new string[] { "GradeGroup" };
            return _courseRepository.GetMulti(x => listID.Contains(x.ID), includeData);
        }

        public IEnumerable<Course> GetAllByGradeGroups(List<int> gradeGroups)
        {
            return _courseRepository.GetMulti(x => x.Active == true && gradeGroups.Contains(x.GradeGroupId));
        }

        public IEnumerable<Course> GetListCourseByUserId(string userId)
        {
            return _courseRepository.GetListCourseByUserId(userId);
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetSingleById(id);
        }

        public Course GetByNameAndGradeGroup(string name, int GradeGroupId)
        {
            return _courseRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.GradeGroupId == GradeGroupId);
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

        public Result Update(Course course)
        {
            try
            {
                course.UpdateDate = DateTime.Now;
                _courseRepository.Update(course);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = course.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public bool AddCoursesToUser(IEnumerable<UserCourse> userCourses, string userId)
        {
            try
            {
                _userCourseRepository.DeleteMulti(x => x.UserId == userId);
                foreach (var userCourse in userCourses)
                {
                    userCourse.Active = true;
                    userCourse.ActiveDate = DateTime.Now;
                    userCourse.CreateDate = DateTime.Now;
                    _userCourseRepository.Add(userCourse);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ClearCoursesToUser(string userId)
        {
            try
            {
                _userCourseRepository.DeleteMulti(x => x.UserId == userId);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
