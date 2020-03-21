using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.IO;
using System.Configuration;
using System.Web;
using BellFone.B2B.BusinessLayer.Configuration;
using BellFone.B2B.Model;
using System.Net;
using BellFone.B2B.BusinessLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Reflection;
using VM2.Framework.BusinessLayer.Usuario;

namespace BellFone.B2B.BusinessLayer
{
    public class BLIntegracao
    {
        private static List<String> listRetorno = new List<string>();
        private static bool boolIntegrou = false;
        private static List<String> listArquivos = new List<string>();
       


        #region Importar

        /// <summary>
        /// Localiza os aquivos do prefixo informado
        /// </summary>
        /// <user>efranca</user>
        public static void Importar()
        {
            var strPrefixo = "";
            var objRetorno = new List<string>();
            
            try
            {
                var dirInfo = new DirectoryInfo(UTIntegracao.ObterCaminhoRecebimento());
                var allFiles = dirInfo.GetFiles("*.txt");

                var listThread = new List<Thread>();

                ThreadPool.SetMaxThreads(1, 1);
                
                foreach (var fileTxt in allFiles)
                {
                    strPrefixo = fileTxt.Name.Substring(0, 3);

                    if (strPrefixo == MLIntegracao.Prefixo.VEN.ToString())
                    {
                        //Vendedor(fileTxt);
                        ThreadPool.QueueUserWorkItem(Vendedor, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.REV.ToString())
                    {
                        //Revendedor(fileTxt);
                        ThreadPool.QueueUserWorkItem(Revendedor, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.CAT.ToString())
                    {
                        //Categoria(fileTxt);
                        ThreadPool.QueueUserWorkItem(Categoria, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.GRU.ToString())
                    {
                        //Grupo(fileTxt);
                        ThreadPool.QueueUserWorkItem(Grupo, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.SGR.ToString())
                    {
                        //Subgrupo(fileTxt);
                        ThreadPool.QueueUserWorkItem(Subgrupo, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.FAB.ToString())
                    {
                        //Fabricante(fileTxt);
                        ThreadPool.QueueUserWorkItem(Fabricante, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.EFI.ToString())
                    {
                        //ExtratoFinanceiro(fileTxt);
                        ThreadPool.QueueUserWorkItem(ExtratoFinanceiro, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.FFI.ToString())
                    {
                        //FichaFinanceira(fileTxt);
                        ThreadPool.QueueUserWorkItem(FichaFinanceira, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.SIO.ToString())
                    {
                        //StatusItemOrcamento(fileTxt);
                        ThreadPool.QueueUserWorkItem(StatusItemOrcamento, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.ORC.ToString())
                    {
                        //Orcamento(fileTxt);
                        ThreadPool.QueueUserWorkItem(Orcamento, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.IOR.ToString())
                    {
                        //OrcamentoItem(fileTxt);
                        ThreadPool.QueueUserWorkItem(OrcamentoItem, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.TPN.ToString())
                    {
                        //TipoNegocio(fileTxt);
                        ThreadPool.QueueUserWorkItem(TipoNegocio, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.REG.ToString())
                    {
                        //Regiao(fileTxt);
                        ThreadPool.QueueUserWorkItem(Regiao, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.PRO.ToString())
                    {
                        //Produto(fileTxt);
                        ThreadPool.QueueUserWorkItem(Produto, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.PAT.ToString())
                    {
                        //PermissaoAtendimento(fileTxt);
                        ThreadPool.QueueUserWorkItem(PermissaoAtendimento, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.UNM.ToString())
                    {
                        //UnidadeMedida(fileTxt);
                        ThreadPool.QueueUserWorkItem(UnidadeMedida, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.CPG.ToString())
                    {
                        //CondicaoPagamento(fileTxt);
                        ThreadPool.QueueUserWorkItem(CondicaoPagamento, fileTxt);
                    }
                    else if (strPrefixo == MLIntegracao.Prefixo.FPA.ToString())
                    {
                        //FormaPagamento(fileTxt);
                        ThreadPool.QueueUserWorkItem(FormaPagamento, fileTxt);
                    }
                }
                
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodBase.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                //EnviaEmail(null);
                ThreadPool.QueueUserWorkItem(EnviaEmail);                
                ThreadPool.QueueUserWorkItem(ApagarImportadosComSucesso);

            }
        }

        #endregion

        #region Exportar

        /// <summary>
        /// Localiza os aquivos do prefixo informado
        /// </summary>
        /// <user>tprohaska</user>
        public static void Exportar()
        {
            BLIntegracao.ExportarOrcamentos();
            BLIntegracao.ExportarAcessos();
        }

        public static void ExportarAcessos()
        {
            try
            {
                String strLinha = "";

                //Arquivo de envio do Orçamento
                BLAcesso blAcesso = new BLAcesso();
                List<MLAcesso> listMLAcesso = new List<MLAcesso>();
                MLAcesso objMLAcesso = new MLAcesso();

                listMLAcesso = blAcesso.ListarRelatorio(objMLAcesso);

                foreach (var acesso in listMLAcesso)
                {
                    MLOrcamento objMLOrcamento = new MLOrcamento();
                    strLinha += objMLAcesso.FromArquivoIntegracaoExportar(acesso);
                }
                if (!String.IsNullOrEmpty(strLinha))
                {
                    CriarArquivo(strLinha, MLIntegracao.Prefixo.ACC.ToString() + DateTime.Now.ToString("dd-MM-yyyy"));
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ExportarOrcamentos()
        {
            try
            {
                String strLinha = "", strLinhaItem = "";

                //Arquivo de envio do Orçamento
                BLOrcamento blOrcamento = new BLOrcamento();
                List<MLOrcamento> listMLOrcamento = new List<MLOrcamento>();
                MLOrcamento objMLOrcamento = new MLOrcamento();

                objMLOrcamento.Origem = "web";
                objMLOrcamento.IsStatusMigracao = false;

                listMLOrcamento = blOrcamento.Listar(objMLOrcamento);

                foreach (var orcamento in listMLOrcamento)
                {
                    //listagem dos itens
                    BLOrcamentoItem blOrcamentoItem = new BLOrcamentoItem();
                    List<MLOrcamentoItem> listMLOrcamentoItem = new List<MLOrcamentoItem>();
                    MLOrcamentoItem objMLOrcamentoItem = new MLOrcamentoItem();

                    objMLOrcamentoItem.Origem = "web";
                    objMLOrcamentoItem.IsStatusMigracao = false;
                    objMLOrcamentoItem.CodigoOrcamento = orcamento.Codigo;

                    listMLOrcamentoItem = blOrcamentoItem.Listar(objMLOrcamentoItem);
                    orcamento.ValorToral = listMLOrcamentoItem.Sum(t => (t.PrecoSugerido * t.Quantidade)).Value;
                    orcamento.NumeroItens = listMLOrcamentoItem.Sum(t => t.Quantidade).Value;

                    List<MLOrcamento> orcamentoAtual = new List<MLOrcamento>();
                    orcamentoAtual.Add(orcamento);
                    strLinha = objMLOrcamento.FromArquivoIntegracaoExportar(orcamentoAtual);

                    if (!String.IsNullOrEmpty(strLinha))
                    {
                        CriarArquivo(strLinha, MLIntegracao.Prefixo.ORC.ToString() + orcamento.Codigo.ToString().PadLeft(5));
                    }

                    strLinhaItem = objMLOrcamentoItem.FromArquivoIntegracaoExportar(listMLOrcamentoItem);

                    if (!String.IsNullOrEmpty(strLinhaItem))
                    {
                        CriarArquivo(strLinhaItem, MLIntegracao.Prefixo.IOR.ToString() + orcamento.Codigo.ToString().PadLeft(5));

                        String corpo = "Existem arquivos de exportação";

                        //VM2.Framework.BusinessLayer.Utilitarios.BLEmail.EnviarEmail(UTEmail.ObterEmailAdmin(), "Log da Interação - Exportação", corpo);

                        AlterarParaMigrado(listMLOrcamento, listMLOrcamentoItem);
                    }
                }

                //Arquivo de envio do Item de Orçamento
                /*strLinha = "";
                BLOrcamentoItem blOrcamentoItem = new BLOrcamentoItem();
                List<MLOrcamentoItem> listMLOrcamentoItem = new List<MLOrcamentoItem>();
                MLOrcamentoItem objMLOrcamentoItem = new MLOrcamentoItem();

                objMLOrcamentoItem.Origem = "web";
                objMLOrcamentoItem.IsStatusMigracao = false;

                listMLOrcamentoItem = blOrcamentoItem.Listar(objMLOrcamentoItem);

                strLinha = objMLOrcamentoItem.FromArquivoIntegracaoExportar(listMLOrcamentoItem);*/
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Recebe os dados e cria o arquivo de exportação

        /// <summary>
        /// Localiza os aquivos do prefixo informado
        /// </summary>
        /// <user>tprohaska</user>
        private static void CriarArquivo(String pstrLinha, String pstrPrefixo)
        {
            try
            {
                //String strNomeArquivo = pstrPrefixo + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + ".txt";
                String strNomeArquivo = pstrPrefixo + ".txt";
                
                FileInfo aFile = new FileInfo(UTIntegracao.ObterCaminhoEnvio() + "/" + strNomeArquivo);

                StreamWriter sw = new StreamWriter(aFile.FullName, false, System.Text.Encoding.GetEncoding("ISO-8859-1"));

                sw.Write(pstrLinha);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Importações
        
        #region Vendedor
        /// <summary>
        /// Vendedor
        /// </summary>
        /// <user>efranca</user>
        private static void Vendedor(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;
                
                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var objRetornoVendedor = new List<string>();
                    var blVendedor = new BLVendedor();
                    var objMLVendedor = new MLVendedor();
                    
                    var listMLVendedor = objMLVendedor.FromArquivoIntegracao(strArquivo, ref objRetornoVendedor);

                    boolIntegrou = blVendedor.Importacao(listMLVendedor, out objRetornoVendedor);

                    listRetorno.Add("Arquivo Vendedor:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoVendedor);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Revendedor
        /// <summary>
        /// Revendedor
        /// </summary>
        /// <user>efranca</user>
        private static void Revendedor(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var objRetornoRevendedor = new List<string>();
                    var blRevendedor = new BLRevendedor();
                    var objMLRevendedor = new MLRevendedor();
                    
                    var listMLVendedor = objMLRevendedor.FromArquivoIntegracao(strArquivo, ref objRetornoRevendedor);

                    boolIntegrou = blRevendedor.Importacao(listMLVendedor, out objRetornoRevendedor);

                    listRetorno.Add("Arquivo Revendedor:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoRevendedor);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Categoria
        /// <summary>
        /// Categoria 
        /// </summary>
        /// <user>efranca</user>
        private static void Categoria(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var objRetornoCategoria = new List<string>();
                    var blCategoria = new BLCategoria();
                    var objMLCategoria = new MLCategoria();
                    
                    var listMLVendedor = objMLCategoria.FromArquivoIntegracao(strArquivo, ref objRetornoCategoria);

                    boolIntegrou = blCategoria.Importacao(listMLVendedor, out objRetornoCategoria);

                    listRetorno.Add("Arquivo Categoria:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoCategoria);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Grupo
        /// <summary>
        /// Grupo
        /// </summary>
        /// <user>efranca</user>
        private static void Grupo(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var objRetornoGrupo = new List<string>();
                    var blGrupo = new BLGrupo();
                    var objMLGrupo = new MLGrupo();
                    
                    var listMLVendedor = objMLGrupo.FromArquivoIntegracao(strArquivo, ref objRetornoGrupo);

                    boolIntegrou = blGrupo.Importacao(listMLVendedor, out objRetornoGrupo);

                    listRetorno.Add("Arquivo Grupo:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoGrupo);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Subgrupo
        /// <summary>
        /// Subgrupo 
        /// </summary>
        /// <user>efranca</user>
        private static void Subgrupo(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var objRetornoSubgrupo = new List<string>();
                    var blSubgrupo = new BLSubgrupo();
                    var objMLSubgrupo = new MLSubgrupo();
                    
                    var listMLVendedor = objMLSubgrupo.FromArquivoIntegracao(strArquivo, ref objRetornoSubgrupo);

                    boolIntegrou = blSubgrupo.Importacao(listMLVendedor, out objRetornoSubgrupo);

                    listRetorno.Add("Arquivo Subgrupo:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoSubgrupo);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Fabricante
        /// <summary>
        /// Fabricante
        /// </summary>
        /// <user>efranca</user>
        private static void Fabricante(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoFabricante = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blFabricante = new BLFabricante();
                    var objMLFabricante = new MLFabricante();
                    
                    var listMLVendedor = objMLFabricante.FromArquivoIntegracao(strArquivo, ref objRetornoFabricante);

                    boolIntegrou = blFabricante.Importacao(listMLVendedor, out objRetornoFabricante);

                    listRetorno.Add("Arquivo Fabricante:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoFabricante);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region ExtratoFinanceiro
        /// <summary>
        /// ExtratoFinanceiro
        /// </summary>
        /// <user>efranca</user>
        private static void ExtratoFinanceiro(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var objRetornoExtratoFinanceiro = new List<string>();
                    var blExtratoFinanceiro = new BLExtratoFinanceiro();
                    var objMLExtratoFinanceiro = new MLExtratoFinanceiro();
                    
                    var listMLVendedor = objMLExtratoFinanceiro.FromArquivoIntegracao(strArquivo, ref objRetornoExtratoFinanceiro);

                    boolIntegrou = blExtratoFinanceiro.Importacao(listMLVendedor, out objRetornoExtratoFinanceiro);

                    listRetorno.Add("Arquivo ExtratoFinanceiro:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoExtratoFinanceiro);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region FichaFinanceira
        /// <summary>
        /// FichaFinanceira
        /// </summary>
        /// <user>efranca</user>
        private static void FichaFinanceira(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoFichaFinanceira = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blFichaFinanceira = new BLFichaFinanceira();
                    var objMLFichaFinanceira = new MLFichaFinanceira();
                    

                    var listMLFichaFinanceira = objMLFichaFinanceira.FromArquivoIntegracao(strArquivo, ref objRetornoFichaFinanceira);

                    boolIntegrou = blFichaFinanceira.Importacao(listMLFichaFinanceira, out objRetornoFichaFinanceira);

                    listRetorno.Add("Arquivo FichaFinanceira:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoFichaFinanceira);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Orcamento
        /// <summary>
        /// Orcamento
        /// </summary>
        /// <user>efranca</user>
        private static void Orcamento(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var blOrcamento = new BLOrcamento();
                    var objMLOrcamento = new MLOrcamento();
                    var objRetornoOrcamento = new List<string>();
                    

                    var listMLVendedor = objMLOrcamento.FromArquivoIntegracao(strArquivo, ref objRetornoOrcamento);

                    boolIntegrou = blOrcamento.Importacao(listMLVendedor, out objRetornoOrcamento);

                    listRetorno.Add("Arquivo Orcamento:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoOrcamento);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region OrcamentoItem
        /// <summary>
        /// OrcamentoItem
        /// </summary>
        /// <user>efranca</user>
        private static void OrcamentoItem(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var blOrcamentoItem = new BLOrcamentoItem();
                    var objMLOrcamentoItem = new MLOrcamentoItem();
                    var objRetornoOrcamentoItem = new List<string>();
                    

                    var listMLVendedor = objMLOrcamentoItem.FromArquivoIntegracao(strArquivo, ref objRetornoOrcamentoItem);

                    boolIntegrou = blOrcamentoItem.Importacao(listMLVendedor, out objRetornoOrcamentoItem);

                    listRetorno.Add("Arquivo OrcamentoItem:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoOrcamentoItem);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region TipoNegocio
        /// <summary>
        /// TipoNegocio
        /// </summary>
        /// <user>efranca</user>
        private static void TipoNegocio(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var blTipoNegocio = new BLTipoNegocio();
                    var objMLTipoNegocio = new MLTipoNegocio();
                    var objRetornoTipoNegocio = new List<string>();
                    
                    var listMLVendedor = objMLTipoNegocio.FromArquivoIntegracao(strArquivo, ref objRetornoTipoNegocio);

                    boolIntegrou = blTipoNegocio.Importacao(listMLVendedor, out objRetornoTipoNegocio);

                    listRetorno.Add("Arquivo TipoNegocio:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoTipoNegocio);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Produto
        /// <summary>
        /// Produto
        /// </summary>
        /// <user>efranca</user>
        private static void Produto(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var strArquivo = sr.ReadToEnd();
                    var blProduto = new BLProduto();
                    var objMLProduto = new MLProduto();
                    var objRetornoProduto = new List<string>();
                    
                    var listMLVendedor = objMLProduto.FromArquivoIntegracao(strArquivo, ref objRetornoProduto);

                    boolIntegrou = blProduto.Importacao(listMLVendedor, out objRetornoProduto);

                    listRetorno.Add("Arquivo Produto:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoProduto);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region PermissaoAtendimento
        /// <summary>
        /// PermissaoAtendimento
        /// </summary>
        /// <user>efranca</user>
        private static void PermissaoAtendimento(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoPermissaoAtendimento = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blPermissaoAtendimento = new BLPermissaoAtendimento();
                    var objMLPermissaoAtendimento = new MLPermissaoAtendimento();
                    
                    var listMLVendedor = objMLPermissaoAtendimento.FromArquivoIntegracao(strArquivo, ref objRetornoPermissaoAtendimento);

                    boolIntegrou = blPermissaoAtendimento.Importacao(listMLVendedor, out objRetornoPermissaoAtendimento);

                    listRetorno.Add("Arquivo Permissao Atendimento:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoPermissaoAtendimento);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Regiao
        /// <summary>
        /// Região
        /// </summary>
        /// <user>efranca</user>
        private static void Regiao(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoRegiao = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blRegiao = new BLRegiao();
                    var objMLRegiao = new MLRegiao();
                    
                    var listMLRegiao = objMLRegiao.FromArquivoIntegracao(strArquivo, ref objRetornoRegiao);

                    boolIntegrou = blRegiao.Importacao(listMLRegiao, out objRetornoRegiao);

                    listRetorno.Add("Arquivo Regiao:" + fileTxt.Name);
                    listRetorno.AddRange(objRetornoRegiao);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region UnidadeMedida
        /// <summary>
        /// UnidadeMedida
        /// </summary>
        /// <user>efranca</user>
        private static void UnidadeMedida(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoUnidadeMedida = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blUnidadeMedida = new BLUnidadeMedida();
                    var objMLUnidadeMedida = new MLUnidadeMedida();
                    
                    var listMLVendedor = objMLUnidadeMedida.FromArquivoIntegracao(strArquivo, ref objRetornoUnidadeMedida);

                    boolIntegrou = blUnidadeMedida.Importacao(listMLVendedor, out objRetornoUnidadeMedida);

                    listRetorno.Add("Arquivo Unidade Medida:" + fileTxt.Name);
                    listRetorno.AddRange(objRetornoUnidadeMedida);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region CondicaoPagamento
        /// <summary>
        /// CondicaoPagamento
        /// </summary>
        /// <user>efranca</user>
        private static void CondicaoPagamento(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoCondicaoPagamento = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blCondicaoPagamento = new BLCondicaoPagamento();
                    var objMLCondicaoPagamento = new MLCondicaoPagamento();
                   
                    var listMLVendedor = objMLCondicaoPagamento.FromArquivoIntegracao(strArquivo, ref objRetornoCondicaoPagamento);

                    boolIntegrou = blCondicaoPagamento.Importacao(listMLVendedor, out objRetornoCondicaoPagamento);

                    listRetorno.Add("Arquivo Condicao Pagamento:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoCondicaoPagamento);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region FormaPagamento
        /// <summary>
        /// FormaPagamento
        /// </summary>
        /// <user>efranca</user>
        private static void FormaPagamento(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoFormaPagamento = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blFormaPagamento = new BLFormaPagamento();
                    var objMLFormaPagamento = new MLFormaPagamento();
                    
                    var listMLVendedor = objMLFormaPagamento.FromArquivoIntegracao(strArquivo, ref objRetornoFormaPagamento);

                    boolIntegrou = blFormaPagamento.Importacao(listMLVendedor, out objRetornoFormaPagamento);

                    listRetorno.Add("Arquivo Forma Pagamento:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoFormaPagamento);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region FormaPagamento
        /// <summary>
        /// FormaPagamento
        /// </summary>
        /// <user>efranca</user>
        private static void StatusItemOrcamento(Object pFileTxt)
        {
            try
            {
                var fileTxt = (FileInfo)pFileTxt;

                using (var sr = new StreamReader(fileTxt.FullName, System.Text.Encoding.GetEncoding("ISO-8859-1")))
                {
                    var objRetornoStatusItemOrcamento = new List<string>();
                    var strArquivo = sr.ReadToEnd();
                    var blStatusItemOrcamento = new BLStatusItemOrcamento();
                    var objMLStatusItemOrcamento = new MLStatusItemOrcamento();
                    
                    var listMLVendedor = objMLStatusItemOrcamento.FromArquivoIntegracao(strArquivo, ref objRetornoStatusItemOrcamento);

                    boolIntegrou = blStatusItemOrcamento.Importacao(listMLVendedor, out objRetornoStatusItemOrcamento);

                    listRetorno.Add("Arquivo Forma Pagamento:" + fileTxt.Name);

                    listRetorno.AddRange(objRetornoStatusItemOrcamento);

                    if (boolIntegrou)
                    {
                        listArquivos.Add(fileTxt.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #endregion

        #region Envia Email
        /// <summary>
        /// Envia Email
        /// </summary>
        /// <user>efranca</user>
        private static void EnviaEmail(Object pFileTxt)
        {
            try
            {               

                int intcompletos;
                int inttotal;

                ThreadPool.GetAvailableThreads(out inttotal, out intcompletos);

                int intcompletosA;
                int inttotalB;

                ThreadPool.GetMaxThreads(out inttotalB, out intcompletosA);

                while (intcompletos != intcompletosA)
                {
                    Thread.Sleep(1000);
                    ThreadPool.GetAvailableThreads(out inttotal, out intcompletos);
                }

                if (listRetorno.Count != 0)
                {
                    var corpo = "";

                    foreach (string item in listRetorno)
                    {
                        corpo += item + "\r\n";
                    }

                    corpo = corpo.Replace("\r\n", "<br/>");

                    BLEmail.EnviarEmail(UTEmail.ObterEmailAdmin(), "Log da Interação - Importação", corpo);

                    BLFuncoes.GravaLog(corpo);

                    listRetorno.Clear();
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Apaga arquivos que importaram com sucesso
        /// <summary>
        /// ApagarImportadosComSucesso
        /// </summary>
        /// <user>efranca</user>
        private static void ApagarImportadosComSucesso(Object pFileTxt)
        {
            try
            {
                int intcompletos;
                int inttotal;

                ThreadPool.GetAvailableThreads(out inttotal, out intcompletos);

                int intcompletosA;
                int inttotalB;

                ThreadPool.GetMaxThreads(out inttotalB, out intcompletosA);

                while (intcompletos != intcompletosA)
                {
                    Thread.Sleep(1000);
                    ThreadPool.GetAvailableThreads(out inttotal, out intcompletos);
                }

                var dirInfo = new DirectoryInfo(UTIntegracao.ObterCaminhoRecebimento());
                var allFiles = dirInfo.GetFiles("*.txt");

                foreach (var files in allFiles)
                {
                    if (listArquivos.Contains(files.Name))
                    {
                        files.Delete();
                    }
                }

                listArquivos.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region Altera o status do orçamento para Migrado

        /// <summary>
        /// Altera o status do orçamento para Migrado
        /// </summary>
        /// <user>tprohaska</user>
        private static void AlterarParaMigrado(List<MLOrcamento> listMLOrcamento, List<MLOrcamentoItem> listMLOrcamentoItem)
        {
            try
            {
                BLOrcamento objBLOrcamento = new BLOrcamento();
                BLOrcamentoItem objBLOrcamentoItem = new BLOrcamentoItem();

                foreach (var objMLOrcamento in listMLOrcamento)
                {
                    objMLOrcamento.IsStatusMigracao = true;

                    objBLOrcamento.Alterar(objMLOrcamento);
                }
                foreach (var objMLOrcamentoItem in listMLOrcamentoItem)
                {
                    objMLOrcamentoItem.IsStatusMigracao = true;

                    objBLOrcamentoItem.Alterar(objMLOrcamentoItem);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        #endregion

        #region VERIFICA SE TEM IMAGEM DO PRODUTO NO FTP

        /// <summary>
        /// VERIFICA SE TEM IMAGEM DO PRODUTO NO FTP
        /// </summary>
        /// <user>tprohaska</user>
        public static void VerificaImagem(string strCaminho)
        {
            try
            {
                var intValor = 0;
                var objUsuario = BLUsuario.ObterLogado();
                List<MLProduto> ListMLProduto = new BLProduto().Listar(new MLProduto(), null);

                foreach (var objMLProduto in ListMLProduto)
                {
                    if (int.TryParse(objMLProduto.Codigo, out intValor))
                    {
                        var url = strCaminho + Convert.ToInt32(objMLProduto.Codigo).ToString() + ".jpg";
                        
                        objMLProduto.TemImagem = File.Exists(url);

                        new BLProduto().Alterar(objMLProduto);                     
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
