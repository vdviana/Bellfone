using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Mime;
using System.Timers;
using System.Web;
using Framework.AtendimentoOnline.DataLayer;
using Framework.AtendimentoOnline.Model;
using System;
using BellFone.B2B.BusinessLayer;
using BellFone.B2B.Model;

namespace Framework.AtendimentoOnline.BusinessLayer
{
    /// <summary>
    /// Classe para manipulação do assunto
    /// </summary>
    /// <author>vnarcizo</author>
    /// <createdDate>27/02/2009</createdDate>
    public class BLAtendente
    {
        #region Atributos Estaticos
        private static Timer tempoRespostaAtendente = new Timer();
        private static Hashtable objAtendentesDisponiveis = new Hashtable();
        #endregion

        #region Listar

        /// <summary>
        /// Listar assuntos
        /// </summary>
        /// <returns>ModelAssunto</returns>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public List<ModelAtendente> Listar()
        {
            DALAtendente objDALAtendente = new DALAtendente();

            return objDALAtendente.Listar();
        }

        #endregion

        #region Inserir
        /// <summary>
        ///  Inserir novo Atendente
        /// </summary>
        /// <param name="objModelAtendente">Model Atendente</param>
        /// <returns>Status da Inserção</returns>
        /// <user>vnarcizos</user>
        public bool Inserir(ModelAtendente objModelAtendente)
        {
            var objDALAtendente = new DALAtendente();

            return objDALAtendente.Inserir(objModelAtendente);
        }

        #endregion

        #region Alterar
        /// <summary>
        /// Altera os dados de um determinado registro
        /// </summary>
        /// <param name="objModelAssunto">Model para a alteração</param>
        /// <returns>Status da alteração</returns>
        /// <user>vnarcizo</user>
        public bool Alterar(ModelAtendente objModelAssunto)
        {
            var objDALAtendente = new DALAtendente();

            return objDALAtendente.Alterar(objModelAssunto);
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obtem um atendente a partir de um codigo
        /// </summary>
        /// <param name="CodigoRegistro">Codigo do atendente</param>
        /// <returns>Model de Atendente</returns>
        /// <user>vnarcizo</user>
        public ModelAtendente Obter(decimal? CodigoRegistro)
        {
            var objDALAtendente = new DALAtendente();

            return objDALAtendente.Obter(CodigoRegistro);
        }
        #endregion

        #region Atendentes Disponiveis
        /// <summary>
        /// Atendentes disponiveis
        /// </summary>
        /// <user>vnarcizo</user>
        public static Hashtable AtendentesDisponiveis
        {
            get
            {
                if (objAtendentesDisponiveis.Count == 0)
                {
                    tempoRespostaAtendente.Elapsed += tempoRespostaAtendente_Elapsed;
                    tempoRespostaAtendente.Interval = 2000;
                    tempoRespostaAtendente.Start();
                }

                return objAtendentesDisponiveis;
            }
        }
        #endregion

        #region Envento do Timer
        /// <summary>
        ///  Timer para verificar a existencia de algum atendente no atendimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <user>vnarcizo</user>
        protected static void tempoRespostaAtendente_Elapsed(object sender, ElapsedEventArgs e)
        {
            string itensRemover = string.Empty;

            int tempoRefresh = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.TempoEspera"]);

            foreach (DictionaryEntry item in objAtendentesDisponiveis)
            {
                if (DateTime.Now.Subtract((DateTime)item.Value).TotalSeconds > tempoRefresh)
                {
                    itensRemover += item.Key + ",";
                }
            }

            if (itensRemover.Length > 0)
            {
                itensRemover = itensRemover.Substring(0, itensRemover.Length - 1);

                foreach (string remover in itensRemover.Split(','))
                {
                    objAtendentesDisponiveis.Remove(remover);
                }
            }
        }
        #endregion



        #region Atendentes Disponiveis
        /// <summary>
        /// Verifica se os Atendentes disponiveis podem atender determinado Assunto e/ou Revendedor
        /// </summary>
        /// <param name="pstrCodAssunto">Codigo do Assunto</param>
        /// <param name="pstrCodrevendedor">Codigo do Revendedor</param>
        /// <returns>bool</returns>
        /// <user>lmascarenhas</user>
        public static bool VerificarAtendentes(string pstrCodAssunto, string pstrCodrevendedor)
        {

            bool objRetorno = false;
            BLAssunto objBLAssunto = new BLAssunto();
            ModelAssunto objAssunto = new ModelAssunto();
            BLPermissaoAtendimento objBLPermissaoAtendimento = new BLPermissaoAtendimento();
            List<MLPermissaoAtendimento> objPermissaoAtendimento = new List<MLPermissaoAtendimento>();

            objAssunto = objBLAssunto.Obter(Convert.ToDecimal(pstrCodAssunto));

            if (objAssunto != null && objAssunto.Vendas)
            {
                BLAtendente objBLAtendendente = new BLAtendente();
                objPermissaoAtendimento = objBLPermissaoAtendimento.Listar(new MLPermissaoAtendimento() { CodigoRevendedor = pstrCodrevendedor });
                foreach (MLPermissaoAtendimento permissao in objPermissaoAtendimento)
                {
                    if (objAtendentesDisponiveis.ContainsKey(permissao.Atdcodigo.ToString()))
                    {
                        return true;
                    }
                }
            }else
            {
                return true;
            }

            return objRetorno;
        }
        #endregion
    }

}
