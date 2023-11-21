
using Kike.Data.Oracle;
using Kike.Data.Oracle.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizacao.Desktop.Customizacao.Repositorio
{
    public class OracleContext : KikeOracleDataContext
    {
        private string connStr = "";

        #region CONFIGURACOES
        public OracleContext()
            : base("name=Contexto")
        {
        }

        public OracleContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<OracleContext>(null);
            this.connStr = connectionString;

            DbConfiguration.SetConfiguration(new KikeOracleDataContextConfiguration());
        }

        private void ConfigureModelBuilder(DbModelBuilder modelBuilder, string connectionstring)
        {
            modelBuilder.HasDefaultSchema(string.Empty);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureModelBuilder(modelBuilder, connStr);
        }
        #endregion
     
    }
}
