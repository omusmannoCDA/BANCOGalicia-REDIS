using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGalicia.Models
{
    public class Mail
    {

        public string ID_DIRECCION { get; set; }
        public string ID_PERSONA { get; set; }
        public string COD_TI_DIRECCION { get; set; }
        public string TXT_E_MAIL_USU { get; set; }
        public string TXT_E_MAIL_NODO { get; set; }
        public string PORC_NIVEL_CONFIAB { get; set; }
        public string NRO_ORD_PRIORIDAD { get; set; }
    }
}
