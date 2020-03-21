<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BellFone.B2B.UI.Default" %>

<%@ Register Src="~/Componentes/Slider.ascx" TagPrefix="uc1" TagName="Slider" %>
<%@ Register Src="~/Componentes/SuperOfertas.ascx" TagPrefix="uc1" TagName="SuperOfertas" %>
<%@ Register Src="~/Componentes/Ofertas.ascx" TagPrefix="uc1" TagName="Ofertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConteudo" runat="server">
    <div class="container">
        <div class="row">
            <uc1:Slider runat="server" ID="Slider" />
            <div class="span4">
                <div id="homeSpecial">
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
                        data-cycle-carousel-visible="2"
                        data-cycle-carousel-vertical="true">
                    <uc1:SuperOfertas runat="server" ID="SuperOfertas" />
                    </ul>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="span12">
                <div id="featuredItems">
                    <div class="titleHeader clearfix">
                        <h3>Ofertas</h3>
                    </div>
                    <uc1:Ofertas runat="server" ID="Ofertas" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="span12">
                <div id="brands">
                    <div class="titleHeader clearfix">
                        <h3>Lorem Ipsum</h3>
                    </div>
                    <ul class="brandList clearfix">
                        <li>
                            <a href="#">
                                <img src="img/Layer-4.png" alt="logo"></a>
                        </li>
                        <li>
                            <a href="#">
                                <img src="img/Layer-1.png" alt="logo"></a>
                        </li>
                        <li>
                            <a href="#">
                                <img src="img/Layer-3.png" alt="logo"></a>
                        </li>
                        <li>
                            <a href="#">
                                <img src="img/Layer-2.png" alt="logo"></a>
                        </li>
                    </ul>
                    <ul class="brandList clearfix">
                        <li>
                            <a href="#">
                                <img src="img/Layer-4.png" alt="logo"></a>
                        </li>
                        <li>
                            <a href="#">
                                <img src="img/Layer-1.png" alt="logo"></a>
                        </li>
                        <li>
                            <a href="#">
                                <img src="img/Layer-3.png" alt="logo"></a>
                        </li>
                        <li>
                            <a href="#">
                                <img src="img/Layer-2.png" alt="logo"></a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
