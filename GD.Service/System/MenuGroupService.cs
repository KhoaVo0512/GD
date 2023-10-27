using GD.Data.Infrastructure;
using GD.Data.Repositories;
using GD.Model.Models;
using System;
using System.Collections.Generic;

namespace GD.Service
{
    public interface IMenuGroupService
    {
        Result Add(MenuGroup menuGroup);

        Result Update(MenuGroup menuGroup);

        Result Delete(int id);

        IEnumerable<MenuGroup> GetAll();

        IEnumerable<MenuGroup> GetAllByActive(bool active);

        MenuGroup GetById(int id);

        MenuGroup GetByName(string name);

        Result Save();
    }

    public class MenuGroupService : IMenuGroupService
    {
        IMenuGroupRepository _menuGroupRepository;
        IUnitOfWork _unitOfWork;

        public MenuGroupService(IMenuGroupRepository menuGroupRepository, IUnitOfWork unitOfWork)
        {
            this._menuGroupRepository = menuGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public Result Add(MenuGroup menuGroup)
        {
            try
            {
                menuGroup.Active = true;
                menuGroup.CreateDate = DateTime.Now;
                _menuGroupRepository.Add(menuGroup);
                _unitOfWork.Commit();

                return new Result() { Status = true, ID = menuGroup.ID, Notication = "Thêm thành công" };

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
                _menuGroupRepository.Delete(id);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = 0, Notication = "Xóa thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _menuGroupRepository.GetAll();
        }

        public IEnumerable<MenuGroup> GetAllByActive(bool active)
        {
            return _menuGroupRepository.GetMulti(x => x.Active == active);
        }

        public MenuGroup GetById(int id)
        {
            return _menuGroupRepository.GetSingleById(id);
        }

        public MenuGroup GetByName(string name)
        {
            return _menuGroupRepository.GetSingleByCondition(x => x.Name == name);
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

        public Result Update(MenuGroup menuGroup)
        {
            try
            {
                menuGroup.UpdateDate = DateTime.Now;
                _menuGroupRepository.Update(menuGroup);
                _unitOfWork.Commit();
                return new Result() { Status = true, ID = menuGroup.ID, Notication = "Cập nhật thành công" };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, ID = 0, Notication = ex.Message };
            }
        }
    }
}
