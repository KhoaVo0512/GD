using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IMenuService
    {
        Result Add(Menu menu);

        Result Update(Menu menu);

        Result Delete(int id);

        IEnumerable<Menu> GetAll();

        IEnumerable<Menu> GetAllByActive(bool active);

        Menu GetById(int id);

        Menu GetByName(string name);

        Menu GetByURL(string url);

        //Add roles to a sepcify group
        bool AddMenusToGroup(IEnumerable<ApplicationGroupMenu> groupMenus, int groupId);

        //Get list role by group id
        IEnumerable<Menu> GetListMenuByGroupId(int groupId);

        IEnumerable<Menu> GetListMenuByListGroupId(List<int> listId);

        Result Save();
    }

    public class MenuService : IMenuService
    {
        IMenuRepository _menuRepository;
        IApplicationGroupMenuRepository _applicationGroupMenuRepository;
        IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork, IApplicationGroupMenuRepository applicationGroupMenuRepository)
        {
            
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
            this._applicationGroupMenuRepository = applicationGroupMenuRepository;
        }

        public Result Add(Menu menu)
        {
            try
            {
                menu.Active = true;
                menu.CreateDate = DateTime.Now;
                _menuRepository.Add(menu);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = menu.ID, Notication = "Thêm thành công" };

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
                _menuRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public IEnumerable<Menu> GetAllByActive(bool active)
        {
            return _menuRepository.GetMulti(x => x.Active == active);
        }

        public Menu GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }

        public Menu GetByName(string name)
        {
            return _menuRepository.GetSingleByCondition(x => x.Name == name);
        }

        public Menu GetByURL(string url)
        {
            return _menuRepository.GetSingleByCondition(x => x.URL == url);
        }

        public bool AddMenusToGroup(IEnumerable<ApplicationGroupMenu> groupMenus, int groupId)
        {
            _applicationGroupMenuRepository.DeleteMulti(x => x.GroupId == groupId);
            foreach (var groupMenu in groupMenus)
            {
                _applicationGroupMenuRepository.Add(groupMenu);
            }
            return true;
        }

        public IEnumerable<Menu> GetListMenuByGroupId(int groupId)
        {
            return _menuRepository.GetListMenuByGroupId(groupId);
        }

        public IEnumerable<Menu> GetListMenuByListGroupId(List<int> listId)
        {
            return _menuRepository.GetListMenuByListGroupId(listId);
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

        public Result Update(Menu menu)
        {
            try
            {
                menu.UpdateDate = DateTime.Now;
                _menuRepository.Update(menu);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = menu.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
