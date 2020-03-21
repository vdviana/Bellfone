<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="BellFone.B2B.UI.Produto" %>

<%@ Register Src="~/Componentes/SuperOfertas.ascx" TagPrefix="uc1" TagName="SuperOfertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConteudo" runat="server">
    <div class="container">
        <div class="row">
            <aside class="span3">
                <div class="aside-inner" id="product-aside">
                    <div class="special">
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
                </div>
            </aside>
            <div class="span9">
                <div class="row">
                    <div class="product-details clearfix">
                        <div class="span5">
                            <div class="product-title">
                                <h4>
                                    <asp:Literal ID="ltlNome" runat="server" /></h4>
                            </div>
                            <div class="product-img">
                                <asp:Image ID="imgProduto" runat="server" Width="372px" Height="370px" />
                            </div>
                        </div>
                        <div class="span4">
                            <div class="product-set">
                                <div class="product-price">
                                    <asp:Label ID="lblPreco" runat="server" />
                                </div>
                                <div class="product-info">
                                    <dl class="dl-horizontal">
                                        <dt>Código:</dt>
                                        <dd>
                                            <asp:Literal ID="ltlCodigo" runat="server" /></dd>

                                        <dt>Fabricante:</dt>
                                        <dd>
                                            <asp:Literal ID="ltlFabricante" runat="server" /></dd>

                                        <dt>Unidade de Medida:</dt>
                                        <dd>
                                            <asp:Literal ID="ltlUnidadeMedida" runat="server" /></dd>
                                    </dl>
                                </div>
                                <div class="input-append">
                                    <input class="span1" type="text" name="" value="" placeholder="Qtd">
                                    <button class="btn btn-primary"><i class="icon-shopping-cart"></i> Adicionar ao Carrinho</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlDescricao" runat="server">
                    <div class="product-tab">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a href="#descricao" data-toggle="tab">Descrição</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="descricao">
                                <asp:Literal ID="ltlDescricao" runat="server" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
