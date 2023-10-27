using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreateDate { set; get; }
        string CreateBy { set; get; }
        DateTime? UpdateDate { set; get; }
        string UpdateBy { set; get; } 
        DateTime? ActiveDate { set; get; }
        string ActiveBy { set; get; }
        bool Active { set; get; }
        DateTime? ApproveDate { set; get; }
        string ApproveBy { set; get; }
        int? Approve { set; get; }
        int? ApproveLevel { set; get; }
    }
}
