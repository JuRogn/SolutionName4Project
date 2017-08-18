using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wjw1.Infrastructure.Models
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class SysController : DbSetId, IUserDictionary
    {

        /// <summary>
        ///Area
        /// </summary>
        [Required]
        [ForeignKey("SysArea")]
        [Display(Name = "Area")]
        public string SysAreaId { get; set; } = "000";

        [ScaffoldColumn(false)]
        public SysArea SysArea { get; set; }

        /// <summary>
        /// 显示名称 
        /// 舍弃：将使用翻译系统生成控制器显示名称 T["ControllerName"]
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 控制器名称
        /// 控制器"ControllerNameController"的名称为"ControllerName"
        /// </summary>
        [MaxLength(50)]
        public string ControllerName { get; set; } = "Index";

        /// <summary>
        /// 菜单关联的Action
        /// 默认为"Index"
        /// </summary>
        [MaxLength(50)]
        public string ActionName { get; set; } = "Index";

        /// <summary>
        /// 菜单传入的参数
        /// 默认为空
        /// </summary>
        [MaxLength(50)]
        public string Parameter { get; set; } = "";

        /// <summary>
        /// 系统编号
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string SystemId { get; set; } = "000";

        /// <summary>
        /// 菜单显示标志
        /// 默认为True
        /// </summary>
        public bool Display { get; set; } = true;

        /// <summary>
        /// 是否在新窗口打开
        /// </summary>
        public bool TargetBlank { get; set; } = false;

        /// <summary>
        /// 菜单显示图标
        /// </summary>
        [DataType("Ico")]
        public string Ico { get; set; } = "fa-list-ul";

        /// <summary>
        /// Actions
        /// </summary>
        [Display(Name = "Action")]
        public IEnumerable<SysControllerSysAction> SysControllerSysActions { get; set; }

        /// <summary>
        /// 是否选中标志
        /// 权限编辑使用
        /// </summary>
        [ScaffoldColumn(false)]
        [NotMapped]
        public bool Selected { get; set; }
        /// <summary>
        /// 启用标志
        /// 默认启用
        /// </summary>

        public bool Enable { get; set; } = true;
    }
}