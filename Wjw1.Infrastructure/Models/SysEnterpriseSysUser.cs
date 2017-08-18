using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wjw1.Infrastructure.Models
{
    public class SysEnterpriseSysUser
    {
        public SysEnterpriseSysUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [MaxLength(450)]
        public string Id { get; set; }
        

        [ForeignKey("SysEnterprise")]
        [Required]
        public string SysEnterpriseId { get; set; }
        [ScaffoldColumn(false)]
        public SysEnterprise SysEnterprise { get; set; }

     
        [ForeignKey("SysUser")]
        [Required]
        public string SysUserId { get; set; }
        [ScaffoldColumn(false)]
        public SysUser SysUser { get; set; }

    }
}