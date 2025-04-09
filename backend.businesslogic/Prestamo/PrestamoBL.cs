using backend.businesslogic.Interfaces.Prestamo;
using backend.domain;
using backend.repository.Interfaces.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Prestamo
{
    public class PrestamoBL : IPrestamoBL
    {

        IPrestamoRepository repository;
        public PrestamoBL(IPrestamoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<SqlRspDTO> postInsPrestamo(PrestamoDTO prestamo)
        {
            return await repository.postInsPrestamo(prestamo);
        }

        public async Task<IList<PrestamoDTO>> getAllPrestamos()
        {
            return await repository.getAllPrestamos();
        }

        public async Task<IList<SelectDTO>> getLibros()
        {
            return await repository.getLibros();
        }

        public async Task<IList<SelectDTO>> getCopiaByLibro(int nIdLibro)
        {
            return await repository.getCopiaByLibro(nIdLibro);
        }

    }
}
