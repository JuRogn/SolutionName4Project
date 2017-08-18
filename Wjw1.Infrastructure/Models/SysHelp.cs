using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Wjw1.Infrastructure.Models
{
  
    public class SysHelp : DbSetBase
    {
        public SysHelp()
        {
            Sort = 0;
        }


        [Required]
        [ForeignKey("SysHelpClass")]
        [DataType("SystemId")]
        [Display(Name = "Class")]
        public string SysHelpClassId { get; set; }


        [ScaffoldColumn(false)]
        public SysHelpClass SysHelpClass { get; set; }


        [MaxLength(100)]

        [Required]
        public string Title { get; set; }

        [MaxLength]
        [DataType(DataType.Html)]
        [Required]
    

        public string Content { get; set; }

        [Required]
        public int Sort { get; set; }

    }
}