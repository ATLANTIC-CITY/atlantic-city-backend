using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBase
    {
        public readonly IPersonaBL service;
        public PersonaController(IPersonaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<int>>> validDocumentoUsuario(int nIdUsuario, string? sDNI, string? sCE, string? sRUC)
        {
            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.validDocumentoUsuario(nIdUsuario, sDNI, sCE, sRUC);

                response.success = true;
                response.data = result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }
    }
}
