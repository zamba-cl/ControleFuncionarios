<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmFerias.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmFerias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-end mb-4">
        <a href="FrmManterFerias.aspx"
            class="btn btn-primary"
            style="background-color: #010126; border-color: #010126;">+ Incluir férias
        </a>
    </div>

    <asp:Panel ID="pnlFerias" runat="server" Visible="true">
        <div class="table-responsive">
            <asp:GridView ID="grdFerias" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                DataKeyNames="idFerias" OnRowCommand="grdFerias_RowCommand">
                <Columns>
                    <asp:BoundField DataField="idFuncionario" HeaderText="Id Funcionario">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="nomeFuncionario" HeaderText="Funcionário">
                        <HeaderStyle CssClass="text-center" Width="20%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dtInicio" HeaderText="Data inicial" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                        <HeaderStyle CssClass="text-center" Width="20%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dtTermino" HeaderText="Data final" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                        <HeaderStyle CssClass="text-center" Width="20%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="statusFerias" HeaderText="Status">
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
                                OnClientClick='<%# "abrirModalExcluirFerias(" + Eval("idFerias") + "); return false;" %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>

    <div class="modal fade" id="modalExcluirFerias" tabindex="-1">
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
                        Tem certeza que deseja <strong>excluir as férias deste funcionário</strong>?
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

                    <asp:HiddenField ID="hfIdFerias" runat="server" />

                    <asp:Button ID="btnConfirmarExcluirFerias"
                        runat="server"
                        Text="Confirmar exclusão"
                        CssClass="btn btn-danger"
                        OnClick="btnConfirmarExcluirFerias_Click" />

                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">

    <script>

        function abrirModalExcluirFerias(idFerias) {
            document.getElementById('<%= hfIdFerias.ClientID %>').value = idFerias;

            var modal = new bootstrap.Modal(
                document.getElementById('modalExcluirFerias')
            );
            modal.show();
        }

    </script>

</asp:Content>
