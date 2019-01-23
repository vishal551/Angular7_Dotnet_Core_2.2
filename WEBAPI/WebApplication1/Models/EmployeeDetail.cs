using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class EmployeeDetail
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string FullName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]

        public string EMPCode { get; set; }
        [Required]
        public Int32 Mobile { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]

        public string Position { get; set; }
    }
}
