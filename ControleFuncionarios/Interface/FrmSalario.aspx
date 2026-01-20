<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmSalario.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmSalario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">

        <div class="row justify-content-center">
            <div class="col-md-10 col-lg-8">

                <h2 class="text-center fw-semibold mb-4">A média dos salários dos funcionários ativos na empresa é:
                </h2>

                <div class="card shadow-sm text-center">
                    <div class="card-body py-5">

                        <asp:Label ID="lblMediaSalarios"
                            runat="server"
                            CssClass="display-4 fw-bold text-dark"
                            Text="R$ 0,00">
                        </asp:Label>

                    </div>
                </div>

            </div>
        </div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
