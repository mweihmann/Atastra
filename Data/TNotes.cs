using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atastra.Data
{
    public class TNotes
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(400)]
        public string Summary { get; set; }
        [Required]
        [StringLength(100)]
        public string TNotePrio { get; set; }
        [StringLength(100)]
        public string Assignee { get; set; }
        [Required]
        [StringLength(100)]
        public string TNoteStatus { get; set; }
    }
}
