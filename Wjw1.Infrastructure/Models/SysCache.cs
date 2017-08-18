using System;
using System.ComponentModel.DataAnnotations;

namespace Wjw1.Infrastructure.Models
{

    public class SysCache 
    {
       
        [Key]
        [ScaffoldColumn(false)]
        [Required]
        [MaxLength(449)]
        public string Id { get; set; }

        [Required]
        public byte[] Value { get; set; }

        [Required]
        public DateTimeOffset ExpiresAtTime { get; set; }

        public long? SlidingExpirationInSeconds { get; set; }

        public DateTimeOffset? AbsoluteExpiration { get; set; }
    }
}