using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;

namespace Wjw1.Infrastructure.Models
{


    // 可以通过向 ApplicationUser 类添加更多属性来为用户添加配置文件数据。若要了解详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=317594。
    public class SysUser : IdentityUser, IDbSetBase
    {
        public SysUser()
        {
            CreatedDate = DateTime.Now.ToDateString();
            CreatedTime = DateTime.Now.ToTimeString();
            Deleted = false;
        }


        [MaxLength(100)]
        public string FullName { get; set; }

        /// <summary>
        /// 头像URL
        /// </summary>
        [MaxLength(300)]
        public string Picture { get; set; }

        /// <summary>
        /// 添加日期
        /// </summary>
        [Editable(false)]
        [DataType(DataType.Date)]
        [MaxLength(50)]
        public string CreatedDate { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [Editable(false)]
        [DataType(DataType.Time)]
        [MaxLength(50)]
        public string CreatedTime { get; set; }

        [Editable(false)]
        [DataType(DataType.DateTime)]
        public string UpdatedDate { get; set; }

        [Editable(false)]
        [MaxLength(450)]
        public string CreatedBy { get; set; }

        [Editable(false)]
        [MaxLength(450)]
        public string UpdatedBy { get; set; }

        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }

        [MaxLength(450)]
        [ScaffoldColumn(false)]
        public string CurrentEnterpriseId { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<SysEnterpriseSysUser> SysEnterpriseSysUsers { get; set; } = new List<SysEnterpriseSysUser>();

        [ScaffoldColumn(false)]
        public ICollection<SysDepartmentSysUser> SysDepartmentSysUsers { get; set; } = new List<SysDepartmentSysUser>();


   
    }
    
}
