using GD.Data.Infrastructure;
using GD.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Data.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
        //phuong thuc viet them ngoai phuong thuc RepositoryBase co san
        IEnumerable<Menu> GetListMenuByGroupId(int groupId);

        IEnumerable<Menu> GetListMenuByListGroupId(List<int> listId);
    }
    public class MenuRepository: RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public IEnumerable<Menu> GetListMenuByGroupId(int groupId)
        {
            var query = from g in DbContext.Menus
                        join ug in DbContext.ApplicationGroupMenus
                        on g.ID equals ug.MenuId
                        where ug.GroupId == groupId
                        select g;
            return query;
        }

        public IEnumerable<Menu> GetListMenuByListGroupId(List<int> listId)
        {

            var queryGetID = from g in DbContext.ApplicationGroupMenus
                             where listId.Contains(g.GroupId)
                             select g.MenuId;

            var query = from g in DbContext.Menus.Include("MenuGroup")
                        where queryGetID.ToList().Contains(g.ID)
                        select g;
      
            return query;
        }
    }
}
