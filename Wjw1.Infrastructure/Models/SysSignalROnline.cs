using System.ComponentModel.DataAnnotations;

namespace Wjw1.Infrastructure.Models
{
    public class SysSignalROnline:DbSetBase
    {
        [MaxLength(100)]
        public string ConnectionId { get; set; }

        [MaxLength(100)]
        public string GroupId { get; set; }
    }
}