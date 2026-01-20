<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRelatorio.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmRelatorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-end mb-4">
        <asp:Button
            ID="btnExportarPdf"
            runat="server"
            Text="Salvar relatório em PDF"
            CssClass="btn text-white px-4"
            Style="background-color: #010126; border-color: #010126;"
            OnClick="btnExportarPdf_Click" />
    </div>

    <asp:Panel ID="pnlRelatorio" runat="server" Visible="true">
        <div class="table-responsive">
            <asp:GridView ID="grdRelatorio" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                DataKeyNames="idFerias, idCargo">
                <Columns>

                    <asp:BoundField DataField="idFuncionario" HeaderText="Id Funcionario">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="nomeFuncionario" HeaderText="Funcionário">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dtAdmissao" HeaderText="Data de admissão" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="nomeCargo" HeaderText="Cargo">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="salario" HeaderText="Salário">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dtInicio" HeaderText="Início férias" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dtTermino" HeaderText="Final férias" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="statusFerias" HeaderText="Status férias">
                        <HeaderStyle CssClass="text-center" Width="10%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="statusFuncionarioTexto" HeaderText="Status funcionário">
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
