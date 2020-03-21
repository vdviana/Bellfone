using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Usuario;
using VM2.Framework.DataLayer.Usuario;
using VM2.Framework.BusinessLayer.Utilitarios;

namespace VM2.Framework.BusinessLayer.Usuario
{

    /// <summary>
    ///     Classe de regra de negocio para permissao
    /// </summary>
    public class BLGrupoPermissao
    {

        #region Listar

        /// <summary>
        ///     Lista as Permissoes
        /// </summary>
        /// <param name="pobjParametro"></param>
        /// <returns>Lista de Permissao</returns>
        /// <user>mazevedo</user>
        public List<MLGrupoPermissao> Listar(MLGrupoPermissao pobjParametro)
        {

            Connector conGrupoPermissao = new Connector();

            IDLGrupoPermissao objDLPermissao = conGrupoPermissao.ObterDLGrupoPermissao();
            List<MLGrupoPermissao> colRetorno = null;

            try
            {
                colRetorno = objDLPermissao.Listar(pobjParametro);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupoPermissao.Finalizar();
            }
            return colRetorno;
        }

        #endregion

        #region Obter

        /// <summary>
        ///     Obtem uma permissao
        /// </summary>
        /// <param name="pdecCodigoGrupo">Codigo do Grupo</param>
        /// <param name="pdecCodigoFuncionalidade">Codigo da Funcionalidade</param>
        /// <returns>Permissao</returns>
        /// <user>mazevedo</user>
        public MLGrupoPermissao Obter(decimal pdecCodigoGrupo,
                                               decimal pdecCodigoFuncionalidade)
        {

            Connector conGrupoPermissao = new Connector();

            IDLGrupoPermissao objDLPermissao = conGrupoPermissao.ObterDLGrupoPermissao();
            MLGrupoPermissao objRetorno = null;

            try
            {
                objRetorno = objDLPermissao.Obter(pdecCodigoGrupo, pdecCodigoFuncionalidade);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupoPermissao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary>
        ///     Exclui um registro
        /// </summary>
        /// <param name="pdecCodigoGrupo">Código do Grupo</param>
        /// <param name="pdecCodigoFuncionalidade">Código da Funcionalidade</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigoGrupo, decimal pdecCodigoFuncionalidade)
        {

            Connector conGrupoPermissao = new Connector();

            IDLGrupoPermissao objDLPermissao = conGrupoPermissao.ObterDLGrupoPermissao();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLPermissao.Excluir(pdecCodigoGrupo, pdecCodigoFuncionalidade);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupoPermissao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir Todos

        /// <summary>
        ///     Exclui um registro
        /// </summary>
        /// <param name="pdecCodigoGrupo">Código do Grupo</param>
        /// <param name="pdecCodigoFuncionalidade">Código da Funcionalidade</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        private bool ExcluirTodos(decimal pdecCodigoFuncionalidade)
        {

            Connector conGrupoPermissao = new Connector();

            IDLGrupoPermissao objDLPermissao = conGrupoPermissao.ObterDLGrupoPermissao();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLPermissao.ExcluirTodos(pdecCodigoFuncionalidade);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupoPermissao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary>
        ///     Altera uma permissao
        /// </summary>
        /// <param name="pobjPermissao">Permissao com as alteracoes</param>
        /// <returns></returns>
        /// <user>mazevedo</user>
        public bool Alterar(MLGrupoPermissao pobjPermissao)
        {
            Connector conGrupoPermissao = new Connector();

            IDLGrupoPermissao objDLPermissao = conGrupoPermissao.ObterDLGrupoPermissao();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLPermissao.Alterar(pobjPermissao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupoPermissao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary>
        ///     Insere uma permissão
        /// </summary>
        /// <param name="pobjPermissao">Permissao para insercao</param>
        /// <returns>Resultado da Operacao</returns>
        /// <user>mazevedo</user>
        public bool Inserir(MLGrupoPermissao pobjPermissao)
        {

            Connector conGrupoPermissao = new Connector();

            IDLGrupoPermissao objDLPermissao = conGrupoPermissao.ObterDLGrupoPermissao();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLPermissao.Inserir(pobjPermissao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupoPermissao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir Lista

        /// <summary>
        ///     Insere uma lista de permissão
        /// </summary>
        /// <param name="pobjPermissao">Permissao para insercao</param>
        /// <returns>Resultado da Operacao</returns>
        /// <user>tprohaska</user>
        public void InserirLista(List<MLGrupoPermissao> plstPermissao)
        {

            Connector conGrupoPermissao = new Connector();

            IDLGrupoPermissao objDLPermissao = conGrupoPermissao.ObterDLGrupoPermissao();

            try
            {
                conGrupoPermissao.BeginTransaction();

                if (plstPermissao.Count > 0)
                {

                    this.ExcluirTodos(plstPermissao[0].CodigoFuncionalidade);

                    foreach (MLGrupoPermissao item in plstPermissao)
                    {
                        objDLPermissao.Inserir(item);
                    }
                }

                conGrupoPermissao.CommitTransaction();
            }
            catch (Exception ex)
            {
                conGrupoPermissao.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupoPermissao.Finalizar();
            }
        }

        #endregion
    }
}


