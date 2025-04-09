using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Prestamo
{
    public interface IPrestamoBL
    {
        Task<SqlRspDTO> postInsPrestamo(PrestamoDTO prestamo);
        Task<IList<PrestamoDTO>> getAllPrestamos();
        Task<IList<SelectDTO>> getLibros();
        Task<IList<SelectDTO>> getCopiaByLibro(int nIdTipoUsuario);
    }
}
