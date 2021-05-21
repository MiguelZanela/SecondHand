using Entities.Interfaces;
using Entities.Models;
using PL.DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BusinesFacade
    {
        private readonly IProdutoDAO _dao;

        //construtor busines facade
        /*
        public BusinesFacade()
        {
            _dao = new ProdutoEF();
        }*/

        
        public BusinesFacade(IProdutoDAO dao)
        {
            _dao = dao;
        }
        

        #region consultas em produtos

        //Todos os produtos do banco:
        public List<Produto> ListaDeProdutos()
        {
            return _dao.ListaDeProdutos();
        }

        //Salva um produto novo no banco
        public void CadNovoProduto(Produto prod)
        {
            _dao.CadastroNovoProduto(prod);
        }

        //relatorio de itens por uma determinada categoria
        public List<Produto> ItensPorCategoria(String cat)
        {
            return _dao.ItensPorCategoria(cat);
        }

        //relatorio de itens por uma determinada categoria e palavra
        public List<Produto> ItensPalChavCat(String palChave, String cat)
        {
            return _dao.ItensPalChavCat(palChave, cat);
        }

        //relatorio de itens por uma determinada faixa de valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin)
        {
            return _dao.ItensFaixaDeValores(valIni, valFin);
        }

        //relatorio de itens por um determinado usuario
        public List<Produto> ItensPorStatusUsu(String usu)
        {
            return _dao.ItensPorStatusUsu(usu);
        }

        ////relatorio do total de vendas em um determinado periodo de tempo
        public List<String> TotalVendaPeriodo(DateTime dtIni, DateTime dtFin)
        {
            return _dao.NroTotalVendaPeriodo(dtIni, dtFin);
        }
        #endregion

    }
}
