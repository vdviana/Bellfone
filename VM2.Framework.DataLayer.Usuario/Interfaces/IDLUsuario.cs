using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Usuario;

namespace VM2.Framework.DataLayer.Usuario
{

    /// <summary>
    ///     Interface com os metodos relacionados as operacoes realizadas com a base de dados
    /// </summary>
    /// <user>mazevedo</user>
    public interface IDLUsuario
    {

        List<MLUsuario> Listar(MLUsuario pobjMLUsuario);
        MLUsuario Obter(decimal pdecCodigo);
        MLUsuario Obter(string pstrLogin);
        MLUsuarioGrupo ObterCompleto(decimal pdecCodigo);
        bool Excluir(decimal pdecCodigo);
        bool Alterar(MLUsuario pobjMLUsuario);
        int Inserir(MLUsuario pobjMLUsuario);
        void InserirGrupos(decimal pdecCodigoUsuario, string strGruposUsuario);
        List<MLLogAcesso> ListarAuditoriaAcesso(Decimal pdecCodigoUsuario, DateTime? pdtDataInicio,DateTime? pdtDataFinal);
        decimal InserirAuditoriaAcesso(MLLogAcesso pobjMLLogAcesso);

    }
}
