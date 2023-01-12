using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseLEKSTIASPNETMVCSimplificado.Models
{
   
    public class Movimentations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Local { get; set; }
        public string EntryOrExit { get; set; }
        public string Commodities { get; set; }
    }
}
