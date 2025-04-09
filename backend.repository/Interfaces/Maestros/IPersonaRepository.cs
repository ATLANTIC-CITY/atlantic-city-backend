using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface IPersonaRepository
    {
        Task<int> validDocumentoUsuario(int nIdUsuario, string? sDNI, string? sCE, string? sRUC);
    }
}
