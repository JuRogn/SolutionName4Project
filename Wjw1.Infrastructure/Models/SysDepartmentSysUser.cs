using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wjw1.Infrastructure.Models
{
    public class SysDepartmentSysUser
    {
        public SysDepartmentSysUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [MaxLength(450)]
        public string Id { get; set; }

        [ForeignKey("SysDepartment")]
        [Required]
        public string SysDepartmentId { get; set; }

        public SysDepartment SysDepartment { get; set; }
     
        [ForeignKey("SysUser")]
        [Required]
        public string SysUserId { get; set; }

        public SysUser SysUser { get; set; }

  
    }
}