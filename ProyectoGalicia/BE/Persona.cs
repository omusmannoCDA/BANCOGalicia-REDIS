using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGalicia.Models
{
    public class Persona
    {
        public string id { get; set; }
        public string COD_TI_PERS { get; set; }
        public string COD_NAT_JURIDICA { get; set; }
        public string TI_IDEN_TRIBUTARIA { get; set; }
        public string NRO_IDEN_TRIBUTARI { get; set; }
        public string TI_DOCUMENTO { get; set; }
        public string NRO_DOCUMENTO { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ApellidoCasada { get; set; }
        //public string TXT_RAZON_SOCIAL { get; set; }
        //
        public string COD_SEXO { get; set; }

        public string COD_NACIONALIDAD { get; set; }
        public string FE_NACIMIENTO { get; set; }
        public string COD_PAIS_NAC { get; set; }
        public string COD_EST_CIVIL { get; set; }
        public string COD_PROFESION { get; set; }
        public string COD_SIT_LAB { get; set; }
        public string COD_ACTIV_PPAL { get; set; }
        public string COD_REL_VIVIENDA { get; set; }
        public string COD_COND_IMPOS_GAN { get; set; }
        public string COD_COND_IMPOS_IVA { get; set; }
        public string COD_COND_IMPOS_IBR { get; set; }
        public string COD_JURISD_IBR { get; set; }
        public string COD_EMPLEADO_BGBA { get; set; }
        public string COD_ACTIV_AFIP { get; set; }
        public string COD_ACTIV_SEC { get; set; }
        public string COD_NIVEL_ESTUDIO { get; set; }
        public string FE_INICIO_LABORAL { get; set; }
        public string COD_ACTIV_MONOT { get; set; }
        public string COD_CATEG_MONOT { get; set; }
        public string MA_ACRED_HABERES { get; set; }
        public string COD_PAUTA_ING { get; set; }
        public string COD_CARGO { get; set; }
        public string CANT_PERS_A_CARGO { get; set; }
        public string COD_MOD_ATENCION { get; set; }
        public string MA_TARJ_NARANJA { get; set; }
        public string MA_TARJ_NEVADA { get; set; }
        public string MA_PERS_FAMOSA { get; set; }
        public string COD_SUC_MADRE { get; set; }
        public string COD_SEGMENTO { get; set; }
        public string FE_TRAMITE_AUTONOM { get; set; }
        public string MA_PROVEEDOR { get; set; }
        public string TI_PERSONA { get; set; }
        public string COD_SECTOR_CONTAB { get; set; }
        public string FE_ALTA_PERS { get; set; }
        public string MA_PEP { get; set; }
        public string COD_PRIVATE_BANKING { get; set; }
        public string TXT_CANDADO { get; set; }

    }
}
