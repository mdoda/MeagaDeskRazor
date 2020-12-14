using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor
{
    public class DesktopMaterial
    {
        public int DesktopMaterialId { get; set; }//PK

        public string MaterialName { get; set; }
        
        public decimal MaterialPrice{ get; set; }
       
    }
}
