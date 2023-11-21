using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizacao.Desktop.Customizacao.Servico
{
   public class ServicoCustomizacao
    {
        private Repositorio.RepositorioCustomizacao repositorioCustomizacao;

        public ServicoCustomizacao(string conexao)
        {
            repositorioCustomizacao = new Repositorio.RepositorioCustomizacao(conexao);
        }
    }
}
