using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Framework.AtendimentoOnline.Model.Exceptions;

namespace Framework.AtendimentoOnline.Model
{
    public class ModelFilaAtendimento
    {
        /// <summary>
        /// HashTable com as conversas categorizadas por assuntos.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28-01-2009</dateCreated>
        Hashtable hstAssuntos = new Hashtable();
        
        /// <summary>
        /// Gerar espera para atendimento.
        /// </summary>
        /// <returns>GUID do atendimento em espera.</returns>
        /// <author>vnarcizo</author>
        /// <dateCreated>28-01-2009</dateCreated>
        public string GerarEsperaAtendimento(string pstrNomeCliente,
                                                string pstrEmailCliente,
                                                int pintCodigoAssunto,
                                                string pstrCodigoRevendedor)
        {
            Queue<ModelConversa> objQueue;

            if (!hstAssuntos.Contains(pintCodigoAssunto.ToString()))
            {
                objQueue = new Queue<ModelConversa>();
                hstAssuntos.Add(pintCodigoAssunto.ToString(), objQueue);
            }
            else
            {
                objQueue = hstAssuntos[pintCodigoAssunto.ToString()] as Queue<ModelConversa>;
            }

            var pstrGUIDAtendimento = Guid.NewGuid().ToString();

            var objModeConversa = new ModelConversa(pstrGUIDAtendimento, pintCodigoAssunto, pstrNomeCliente, pstrEmailCliente, pstrCodigoRevendedor);

            if (objQueue != null) 
                objQueue.Enqueue(objModeConversa);

            return pstrGUIDAtendimento;
        }


        /// <summary>
        /// Fila de Atendimento
        /// </summary>
        public static ModelFilaAtendimento FilaAtendimento
        {
            get
            {
                ModelFilaAtendimento objFilaAtendimento ;

                if (HttpContext.Current.Cache["filaAtendimento"] == null)
                {
                    objFilaAtendimento = new ModelFilaAtendimento();
                    HttpContext.Current.Cache["filaAtendimento"] = objFilaAtendimento;
                }
                else
                {
                    objFilaAtendimento = HttpContext.Current.Cache["filaAtendimento"] as ModelFilaAtendimento;
                }

                return objFilaAtendimento;
            }
        }
        
        /// <summary>
        /// Fila de Atendimento
        /// </summary>
        public static Hashtable AtendimentoEmAndamento
        {
            get
            {
                Hashtable table;
                if (HttpContext.Current.Cache["AtendimentoEmAndamento"] == null)
                {
                    table = new Hashtable();
                    HttpContext.Current.Cache["AtendimentoEmAndamento"] = table;
                }
                else
                {
                    table = HttpContext.Current.Cache["AtendimentoEmAndamento"] as Hashtable;
                }

                return table;
            }
        }

        /// <summary>
        /// Busca a posição.
        /// </summary>
        /// <param name="pstrGUIDAtendimento">GUID do atendimento.</param>
        /// <param name="pintCodigoAssunto">Codigo assunto.</param>
        /// <returns>Posição do atendente na fila.</returns>
        /// <author>vnarcizo</author>
        /// <dateCreated>29-01-2009</dateCreated>
        public int PosicaoFila(string pstrGUIDAtendimento, int pintCodigoAssunto)
        {
            if (!hstAssuntos.Contains(pintCodigoAssunto.ToString()))
            {
                throw new GUIDAtendimentoInvalido("GUID de atendimento inválido.", null);
            }

            int intPosicao = 0;
            int intCount = 0;

            if (hstAssuntos.ContainsKey(pintCodigoAssunto.ToString()))
            {
                Queue<ModelConversa> objQueue = hstAssuntos[pintCodigoAssunto.ToString()] as Queue<ModelConversa>;

                Queue<ModelConversa>.Enumerator objEnumerator = objQueue.GetEnumerator();

               

                lock (objQueue)
                {

                    while (objEnumerator.MoveNext())
                    {

                        if (objEnumerator.Current.GUID == pstrGUIDAtendimento)
                        {
                            objEnumerator.Current.DataRequisicao = DateTime.Now;
                            break;
                        }
                        intPosicao++;
                        intCount++;
                    }

                    if (objQueue.Count == intCount)
                    {
                        intPosicao = 0;
                    }

                }
            }
            return intPosicao;
        }

        /// <summary>
        /// Busca a posição.
        /// </summary>
        /// <returns>Posição do atendente na fila.</returns>
        /// <author>vnarcizo</author>
        /// <dateCreated>29-01-2009</dateCreated>
        public Hashtable AssuntoQuantidadeNaFila()
        {
            var objtableAux = new Hashtable();

            foreach (DictionaryEntry item in FilaAtendimento.hstAssuntos)
            {
               

                objtableAux.Add(item.Key,
                                ((Queue<ModelConversa>)item.Value).Count);
                
            }//TODO FERNANDO MASCARENHAS

            return objtableAux;
        }

        /// <summary>
        /// Fila
        /// </summary>
        /// <returns>Posição do atendente na fila.</returns>
        /// <author>vnarcizo</author>
        /// <dateCreated>29-01-2009</dateCreated>
        public Hashtable Filas { get { return hstAssuntos; }}
    }
}
