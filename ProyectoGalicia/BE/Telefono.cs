using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGalicia.Models
{
    public class Telefono
    {
        public string ID_DIRECCION { get; set; }
        public string ID_PERSONA { get; set; }
        public string TI_TELEFONO { get; set; }
        public string TXT_NRO_TEL { get; set; }
        public string TXT_INTERNO_TEL { get; set; }
        public string NRO_ORD_PRIORIDAD { get; set; }
        public string MA_CONTACTAR { get; set; }
        public string COD_USO_DIR_PERS { get; set; }
        public string COD_USO_DIR_BCO { get; set; }
    }
}
