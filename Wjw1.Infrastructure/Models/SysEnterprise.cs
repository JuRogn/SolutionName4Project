using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Wjw1.Infrastructure.Models
{
    public class SysEnterprise : DbSetBase
    {

        [MaxLength(200)]
        [Required]

        public string EnterpriseName { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<SysEnterpriseSysUser> SysEnterpriseSysUsers { get; set; }
    }
}