using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Models
{
    public class Commodity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberRecord { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string type { get; set; }

        public Commodity() { }
    }
}

