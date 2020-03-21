using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Arquivo;

namespace VM2.Framework.DataLayer.Arquivo.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para Arquivo 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLArquivo : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLArquivo()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Alterar

        public bool Alterar(MLArquivo pobjMLArquivo)
        {
            throw new NotImplementedException();
        }
        #endregion

        # region Excluir
        public bool Excluir(decimal pdecCodigo)
        {
            throw new NotImplementedException();
        }
        # endregion

        #region Inserir
        public int Inserir(MLArquivo pobjMLArquivo)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Listar
        public List<MLArquivo> Listar(MLArquivo pobjMLArquivo)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Obter
        public MLArquivo Obter(decimal pdecCodigo)
        {
            throw new NotImplementedException();
        }
        # endregion
    }
}
