using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Menu;

namespace VM2.Framework.DataLayer.Menu
{

    /// <summary>
    ///     Interface com os metodos relacionados as operacoes realizadas com a base de dados
    /// </summary>
    /// <user>mazevedo</user>
    public interface IDLMenuItem
    {

        List<MLMenuItem> Listar(MLMenuItem pobjMLMenuItem);
        MLMenuItem Obter(decimal pdecCodigo);
        bool Excluir(String pstrCodigoItens);
        bool Alterar(MLMenuItem pobjMLMenuItem);
        int Inserir(MLMenuItem pobjMLMenuItem);
        void AlterarOrdem(decimal pdecCodigoOrigem, decimal? pdecCodigoDestino, decimal pdecCodigoPaiDestino);
        List<MLMenuItem> ListarPais(decimal pdecCodigo);
        List<MLMenuItem> ListarFilhos(decimal pdecCodigo);

    }
}
