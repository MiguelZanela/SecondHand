using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IProdutoDAO
    {
        //Todos os produtos do banco:
        public List<Produto> ListaDeProdutos();

        //Salva um produto novo no banco
        public void CadastroNovoProduto(Produto prod);

        //relatorio de itens por uma determinada categoria
        public List<Produto> ItensPorCategoria(String cat);

        //relatorio de itens por uma determinada categoria e palavra
        public List<Produto> ItensPalChavCat(String palChave, String cat);

        //relatorio de itens por uma determinada faixa de valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin);

        //relatorio de itens por Status do produto de um determinado usuario
        public List<Produto> ItensPorStatusUsu(long usu);

        ////relatorio do total de vendas em um determinado periodo de tempo
        public List<String> NroTotalVendaPeriodo(DateTime dtIni, DateTime dtFin);

    }
}
