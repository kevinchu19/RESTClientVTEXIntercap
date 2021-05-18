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
                            response.Add(MapToValue(reader));
                        }
                    }
                }
            }

            return response;

        }

        private Stmpdh MapToValue(SqlDataReader reader)
        {
            Stmpdh respuesta = (Stmpdh)Activator.CreateInstance(typeof(Stmpdh), new object[] { });
            Type typeResponse = typeof(Stmpdh);
            System.Reflection.PropertyInfo[] listaPropiedades = typeResponse.GetProperties();
            
            for (int i = 0; i < reader.FieldCount - 1; i++)
            {
                switch (listaPropiedades[i].Name)
                {
                    case "Activo":
                        listaPropiedades[i].SetValue(respuesta, (string)reader["DeBaja"] == "S" ? 0 : 1);
                        break;

                    default:
                       
                        if (reader[listaPropiedades[i].Name] != DBNull.Value)
                        {
                            listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name]);
                        }
                        break;
                }
            }

            return respuesta;
        }


    }
}
