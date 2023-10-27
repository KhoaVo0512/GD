using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IGradeGroupService
    {
        Result Add(GradeGroup gradeGroup);

        Result Update(GradeGroup gradeGroup);

        Result Delete(int id);

        IEnumerable<GradeGroup> GetAll();

        IEnumerable<GradeGroup> GetAllByActive(bool active);

        IEnumerable<GradeGroup> GetListGradeGroupUserId(string userId);

        GradeGroup GetById(int id);

        IEnumerable<GradeGroup> GetByName(string name);

        GradeGroup GetByNameAndSchool(string name, int schoolId);

        GradeGroup GetByNumberAndSchool(int number, int schoolId);

        bool AddGradeGroupsToUser(IEnumerable<UserGradeGroup> gradeGroups, string userId);

        bool ClearGradeGroupsToUser(string userId);

        Result Save();
    }

    public class GradeGroupService : IGradeGroupService
    {
        IGradeGroupRepository _gradeGroupRepository;
        IUserGradeGroupRepository _userGradeGroupRepository;
        IUnitOfWork _unitOfWork;

        public GradeGroupService(IGradeGroupRepository gradeGroupRepository, IUserGradeGroupRepository userGradeGroupRepository, IUnitOfWork unitOfWork)
        {
            this._gradeGroupRepository = gradeGroupRepository;
            this._userGradeGroupRepository = userGradeGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(GradeGroup gradeGroup)
        {
            try
            {
                gradeGroup.Active = true;
                gradeGroup.CreateDate = DateTime.Now;
                _gradeGroupRepository.Add(gradeGroup);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = gradeGroup.ID, Notication = "Thêm thành công" };

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
                _gradeGroupRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }

        }

        public IEnumerable<GradeGroup> GetAll()
        {
            return _gradeGroupRepository.GetAll();
        }


        public IEnumerable<GradeGroup> GetAllByActive(bool active)
        {
            string[] includeData = new string[] { "School" };
            return _gradeGroupRepository.GetMulti(x => x.Active == active, includeData);
        }

        public IEnumerable<GradeGroup> GetListGradeGroupUserId(string userId)
        {
            return _gradeGroupRepository.GetListGradeGroupUserId(userId);
        }

        public GradeGroup GetByNumberAndSchool(int number, int schoolId)
        {
            string[] includeData = new string[] { "School" };
            return _gradeGroupRepository.GetSingleByCondition(x => x.Number == number && x.SchoolId == schoolId, includeData);
        }

        public GradeGroup GetById(int id)
        {
            string[] includeData = new string[] { "School" };
            return _gradeGroupRepository.GetSingleByCondition(x => x.ID == id, includeData);
        }

        public IEnumerable<GradeGroup> GetByName(string name)
        {
            return _gradeGroupRepository.GetMulti(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public GradeGroup GetByNameAndSchool(string name, int schoolId)
        {
            return _gradeGroupRepository.GetSingleByCondition(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && x.SchoolId == schoolId);
        }

        public bool AddGradeGroupsToUser(IEnumerable<UserGradeGroup> gradeGroups, string userId)
        {
            try
            {
                _userGradeGroupRepository.DeleteMulti(x => x.UserId == userId);
                foreach (var gradeGroup in gradeGroups)
                {
                    gradeGroup.Active = true;
                    gradeGroup.ActiveDate = DateTime.Now;
                    gradeGroup.CreateDate = DateTime.Now;
                    _userGradeGroupRepository.Add(gradeGroup);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
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

        public Result Update(GradeGroup gradeGroup)
        {
            try
            {
                gradeGroup.UpdateDate = DateTime.Now;
                _gradeGroupRepository.Update(gradeGroup);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = gradeGroup.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public bool ClearGradeGroupsToUser(string userId)
        {
            try
            {
                _userGradeGroupRepository.DeleteMulti(x => x.UserId == userId);
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
