using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Wjw1.Infrastructure.Models
{
  
    /// <summary>
    /// 系统帮助分类
    /// </summary>
    public class SysHelpClass : DbSetBase,IUserDictionary
    {
        public SysHelpClass()
        {

            SystemId = "000";
            Enable = true;
        }

        [MaxLength(40)]
        [Required]
        
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string SystemId { get; set; }

        public bool Enable { get; set; }


        [ScaffoldColumn(false)]
        [NotMapped]
        public bool Selected { get; set; }


        [ScaffoldColumn(false)]
        public ICollection<SysHelp> SysHelps { get; set; }
    }
}