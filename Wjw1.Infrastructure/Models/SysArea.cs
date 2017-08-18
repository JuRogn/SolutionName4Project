using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wjw1.Infrastructure.Models
{

    public class SysArea : DbSetId, IUserDictionary
    {
        public SysArea()
        {
            SystemId = "000";
            Enable = true;
        }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [MaxLength(40)]
        [Required]
        public string AreaName { get; set; }

        [MaxLength(30)]
        [Required]
        public string SystemId { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<SysController> SysControllers { get; set; }


        [ScaffoldColumn(false)]
        [NotMapped]
        public bool Selected { get; set; }

        public bool Enable { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}