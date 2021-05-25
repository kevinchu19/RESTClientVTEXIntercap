using Microsoft.EntityFrameworkCore;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using RESTClientIntercapVTEX.Models;

namespace RESTClientIntercapVTEX.Repositories
{
    public class ProductsSKURepository : RepositoryBase<Stmpdh>, IProductsSKURepository
    {
        public IConfigurationRoot Configuration { get; }
        public ProductsSKURepository(ApiIntercapContext context, IConfigurationRoot configuration) : base(context)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<Stmpdh>> GetProductForVTEX(CancellationToken cancellationToken)
        {
            return await Context.Set<Stmpdh>().FromSqlRaw("EXEC Alm_StmpdhProductGetForVTEX").ToListAsync();
        }

        //public async Task<IEnumerable<Stmpdh>> GetSKUForVTEX(CancellationToken cancellationToken)
        //{
        //    IEnumerable<Stmpdh> a = await Context.Set<Stmpdh>().FromSqlRaw("EXEC Alm_StmpdhSKUGetForVTEX").ToListAsync();
        //    return a;
        //}
        public async Task<IEnumerable<Stmpdh>> GetSKUForVTEX(CancellationToken cancellationToken)
        {
            List<Stmpdh> response = new List<Stmpdh>();


            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand($"ALM_StmpdhSKUGetForVTEX", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue<Stmpdh>(reader));
                        }
                    }
                }
            }

            return response;

        }

        public async Task<IEnumerable<InventoryDTO>> GetInventoryForVTEX(CancellationToken cancellationToken)
        {
            List<InventoryDTO> response = new List<InventoryDTO>();


            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand($"ALM_STRMVKGetForVTEX", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue<InventoryDTO>(reader));
                        }
                    }
                }
            }

            return response;
        }

        public async Task<IEnumerable<PricesDTO>> GetPricesForVTEX(CancellationToken cancellationToken)
        {
            List<PricesDTO> response = new List<PricesDTO>();


            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand($"ALM_STTPREGetForVTEX", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue<PricesDTO>(reader));
                        }
                    }
                }
            }

            return response;
        }

        private TResponse MapToValue<TResponse>(SqlDataReader reader)
        {
            var respuesta = (TResponse)Activator.CreateInstance(typeof(TResponse), new object[] { });
            Type typeResponse = typeof(TResponse);
            System.Reflection.PropertyInfo[] listaPropiedades = typeResponse.GetProperties();
            
            for (int i = 0; i < listaPropiedades.Count(); i++)
            {          
                if (reader[listaPropiedades[i].Name] != DBNull.Value)
                {
                    listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name]);
                }
            
            }

            return respuesta;
        }


    }
}
