using backend.domain;
using backend.repository.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Maestros;

namespace backend.businesslogic.Maestros
{
    public class PersonaBL : IPersonaBL
    {
        IPersonaRepository repository;
        public PersonaBL(IPersonaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int> validDocumentoUsuario(int nIdUsuario, string? sDNI, string? sCE, string? sRUC)
        {
            return await repository.validDocumentoUsuario(nIdUsuario, sDNI, sCE, sRUC);
        }
    }
}
