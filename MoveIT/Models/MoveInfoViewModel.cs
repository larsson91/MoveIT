using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoveIT.Models
{
    public class MoveInfoViewModel
    {
        [Display(Name = "Offertnummer")]
        public int OffNo { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Display(Name = "Adressen du flyttar från")]
        public string MoveFrom { get; set; }

        [Display(Name = "Adressen du flyttar till")]
        public string MoveTo { get; set; }

        [Display(Name = "Avstånd mellan bostäderna (km)")]
        public  int Distance { get; set; }

        [Display(Name = "Storlek (kvm)")]
        public int MainArea { get; set; }

        [Display(Name = "Vind/Källare (kvm)")]
        public int ExtraArea { get; set; }

        [Display(Name = "Piano")]
        public bool Piano { get; set; }

        [Display(Name = "Packhjälp")]
        public bool HelpPacking { get; set; }
    }
}