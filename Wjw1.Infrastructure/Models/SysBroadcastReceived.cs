using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wjw1.Infrastructure.Models
{
    public class SysBroadcastReceived : DbSetBase//DbSetEnterpriseBase
    {
        [MaxLength(450)]
        [Required]
        [ForeignKey("SysBroadcast")]
        public string SysBroadcastId { get; set; }

        public SysBroadcast SysBroadcast { get; set; }
    }
}
