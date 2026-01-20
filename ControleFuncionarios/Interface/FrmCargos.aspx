<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCargos.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmCargos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-end mb-4">
        <a href="FrmManterCargo.aspx"
            class="btn btn-primary"
            style="background-color: #010126; border-color: #010126;">+ Criar Cargo
        </a>
    </div>

    <asp:Panel ID="pnlFerias" runat="server" Visible="true">
        <div class="table-responsive">
            <asp:GridView ID="grdCargos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                DataKeyNames="idCargo" OnRowCommand="grdCargos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="nomeCargo" HeaderText="Cargo">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="salario" HeaderText="Salário">
                        <HeaderStyle CssClass="text-center" Width="20%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="quantidadeFuncionarios" HeaderText="Quantidade funcionários">
                        <HeaderStyle CssClass="text-center" Width="20%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Editar">
                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="text-center" Width="8%" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server"
                                ImageUrl="~/Images/iconeEditar.png"
                                Width="24px"
                                Height="24px"
                                CommandName="Editar"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                ToolTip="Editar"
                                CssClass="img-icon" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Excluir">
                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="text-center" Width="5%" />
                        <ItemTemplate>
                            <asp:ImageButton ID="btnExcluir" runat="server"
                                ImageUrl="~/Images/iconeExcluir.png"
                                Width="24px"
                                Height="24px"
                                ToolTip="Excluir"
                                CssClass="img-icon"
                                OnClientClick='<%# "abrirModalExcluirCargo(" + Eval("idCargo") + "); return false;" %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>

    <div class="modal fade" id="modalExcluirCargo" tabindex="-1">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title text-danger">Confirmar exclusão
                    </h5>
                    <button type="button"
                        class="btn-close"
                        data-bs-dismiss="modal">
                    </button>
                </div>

                <div class="modal-body">
                    <p>
                        Tem certeza que deseja <strong>excluir esse cargo</strong>?
                    </p>
                    <p class="text-muted mb-0">
                        Essa ação não poderá ser desfeita.
                    </p>
                </div>

                <div class="modal-footer">

                    <button type="button"
                        class="btn btn-secondary"
                        data-bs-dismiss="modal">
                        Cancelar
                    </button>

                    <asp:HiddenField ID="hfIdCargo" runat="server" />

                    <asp:Button ID="btnConfirmarExcluirCargo"
                        runat="server"
                        Text="Confirmar exclusão"
                        CssClass="btn btn-danger"
                        OnClick="btnConfirmarExcluirCargo_Click" />

                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">

    <script>

        function abrirModalExcluirCargo(idCargo) {
            document.getElementById('<%= hfIdCargo.ClientID %>').value = idCargo;

            var modal = new bootstrap.Modal(
                document.getElementById('modalExcluirCargo')
            );
            modal.show();
        }

    </script>

</asp:Content>
