<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ofertas.ascx.cs" Inherits="BellFone.B2B.UI.Componentes.Ofertas" %>

<div class="row">
    <ul class="hProductItems clearfix">
        <asp:Repeater ID="rptOfertas" runat="server" OnItemDataBound="rptOfertas_ItemDataBound">
            <HeaderTemplate>
                <asp:Panel ID="pnlMensagem" runat="server" Visible="false">
                    <div class="pagination pagination-right">
                        <br />
                        <span class="pull-left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltlMensagem" runat="server" /></span>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlPaginacaoCabecalho" runat="server">
                    <div class="pagination pagination-right">
                        <br />
                        <span class="pull-left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltlResultados" runat="server" /></span>
                        <ul>
                            <li>
                                <asp:LinkButton ID="btnPrimeiro" runat="server" CssClass="invarseColor" Text="Prim." OnClick="btnPrimeiro_Click" /></li>
                            <li>
                                <asp:LinkButton ID="btnAnterior" runat="server" CssClass="invarseColor" Text="Anter." OnClick="btnAnterior_Click" /></li>
                            <li class="active"><a class="invarseColor" href="">1</a></li>
                            <li><a class="invarseColor" href="">2</a></li>
                            <li><a class="invarseColor" href="">3</a></li>
                            <li><a class="invarseColor" href="">4</a></li>
                            <li>
                                <asp:LinkButton ID="btnProximo" runat="server" CssClass="invarseColor" Text="Prox." OnClick="btnProximo_Click" /></li>
                            <li>
                                <asp:LinkButton ID="btnUltimo" runat="server" CssClass="invarseColor" Text="Ulti." OnClick="btnUltimo_Click" /></li>
                        </ul>
                    </div>
                </asp:Panel>
            </HeaderTemplate>
            <ItemTemplate>
                <li class="span3 clearfix">
                    <div class="thumbnail">
                        <asp:LinkButton ID="btnDetalhesProduto" runat="server" CommandArgument='<%# Eval("Codigo") %>' OnClick="btnDetalhesProduto_Click">
                            <asp:Image ID="imgProduto" runat="server" Width="212px" Height="192px" />
                        </asp:LinkButton>
                    </div>
                    <div class="thumbSetting">
                        <div class="thumbTitle">
                            <asp:Label ID="lblProdutoNome" runat="server" Text='<%# Eval("Nome") %>' />
                        </div>
                        <div class="thumbPrice">
                            <asp:Label ID="lblProdutoValor" runat="server" Text='<%# Eval("ValorDe") %>' />
                        </div>
                        <div class="thumbButtons">
                            <asp:LinkButton ID="btnAdicionarCarrinho" runat="server" CommandArgument='<%# Eval("Codigo") %>' OnClick="btnAdicionarCarrinho_Click" class="btn btn-primary btn-small" data-title="Adicionar ao Carrinho" data-placement="top" data-toggle="tooltip">
                                <i class="icon-shopping-cart"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Panel ID="pnlPaginacaoRodape" runat="server">
                    <div class="pagination pagination-right">
                        <br />
                        <br />
                        <ul>
                            <li>
                                <asp:LinkButton ID="btnPrimeiro" runat="server" CssClass="invarseColor" Text="Prim." OnClick="btnPrimeiro_Click" /></li>
                            <li>
                                <asp:LinkButton ID="btnAnterior" runat="server" CssClass="invarseColor" Text="Anter." OnClick="btnAnterior_Click" /></li>
                            <li>
                                <asp:LinkButton ID="btnProximo" runat="server" CssClass="invarseColor" Text="Prox." OnClick="btnProximo_Click" /></li>
                            <li>
                                <asp:LinkButton ID="btnUltimo" runat="server" CssClass="invarseColor" Text="Ulti." OnClick="btnUltimo_Click" /></li>
                        </ul>
                    </div>
                </asp:Panel>
            </FooterTemplate>
        </asp:Repeater>
    </ul>
</div>
