using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Vendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLIntegracao
    {
        public enum Prefixo
        {
            ORC, //ORÇAMENTO
            IOR, //ORÇAMENTO ITEM
            GRU, //GRUPO
            FFI, //FICHA FINANCEIRA
            FAB, //FRABRICANTE
            EFI, //EXTRATO FINANCEIRO
            CPA, //CONDIÇÃO DE PAGAMENTO
            CAT, //CATEGORIA
            PRO, //PRODUTO
            REV, //REVENDEDOR
            SIO, //STATUS ITEM ORÇAMENTO
            SGR, //SUBGRUPO
            VEN, //VENDEDOR
            TPN, //TIPO DE NEGOCIO
            REG, //REGIÃO
            PAT, //PERMISSÃO DE ATENDIMENTO
            UNM,  //UNIDADE DE MEDIDA
            CPG,  //CONDIÇÃO DE PAGAMENTO
            FPA,  //FORMA DE PAGAMENTO
            ACC   //ACESSOS
        }
    }
}
 