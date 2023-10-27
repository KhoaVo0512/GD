using GD.Common.Exceptions;
using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GD.Service
{
    public interface IApplicationRoleService
    {
        ApplicationRole GetDetail(string id);

        ApplicationRole GetByName(string name);

        ApplicationRole GetByDescription(string description);

        IEnumerable<ApplicationRole> GetAll(int page, int pageSize, out int totalRow, string filter);

        IEnumerable<ApplicationRole> GetAll();

        Result Add(ApplicationRole appRole);

        Result Update(ApplicationRole AppRole);

        Result Delete(string id);

        //Add roles to a sepcify group
        bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId);

        //Get list role by group id
        IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId);

        void Save();
    }

    public class ApplicationRoleService : IApplicationRoleService
    {
        private IApplicationRoleRepository _appRoleRepository;
        private IApplicationRoleGroupRepository _appRoleGroupRepository;
        private IUnitOfWork _unitOfWork;

        public ApplicationRoleService(IUnitOfWork unitOfWork,
            IApplicationRoleRepository appRoleRepository, IApplicationRoleGroupRepository appRoleGroupRepository)
        {
            this._appRoleRepository = appRoleRepository;
            this._appRoleGroupRepository = appRoleGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(ApplicationRole appRole)
        {
            try
            {
                _appRoleRepository.Add(appRole);
                _unitOfWork.Commit();
                return new Result() { Status = true, IDString = appRole.Id, Notication = "Thêm thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, IDString = "", Notication = ex.Message };
            }
        }

        public bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId)
        {
            try
            {
                _appRoleGroupRepository.DeleteMulti(x => x.GroupId == groupId);
                foreach (var roleGroup in roleGroups)
                {
                    _appRoleGroupRepository.Add(roleGroup);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Result Delete(string id)
        {
            try
            {
                _appRoleRepository.DeleteMulti(x => x.Id == id);
                _unitOfWork.Commit();
                return new Result() { Status = true, IDString = "", Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, IDString = "", Notication = ex.Message };
            }
            
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            return _appRoleRepository.GetAll();
        }

        public IEnumerable<ApplicationRole> GetAll(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _appRoleRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Description.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Description).Skip(page * pageSize).Take(pageSize);
        }

        public ApplicationRole GetDetail(string id)
        {
            return _appRoleRepository.GetSingleByCondition(x => x.Id == id);
        }

        public ApplicationRole GetByName(string name)
        {
            return _appRoleRepository.GetSingleByCondition(x => x.Name == name);
        }

        public ApplicationRole GetByDescription(string description)
        {
            return _appRoleRepository.GetSingleByCondition(x => x.Description == description);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public Result Update(ApplicationRole AppRole)
        {
            try
            {
                _appRoleRepository.Update(AppRole);
                _unitOfWork.Commit();
                return new Result() { Status = true, IDString = AppRole.Id, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, IDString = "", Notication = ex.Message };
            }
        }

        public IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId)
        {
            return _appRoleRepository.GetListRoleByGroupId(groupId);
        }

    }
}