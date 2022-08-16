using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class Disco
    {

        //CREO MI CLASE BASE, QUE ME VA A DAR EL FORMATO DE MI APLICACION-------------
        public string Titulo { get; set; }

        public int CantidadCanciones { get; set; }

        public string UrlImagenTapa { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public Estilos Tipo { get; set; }

        public TipoEdicion Edicion { get; set; }


    }
}
