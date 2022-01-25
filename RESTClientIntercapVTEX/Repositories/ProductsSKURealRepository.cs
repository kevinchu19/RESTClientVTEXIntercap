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
    public class ProductsSKURealRepository : RepositoryBase<Stmpdh_Real>, IProductsSKURealRepository
    {
        public IConfigurationRoot Configuration { get; }

        public ProductsSKURealRepository(ApiIntercapContext context, IConfigurationRoot configuration) : base(context)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<Stmpdh_Real>> GetSkuForInventory (CancellationToken cancellationToken, int take) => await Context.Set<Stmpdh_Real>()
            .Where(c=> c.Usr_Vtex_Stktra != "S" && c.Usr_Stmpdh_IdSKUvtex != 0)
            .Take(take)
            .ToListAsync();

        public async Task<IEnumerable<Stmpdh_Real>> GetSkuForFiles(CancellationToken cancellationToken, int take) => await Context.Set<Stmpdh_Real>()
            .Where(c => c.Usr_Vtex_Imgtra != "S" && c.Usr_Stmpdh_IdSKUvtex != 0)
            .Take(take)
            .ToListAsync();

        public async Task MarcarStockTransferido(CancellationToken cancellationToken,string tippro, string artcod)
        {
            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand($"UPDATE STMPDH SET USR_VTEX_STKTRA = 'S' WHERE STMPDH_TIPPRO = '{tippro}' " +
                    $" AND STMPDH_ARTCOD = '{artcod}'", sql))
                {
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


    }
}
