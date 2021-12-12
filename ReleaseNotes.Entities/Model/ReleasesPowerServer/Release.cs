using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNotes.Entities.Model.ReleasesPowerServer
{
    public class Release
    {
        [Key]
        public long ReleaseId { get; set; }
        [Required]
        public string VersionNumber { get; set; }
        [Required]
        public IEnumerable<Module> Modules { get; set; }
    }
}
