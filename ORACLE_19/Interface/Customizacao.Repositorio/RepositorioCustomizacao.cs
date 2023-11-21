using Consinco.Common.Windows.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizacao.Desktop.Customizacao.Repositorio
{
    public class RepositorioCustomizacao : RepositorioBase
    {
        private string connectionString;

        public RepositorioCustomizacao(string conexao) : base(conexao)
        {
            connectionString = conexao;

        }

    }
}
