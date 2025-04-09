using backend.businesslogic.Interfaces.Prestamo;
using backend.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.services.Controllers.Prestamos
{
    [Route("api/[controller]")]
    [ApiController]

    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoBL service;

        public PrestamoController(IConfiguration _configuration, IPrestamoBL _service)
        {
            service = _service;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsPrestamo([FromBody] PrestamoDTO prestamo)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.postInsPrestamo(prestamo);

                response.success = result.nCod == 0 ? false : true;
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

        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse<List<PrestamoDTO>>>> getAllPrestamos()
        {
            ApiResponse<List<PrestamoDTO>> response = new ApiResponse<List<PrestamoDTO>>();

            try
            {
                var result = await service.getAllPrestamos();

                response.success = true;
                response.data = (List<PrestamoDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("listarLibro")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getLibros()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getLibros();

                response.success = true;
                response.data = (List<SelectDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("listarCopia")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getCopiaByLibro([FromQuery] int nIdLibro)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getCopiaByLibro(nIdLibro);

                response.success = true;
                response.data = (List<SelectDTO>)result;
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
