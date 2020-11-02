using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Service.Common;

namespace Tasker.Service.Models
{
    public class TimeEntry : Entity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime TimeSpent { get; set; }
        //[Required]
        [MaxLength(1500)]
        public string Description { get; set; }
    }
}
