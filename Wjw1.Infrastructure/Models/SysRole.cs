using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wjw1.Infrastructure.Models
{
    public class SysRole : IdentityRole, IEnterprise
    {
        [MaxLength(100)]
        [Required]
        public string RoleName { get; set; }

        /// <summary>
        /// 系统定义角色标志,默认值false，系统设计的角色，业务强相关
        /// 新建企业时需要复制的角色
        /// 自定义的角色为非系统角色
        /// </summary>
        public bool System { get; set; } = false;
        

        [MaxLength(50)]
        [Required]
        public string SystemId { get; set; } = "100";

        [ScaffoldColumn(false)]
        public ICollection<SysRoleSysControllerSysAction> SysRoleSysControllerSysActions { get; set; }// = new List<SysRoleSysControllerSysAction>();

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string EnterpriseId { get; set; }
    }
}