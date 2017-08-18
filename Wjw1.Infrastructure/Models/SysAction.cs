using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wjw1.Infrastructure.Models
{
        /// <summary>
        /// Action
        /// </summary>
    public class SysAction : DbSetId, IUserDictionary
    {
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [MaxLength(40)]
        [Required]
        public string ActionName { get; set; }

        [MaxLength(50)]
        [Required]
        public string SystemId { get; set; } = "000";

        /// <summary>
        /// 系统默认Action标志
        /// 默认为false，非系统默认将自动加入到控制器上，其他需手动添加
        /// </summary>
        public bool System { get; set; } = false;

        [ScaffoldColumn(false)]
        public ICollection<SysControllerSysAction> SysControllerSysActions { get; set; }


        [ScaffoldColumn(false)]
        [NotMapped]
        public bool Selected { get; set; }

        public bool Enable { get; set; } = true;

    }
}