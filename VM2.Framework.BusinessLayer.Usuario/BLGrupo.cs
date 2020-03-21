using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VM2.Framework.Model.Usuario;
using VM2.Framework.DataLayer.Usuario;
using VM2.Framework.BusinessLayer.Utilitarios;

namespace VM2.Framework.BusinessLayer.Usuario
{
    
    /// <summary>
    ///     Classe de regras de negócio para Grupo
    /// </summary>
    /// <user>mazevedo</user>
    public class BLGrupo
    {

        #region Listar

        /// <summary>
        ///     Lista todos os grupos
        /// </summary>
        /// <param name="pobjGrupo">Filtros</param>
        /// <returns>Lista de grupos</returns>
        /// <user>mazevedo</user>
        public List<MLGrupo> Listar(MLGrupo pobjGrupo)
        {

            Connector conGrupo = new Connector();

            IDLGrupo objDLGrupo = conGrupo.ObterDLGrupo();
            List<MLGrupo> colRetorno = null;

            try
            {
                colRetorno = objDLGrupo.Listar(pobjGrupo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupo.Finalizar();
            }
            return colRetorno;
        }

        #endregion

        #region Obter

        /// <summary>
        ///     Retorna um grupo especifico
        /// </summary>
        /// <param name="pdecCodigo">Codigo do grupo</param>
        /// <returns>Grupo</returns>
        /// <user>mazevedo</user>
        public MLGrupo Obter(decimal pdecCodigo)
        {

            Connector conGrupo = new Connector();

            IDLGrupo objDLGrupo = conGrupo.ObterDLGrupo();
            MLGrupo objRetorno = null;

            try
            {
                objRetorno = objDLGrupo.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary>
        ///     Exclui um grupo
        /// </summary>
        /// <param name="pdecCodigo">Codigo do grupo</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conGrupo = new Connector();

            IDLGrupo objDLGrupo = conGrupo.ObterDLGrupo();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLGrupo.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary>
        ///     Altera um grupo
        /// </summary>
        /// <param name="pobjMLGrupo">Grupo a ser alterado</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool Alterar(MLGrupo pobjMLGrupo)
        {

            Connector conGrupo = new Connector();

            IDLGrupo objDLGrupo = conGrupo.ObterDLGrupo();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLGrupo.Alterar(pobjMLGrupo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary>
        ///     Insere um grupo
        /// </summary>
        /// <param name="pobjMLGrupo">Grupo a ser inserido</param>
        /// <returns>Codigo do grupo</returns>
        public int Inserir(MLGrupo pobjMLGrupo)
        {

            Connector conGrupo = new Connector();

            IDLGrupo objDLGrupo = conGrupo.ObterDLGrupo();
            int objRetorno = 0;

            try
            {
                objRetorno = objDLGrupo.Inserir(pobjMLGrupo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conGrupo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Operacoes de Validacao

        #region Validar Membro

        /// <summary>
        ///     Valida se o usuário logado pertence aos grupos informados
        /// </summary>
        /// <param name="plstCodigoGrupo">Lista de grupos</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public static bool VerificarAssociacaoLogado(List<decimal> plstCodigoGrupo)
        {
            bool blnRetorno = false;

            MLUsuarioGrupo objUsuarioLogado = (MLUsuarioGrupo)BLUsuario.ObterLogado();

            foreach (decimal decCodigoGrupo in plstCodigoGrupo)
            {
                if (objUsuarioLogado != null && objUsuarioLogado.ListaGrupo.Contains(decCodigoGrupo))
                {
                    blnRetorno = true;
                }
            }


            return blnRetorno;
        }

        #endregion

        #endregion

    }
}


