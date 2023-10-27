using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreateDate { set; get; } = DateTime.Now;
        [MaxLength(256)]
        public string CreateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        [MaxLength(256)]
        public string UpdateBy { set; get; }
        public DateTime? ActiveDate { set; get; }
        [MaxLength(256)]
        public string ActiveBy { set; get; }
        public bool Active { set; get; } = true;
        public DateTime? ApproveDate { set; get; }
        [MaxLength(256)]
        public string ApproveBy { set; get; }
        public int? Approve { set; get; }
        public int? ApproveLevel { set; get; }

    }
}
