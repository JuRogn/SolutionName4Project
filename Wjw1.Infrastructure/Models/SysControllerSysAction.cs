using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wjw1.Infrastructure.Models
{
    public class SysControllerSysAction: DbSetId
    {

        [ForeignKey("SysController")]
        [Required]
        public string SysControllerId { get; set; }

        public SysController SysController { get; set; }
     
        [ForeignKey("SysAction")]
        [Required]
        public string SysActionId { get; set; }

        public SysAction SysAction { get; set; }

        public ICollection<SysRoleSysControllerSysAction> SysRoleSysControllerSysActions { get; set; }
    }
}