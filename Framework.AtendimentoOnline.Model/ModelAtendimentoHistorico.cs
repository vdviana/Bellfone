using System;

namespace Framework.AtendimentoOnline.Model
{
    public class ModelAtendimentoHistorico : IComparable<ModelAtendimentoHistorico>
    {
        #region Propriedades

        /// <summary>
        ///  Nome Atendente
        /// </summary>
        /// <user>vnarcizo</user>
        public string NomeAtendente { get; set; }

        /// <summary>
        ///  Nome Cliente
        /// </summary>
        /// <user>vnarcizo</user>
        public string NomeCliente { get; set; }

        /// <summary>
        ///  Data Atendimento
        /// </summary>
        /// <user>vnarcizo</user>
        public DateTime? DataInicio { get; set; }

        /// <summary>
        ///  Data Atendimento
        /// </summary>
        /// <user>vnarcizo</user>
        public DateTime? DataFim { get; set; }

        /// <summary>
        ///  Data Atendimento
        /// </summary>
        /// <user>vnarcizo</user>
        public DateTime DataAtendimento { get; set; }

        /// <summary>
        ///  Codigo Assunto
        /// </summary>
        /// <user>vnarcizo</user>
        public string Assunto { get; set; }

        /// <summary>
        ///  Guid Atendimento
        /// </summary>
        /// <user>vnarcizo</user>
        public string GuidAtendimento{ get; set; }

        #endregion

        #region Compare To

        /// <summary>
        /// Método para o Sort
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <user>vnarcizo</user>
        public int CompareTo(ModelAtendimentoHistorico other)
        {
            return other.DataAtendimento.CompareTo(DataAtendimento);
        }

        #endregion
    }
}
