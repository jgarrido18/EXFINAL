﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXFIN.Models
{
    public class CatedraticosActClass
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Dpi { get; set; }

        public String Activo { get; set; }

        public catedratico getCATEDRATICO { get; set; }

        public CURSO getcurso { get; set; }
    }
}