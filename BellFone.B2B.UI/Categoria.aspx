<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="BellFone.B2B.UI.Categoria" %>

<%@ Register Src="~/Componentes/SuperOfertas.ascx" TagPrefix="uc1" TagName="SuperOfertas" %>
<%@ Register Src="~/Componentes/Ofertas.ascx" TagPrefix="uc1" TagName="Ofertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConteudo" runat="server">
    <div class="container">
        <div class="row">
            <aside class="span3">
                <div class="categories">
                    <div class="titleHeader clearfix">
                        <h3>
                            <asp:Literal ID="ltlCategoria" runat="server" /></h3>
                    </div>
                    <asp:Repeater ID="rptGrupo" runat="server" OnItemDataBound="rptGrupo_ItemDataBound">
                        <ItemTemplate>
                            <ul class="unstyled">
                                <li>
                                    <asp:Literal ID="ltlGrupo" runat="server" Text='<%# Eval("Descricao") %>' />
                                    <ul class="submenu">
                                        <asp:Repeater ID="rptSubGrupo" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:LinkButton ID="btnSubGrupo" runat="server" CssClass="invarseColor" CommandArgument='<%# Eval("Codigo") %>' Text='<%# Eval("Descricao") %>' /></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <br />
                <br />
                <div id="special">
                    <div class="titleHeader clearfix">
                        <h3>Super Ofertas</h3>
                        <div class="pagers">
                            <div class="btn-toolbar">
                                <div class="btn-group">
                                    <button class="btn btn-mini vNext"><i class="icon-caret-down"></i></button>
                                    <button class="btn btn-mini vPrev"><i class="icon-caret-up"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <ul class="vProductItems cycle-slideshow vertical clearfix"
                        data-cycle-fx="carousel"
                        data-cycle-timeout="0"
                        data-cycle-slides="> li"
                        data-cycle-next=".vPrev"
                        data-cycle-prev=".vNext"
                        data-cycle-carousel-visible="5"
                        data-cycle-carousel-vertical="true">
                        <uc1:SuperOfertas runat="server" ID="SuperOfertas" />
                    </ul>
                </div>
            </aside>
            <div class="span9">
                <uc1:Ofertas runat="server" ID="Ofertas" />
            </div>
        </div>
    </div>
</asp:Content>
