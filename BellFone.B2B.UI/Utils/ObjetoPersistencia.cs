using System;

namespace BellFone.B2B.UI.Utils
{
    [Serializable]
    public class PersistenciaTO
    {
        public string idCategoria { get; set; }
        public string idProduto { get; set; }
        public int PaginaAtual { get; set; }
    }

    [Serializable]
    public class PaginacaoTO
    {
        public int PaginaAtual { get; set; }
        public int UltimaPagina { get; set; }
        public int TotalPaginas { get; set; }
    }
}