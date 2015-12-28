using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace NeoTokyo.ProductionBook.DAL
{
    public class ProductionBookConfiguration : DbConfiguration
    {
        public ProductionBookConfiguration()
        {
            SetExecutionStrategy("System.Data,SqlClient", ()=> new SqlAzureExecutionStrategy());
        }
    }
}