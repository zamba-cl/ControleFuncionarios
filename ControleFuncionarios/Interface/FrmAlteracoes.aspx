<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAlteracoes.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmAlteracoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlAlteracoes" runat="server" Visible="true">
        <div class="table-responsive">
            <asp:GridView ID="grdAlteracoes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>

                    <asp:BoundField DataField="nomeFuncionario" HeaderText="Funcionário">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="campoAlterado" HeaderText="Campo alterado">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="valorAntigo" HeaderText="Valor antigo">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="valorNovo" HeaderText="Valor novo">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dtHrAlteracao" HeaderText="Data da alteração" DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="false">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                </Columns>
            </asp:GridView>
        </div>

    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
