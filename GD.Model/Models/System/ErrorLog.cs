using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GD.Model.Abstract;

namespace GD.Model.Models
{
    [Table("ErrorLogs")]
    public class ErrorLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [MaxLength(4000)]
        public string Message { set; get; }

        [MaxLength(4000)]
        public string StackTrace { set; get; }

        [MaxLength(4000)]
        public string Description { get; set; }
        
        public DateTime CreateDate { get; set; }
    }
}
