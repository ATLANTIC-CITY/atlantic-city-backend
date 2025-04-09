using backend.domain;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IPersonaBL
    {
        Task<int> validDocumentoUsuario(int nIdUsuario, string? sDNI, string? sCE, string? sRUC);
    }
}
