using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Prestamos
{
    public interface IPrestamoRepository
    {
        Task<SqlRspDTO> postInsPrestamo(PrestamoDTO prestamo);
        Task<IList<PrestamoDTO>> getAllPrestamos();
        Task<IList<SelectDTO>> getLibros();
        Task<IList<SelectDTO>> getCopiaByLibro(int nIdLibro);
    }
}
