using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Utilitarios;

namespace VM2.Framework.DataLayer.Utilitarios
{

    /// <summary>
    ///     Interface com os metodos relacionados as operacoes realizadas com a base de dados
    /// </summary>
    /// <user>mazevedo</user>
    public interface IDLLog
    {
        List<MLLog> Listar(MLLog pobjLog);
        int Inserir(MLLog pobjLog);
    }
}
