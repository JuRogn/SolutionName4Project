using Wjw1.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace  Wjw1.Infrastructure
{
    public interface IDbSetBase
    {
        string Id { get; set; }

        string CreatedDate { get; set; }

        string CreatedTime { get; set; }

        string UpdatedDate { get; set; }

        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        bool Deleted { get; set; }
    }

    /// <summary>
    /// 企业关联 
    /// </summary>
    public interface IEnterprise
    {
        [MaxLength(450)]
        string EnterpriseId { get; set; }
    }

    /// <summary>
    /// 基础主键
    /// </summary>
    public abstract class DbSetId
    {
        protected DbSetId()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [MaxLength(450)]
        public string Id { get; set; }
    }

    /// <summary>
    /// 企业关联基础表
    /// </summary>
    public abstract class DbSetBase : DbSetId, IDbSetBase, IEnterprise
    {
        protected DbSetBase()
        {
            //CreatedDate = DateTime.UtcNow.ToDateAdd8hString(); 
            CreatedDate = DateTime.Now.ToDateString();
            //CreatedTime = DateTime.UtcNow.ToTimeAdd8hString();
            CreatedTime = DateTime.Now.ToTimeString();
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        [ScaffoldColumn(false)]
        [MaxLength(20)]
        [Required]
        public string CreatedDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ScaffoldColumn(false)]
        [MaxLength(16)]
        [Required]
        public string CreatedTime { get; set; }

        public string CreateDateTime => CreatedDate + " " + CreatedTime;

        /// <summary>
        /// 创建人
        /// </summary>

        [ScaffoldColumn(false)]
        [MaxLength(450)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Editable(false)]
        [ForeignKey("CreatedBy")]
        public SysUser UserCreatedBy { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        [Editable(false)]
        [MaxLength(50)]
        public string UpdatedDate { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [ScaffoldColumn(false)]
        [MaxLength(450)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Editable(false)]
        [ForeignKey("UpdatedBy")]
        public SysUser UserUpdatedBy { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Description = "Remark_Description")]
        public string Remark { get; set; }

        /// <summary>
        /// 记录标记删除
        /// </summary>
        [ScaffoldColumn(false)]
        public bool Deleted { get; set; }

        /// <summary>
        /// 数据所在企业ID
        /// </summary>
        [MaxLength(450)]
        [ScaffoldColumn(false)]

        public string EnterpriseId { get; set; }
    }
}
