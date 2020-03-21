<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.ascx.cs" Inherits="BellFone.B2B.UI.Componentes.MenuPrincipal" %>

<div class="mainNav">
    <div class="navbar">
        <ul class="nav">
            <li class="active"><a href="Default.aspx"><i class="icon-home"></i></a></li>
            <asp:Repeater ID="rptMenuPrincipal" runat="server" OnItemDataBound="rptMenuPrincipal_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:LinkButton ID="btnCategoria" runat="server" CommandArgument='<%# Eval("Codigo") %>' OnClick="btnCategoria_Click" />
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
