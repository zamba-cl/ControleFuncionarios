<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmFuncionario.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid py-4">

        <div class="card shadow-sm mb-4"
            style="border-left: 5px solid #010126;">

            <div class="card-body">

                <div class="row g-3">

                    <div class="col-12 col-md-4">
                        <label class="form-label fw-semibold">Pesquisar</label>
                        <asp:TextBox ID="txtPesquisar" runat="server"
                            CssClass="form-control"
                            placeholder="Nome do funcionário" />
                    </div>

                    <div class="col-12 col-md-4">
                        <label class="form-label fw-semibold">Cargo</label>
                        <asp:DropDownList ID="ddlCargo" runat="server"
                            CssClass="form-select">
                            <asp:ListItem Text="Todos os cargos" Value="0" />
                        </asp:DropDownList>
                    </div>

                    <div class="col-12 col-md-4 d-flex gap-2 align-items-end">

                        <asp:Button ID="btnFiltrar" runat="server"
                            Text="Filtrar"
                            CssClass="btn btn-outline-primary w-50" 
                            onclick="btnFiltrar_Click"/>

                        <a href="FrmManterFuncionario.aspx"
                            class="btn btn-primary w-50"
                            style="background-color: #010126; border-color: #010126;">+ Adicionar funcionário
                        </a>

                    </div>

                </div>

            </div>
        </div>

    </div>


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

                            <p class="fw-bold mt-2 mb-3" style="color: #0b2c4d;">
                                <%# Eval("salario", "{0:C}") %>
                            </p>

                            <div class="d-flex gap-2">

                                <a href='FrmManterFuncionario.aspx?id=<%# Eval("idFuncionario") %>'
                                    class="btn btn-outline-primary w-50">Editar
                                </a>

                                <button type="button"
                                    class="btn btn-outline-danger w-50"
                                    data-bs-toggle="modal"
                                    data-bs-target="#modalDesligar"
                                    onclick="setFuncionario('<%# Eval("idFuncionario") %>')">
                                    Desligar
                                </button>

                            </div>

                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>

    <div class="modal fade" id="modalDesligar" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title text-danger">Confirmar desligamento
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>

                <div class="modal-body">
                    <p>
                        Tem certeza que deseja <strong>desligar este funcionário</strong>?
                    </p>
                    <p class="text-muted mb-0">
                        Essa ação poderá ser revertida apenas por um administrador.
                    </p>
                </div>

                <div class="modal-footer">

                    <button type="button"
                        class="btn btn-secondary"
                        data-bs-dismiss="modal">
                        Cancelar
                    </button>

                    <asp:HiddenField ID="hfFuncionarioId" runat="server" />

                    <asp:Button ID="btnConfirmarDesligamento" runat="server"
                        Text="Confirmar desligamento"
                        CssClass="btn btn-danger"
                        OnClick="btnConfirmarDesligamento_Click" />

                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">

    <script>
        function setFuncionario(id) {
            document.getElementById('<%= hfFuncionarioId.ClientID %>').value = id;
        }
    </script>

</asp:Content>
