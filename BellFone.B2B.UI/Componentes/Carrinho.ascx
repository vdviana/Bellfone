<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carrinho.ascx.cs" Inherits="BellFone.B2B.UI.Componentes.Carrinho" %>

<div class="pull-right">
    <div class="btn-group">
        <a class="btn dropdown-toggle" data-toggle="dropdown" href="#">
            <i class="icon-shopping-cart"></i>3 Itens
                                    <span class="caret"></span>
        </a>
        <div class="dropdown-menu cart-content pull-right">
            <table class="table-cart">
                <tbody>
                    <tr>
                        <td class="cart-product-info">
                            <a href="#">
                                <img src="img/72x72.jpg" alt="product image"></a>
                            <div class="cart-product-desc">
                                <p><a class="invarseColor" href="#">Foliomania the designer portfolio brochure</a></p>
                                <ul class="unstyled">
                                    <li>Available: Yes</li>
                                    <li>Color: Black</li>
                                </ul>
                            </div>
                        </td>
                        <td class="cart-product-setting">
                            <p><strong>1x-$500.00</strong></p>
                            <a href="#" class="remove-pro" data-toggle="tooltip" data-title="Delete"><i class="icon-trash"></i></a>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td class="cart-product-info">
                            <a href="#" class="btn btn-small">Vew cart</a>
                            <a href="#" class="btn btn-small btn-primary">Checkout</a>
                        </td>
                        <td>
                            <h3>TOTAL<br>
                                $1,598.30</h3>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</div>
