using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class PrestamoDTO
    {
        public int? nIdPrestamo { get; set; }
        public int nIdCliente { get; set; }
        public string? sClienteNombre { get; set; }
        public string? sTituloLibro { get; set; }
        public DateTime dFechaPrestamo { get; set; }
        public DateTime? dFechaDevolucion { get; set; }
        public string sEstado { get; set; }
        public string? sCodigoBarras { get; set; }
        public int nPrecioAlquiler { get; set; }
        public int nIdCopia { get; set; }
        public int? nIdTransaccion { get; set; }
        public int nIdUsuarioCrea { get; set; }
    }


}
