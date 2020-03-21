<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuperOfertas.ascx.cs" Inherits="BellFone.B2B.UI.Componentes.SuperOfertas" %>

<asp:Repeater ID="rptSuperOfertas" runat="server" OnItemDataBound="rptSuperOfertas_ItemDataBound">
    <ItemTemplate>
        <li class="span4 clearfix">
            <div class="thumbImage">
                <asp:LinkButton ID="btnDetalhesProduto" runat="server" CommandArgument='<%# Eval("Codigo") %>' OnClick="btnDetalhesProduto_Click">
                    <asp:Image ID="imgProduto" runat="server" Width="92px" Height="92px" />
                </asp:LinkButton>
            </div>
            <div class="thumbSetting">
                <div class="thumbTitle">
                    <asp:Literal ID="lblProdutoNome" runat="server" Text='<%# Eval("Nome") %>' />
                </div>
                <div class="thumbPrice">
                    <asp:Label ID="lblProdutoValor" runat="server" Text='<%# Eval("ValorDe") %>' />
                </div>
            </div>
        </li>
    </ItemTemplate>
</asp:Repeater>
