using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MegaDeskRazor
{
  
    public class Desk
    {
        public int DeskId { get; set; } 
        public decimal Depth { get; set; }

        public decimal Width { get; set; }

        [Display(Name = "Number of Drawers")]
        public int NumberOfDrawers { get; set; }

        public int DesktopMaterialId { get; set; }//FK
        public DesktopMaterial DesktopMaterial { get; set; }

    }
}
