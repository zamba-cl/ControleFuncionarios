<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmInicio.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid py-4">
        <div class="row">
            <asp:Repeater ID="rptFuncionarios" runat="server">
                <ItemTemplate>

                    <div class="col-md-4 mb-4">
                        <div class="card shadow"
                            style="border-radius: 15px; background: #f1f1f1;">

                            <div class="card-body">

                                <h5 class="card-title fw-bold mb-2">
                                    <%# Eval("nomeFuncionario") %>
                                </h5>

                                <p class="mb-1">
                                    <small class="text-muted">Cargo</small><br />
                                    <%# Eval("nomeCargo") %>
                                </p>

                                <p class="mb-1">
                                    <small class="text-muted">Data de Admissão</small><br />
                                    <%# Eval("dtAdmissao", "{0:dd/MM/yyyy}") %>
                                </p>

                                <p class="fw-bold mt-2" style="color: #0b2c4d;">
                                    <%# Eval("salario", "{0:C}") %>
                                </p>

                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
