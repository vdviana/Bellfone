using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.DataLayer.Utilitarios;
using VM2.Framework.Model.Utilitarios;

namespace VM2.Framework.BusinessLayer.Utilitarios
{
    
    /// <summary>
    ///     Classe de negócio para log
    /// </summary>
    /// <user>mazevedo</user>
    public class BLLog
    {

        #region Listar

        /// <summary>
        ///     Lista os logs
        /// </summary>
        /// <param name="pobjParametro">Parametros para filtro</param>
        /// <returns>Lista de Logs</returns>
        /// <user>mazevedo</user>
        public List<MLLog> Listar(MLLog pobjParametro)
        {
            Connector conLog = new Connector();

            IDLLog objDLLog = conLog.ObterDLLog();
            List<MLLog> colRetorno = null;

            try
            {
                colRetorno = objDLLog.Listar(pobjParametro);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conLog.Finalizar();
            }
            return colRetorno;
        }

        #endregion

        #region Inserir

        /// <summary>
        ///     Insere um log
        /// </summary>
        /// <param name="pobjLog">Log a ser inserido</param>
        /// <returns>Codigo do log</returns>
        /// <user>mazevedo</user>
        public int Inserir(MLLog pobjLog)
        {

            Connector conLog = new Connector();

            IDLLog objDLLog = conLog.ObterDLLog();
            int objRetorno = 0;

            try
            {
                objRetorno = objDLLog.Inserir(pobjLog);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conLog.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


