using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.repository.Interfaces.Prestamos;

namespace backend.repository.Prestamos
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly IConfiguration _configuration;

        public PrestamoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlRspDTO> postInsPrestamo(PrestamoDTO prestamo)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnDatabase")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[prestamo].[pa_prestamo]", 1);
                parameters.Add("nIdCliente", prestamo.nIdCliente);
                parameters.Add("dFechaPrestamo", prestamo.dFechaPrestamo);
                parameters.Add("sEstado", prestamo.sEstado);
                parameters.Add("nIdCopia", prestamo.nIdCopia);
                parameters.Add("nIdTransaccion", prestamo.nIdTransaccion);
                parameters.Add("nIdUsuarioCrea", prestamo.nIdUsuarioCrea);


                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<PrestamoDTO>> getAllPrestamos()
        {
            IEnumerable<PrestamoDTO> list = new List<PrestamoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnDatabase")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[prestamo].[pa_prestamo]", 2);

                list = await connection.QueryAsync<PrestamoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }


        public async Task<IList<SelectDTO>> getLibros()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnDatabase")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[libro].[pa_libro_disponibles]", 1);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getCopiaByLibro(int nIdLibro)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnDatabase")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[libro].[pa_libro_disponibles]", 2);
                parameters.Add("nIdLibro", nIdLibro);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


    }
}
