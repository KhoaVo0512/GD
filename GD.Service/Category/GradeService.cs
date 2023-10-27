using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IGradeService
    {
        Result Add(Grade grade);

        Result Update(Grade grade);

        Result Delete(int id);

        IEnumerable<Grade> GetAll();

        IEnumerable<Grade> GetAllByActive(bool active);

        IEnumerable<Grade> GetAllByGradeGroups(List<int> gradeGroups);

        IEnumerable<Grade> GetAllByGradeGroup(int gradeGroup, bool active);

        IEnumerable<Grade> GetAllByScholastic(int scholastic);

        IEnumerable<Grade> GetListGradeNotSubClass(int scholastic);

        Grade GetById(int id);

        Grade GetByNameAndScholasticGradeGroup(string name, int scholasticId, int gradeGroupId);

        Grade GetByScholasticAndGradeGroupNumber(int scholastic, int gradeGroup, int number);

        Result Save();

        IEnumerable<Grade> GetListGradeUserId(string userId);

        bool UpdateNumberForGrade(IEnumerable<Grade> grades, int number);

        bool AddGradesToUser(IEnumerable<UserGrade> userGrades, string userId);

        bool ClearGradesToUser(string userId);
    }

    public class GradeService : IGradeService
    {
        IGradeRepository _gradeRepository;
        IUserGradeRepository _userGradeRepository;
        IUnitOfWork _unitOfWork;

        public GradeService(IGradeRepository gradeRepository, IUserGradeRepository userGradeRepository, IUnitOfWork unitOfWork)
        {
            this._gradeRepository = gradeRepository;
            this._userGradeRepository = userGradeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(Grade grade)
        {
            try
            {
                grade.Active = true;
                grade.CreateDate = DateTime.Now;
                _gradeRepository.Add(grade);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = grade.ID, Notication = "Thêm thành công" };

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
                _gradeRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<Grade> GetAll()
        {
            return _gradeRepository.GetAll();
        }


        public IEnumerable<Grade> GetAllByActive(bool active)
        {
            string[] includeData = new string[] { "Scholastic" };
            return _gradeRepository.GetMulti(x => x.Active == active, includeData);
        }

        public IEnumerable<Grade> GetAllByGradeGroups(List<int> gradeGroups)
        {
            string[] includeData = new string[] { "Scholastic" };
            return _gradeRepository.GetMulti(x => x.Active == true && gradeGroups.Contains(x.GradeGroupId), includeData);
        }
        public IEnumerable<Grade> GetAllByGradeGroup(int gradeGroup, bool active)
        {
            string[] includeData = new string[] { "Scholastic" };
            return _gradeRepository.GetMulti(x => x.Active == true && x.GradeGroupId == gradeGroup, includeData);
        }


        public Grade GetById(int id)
        {
            string[] includeData = new string[] { "GradeGroup", "Scholastic" };
            return _gradeRepository.GetSingleByCondition(x => x.ID == id, includeData);
        }

        public Grade GetByNameAndScholasticGradeGroup(string name, int scholasticId, int gradeGroupId)
        {
            return _gradeRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.ScholasticId == scholasticId && x.GradeGroupId == gradeGroupId);
        }

        public Grade GetByScholasticAndGradeGroupNumber(int scholastic, int gradeGroup, int number)
        {
            return _gradeRepository.GetSingleByCondition(x => x.Number == number && x.ScholasticId == scholastic && x.GradeGroupId == gradeGroup);
        }

        public IEnumerable<Grade> GetAllByScholastic(int scholastic)
        {
            return _gradeRepository.GetMulti(x => x.Active == true && x.ScholasticId == scholastic);
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

        public Result Update(Grade grade)
        {
            try
            {
                grade.UpdateDate = DateTime.Now;
                _gradeRepository.Update(grade);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = grade.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<Grade> GetListGradeUserId(string userId)
        {
            return _gradeRepository.GetListGradeUserId(userId);
        }
        
        public bool UpdateNumberForGrade(IEnumerable<Grade> grades, int number)
        {
            try
            {
                foreach (var grade in grades)
                {
                    grade.Active = true;
                    grade.UpdateDate = DateTime.Now;
                    grade.Name = "Lớp " + number + "" + grade.Prefix;
                    grade.Number = number;
                    _gradeRepository.Update(grade);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddGradesToUser(IEnumerable<UserGrade> userGrades, string userId)
        {
            try
            {
                _userGradeRepository.DeleteMulti(x => x.UserId == userId);
                foreach (var userGrade in userGrades)
                {
                    userGrade.Active = true;
                    userGrade.ActiveDate = DateTime.Now;
                    userGrade.CreateDate = DateTime.Now;
                    _userGradeRepository.Add(userGrade);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClearGradesToUser(string userId)
        {
            try
            {
                _userGradeRepository.DeleteMulti(x => x.UserId == userId);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Grade> GetListGradeNotSubClass(int scholastic)
        {
            return _gradeRepository.GetListGradeNotSubClass(scholastic);
        }
    }
}
