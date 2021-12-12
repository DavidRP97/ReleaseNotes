using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNotes.Entities.Model.ReleasesPowerServer
{
    public class Module
    {
        [Key]
        public long ModuleId { get; set; }
        [Required]
        [StringLength(50)]
        public string ModuleName { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Notes { get; set; }
        [ForeignKey("ReleaseId")]
        public virtual Release Release { get; set; }
        public long ReleaseId { get; set; }
    }
}
