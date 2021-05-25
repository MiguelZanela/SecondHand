using Entities.Interfaces;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using PL.DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BusinesFacade
    {
        private readonly IProdutoDAO _ProdutoDAO;
        private readonly IImagemDAO _ImagemDAO;
        private readonly IApplicationUserDAO _ApplicationUserDAO;

        //construtor busines facade

        public BusinesFacade(IProdutoDAO Pdao, IImagemDAO Idao, IApplicationUserDAO Adao)
        {
            _ProdutoDAO = Pdao;
            _ImagemDAO = Idao;
            _ApplicationUserDAO = Adao;
        }
        

        #region consultas em produtos

        //Todos os produtos do banco:
        public List<Produto> ListaDeProdutos()
        {
            return _ProdutoDAO.ListaDeProdutos();
        }

        //Salva um produto novo no banco
        public void CadNovoProduto(Produto prod)
        {
            _ProdutoDAO.CadastroNovoProduto(prod);
        }

        //Recebe um ID de produto e retorna o mesmo
        public Produto ItemPorId(long ProdutoID)
        {
            return _ProdutoDAO.ItemPorId(ProdutoID);
        }

        //relatorio de itens por uma determinada categoria
        public List<Produto> ItensPorCategoria(String cat)
        {
            return _ProdutoDAO.ItensPorCategoria(cat);
        }

        //relatorio de itens por uma determinada categoria e palavra
        public List<Produto> ItensPalChavCat(String palChave, String cat)
        {
            return _ProdutoDAO.ItensPalChavCat(palChave, cat);
        }

        //relatorio de itens por uma determinada faixa de valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin)
        {
            return _ProdutoDAO.ItensFaixaDeValores(valIni, valFin);
        }

        //relatorio de itens por um determinado usuario
        public List<Produto> ItensPorStatusUsu(String usu)
        {
            return _ProdutoDAO.ItensPorStatusUsu(usu);
        }

        ////relatorio do total de vendas em um determinado periodo de tempo
        public List<TotalVendaPorPeriodo> TotalVendaPeriodo(DateTime dtIni, DateTime dtFin)
        {
            return _ProdutoDAO.NroTotalVendaPeriodo(dtIni, dtFin);
        }
        #endregion

        #region consultas em imagem

        //Salva uma imagens novo no banco
        public void CadImagem(long ProdutoId, List<IFormFile> files)
        {
            _ImagemDAO.LoadFiles(ProdutoId,files);
        }

        //recebe um id de imagem e retorna o resultado
        public Imagem GetImagem(int ImagemId)
        {
            return _ImagemDAO.GetImagem(ImagemId);
        }

        #endregion

        #region consultas em application user

        //retorna o id de um usuario
        public String getUserID(String userName)
        {
            return _ApplicationUserDAO.getUserID(userName);
        }

        #endregion

    }
}
