﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class TipoEdicion
    {
        public int Id { get; set; }

        public string Descripcion{ get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
