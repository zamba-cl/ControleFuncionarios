<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmManterFuncionario.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmManterFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid py-5">
        <div class="row d-flex justify-content-center">
            <div class="col-md-6">
                <div class="card p-4 shadow"
                    style="background: #e5e5e5; border: 2px solid #180e82; border-radius: 15px;">

                    <h4 class="text-center mb-4">Cadastro de funcionário</h4>


                    <div class="mb-3">
                        <label class="form-label">Nome do funcionário</label>
                        <asp:TextBox ID="TxtNomeFuncionario" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:CustomValidator
                            ID="cvNomeFuncionario" runat="server"
                            ControlToValidate="TxtNomeFuncionario"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            OnServerValidate="cvNomeFuncionario_ServerValidate"
                            ValidateEmptyText="true">
                        </asp:CustomValidator>

                    </div>

                    <div class="mb-3">
                        <label class="form-label">Data de admissão</label>
                        <asp:TextBox ID="TxtDtAdmissao"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
                        </asp:TextBox>

                        <asp:CustomValidator
                            ID="cvDtAdmissao"
                            runat="server"
                            ControlToValidate="TxtDtAdmissao"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            ValidateEmptyText="true"
                            OnServerValidate="cvDtAdmissao_ServerValidate">
                        </asp:CustomValidator>

                    </div>

                    <div class="mb-3">
                        <label class="form-label">Cargo</label>

                        <asp:DropDownList ID="ddlCargo" runat="server"
                            CssClass="form-select">
                        </asp:DropDownList>

                        <asp:CustomValidator
                            ID="cvCargos"
                            runat="server"
                            ControlToValidate="ddlCargo"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            ValidateEmptyText="true"
                            OnServerValidate="cvCargos_ServerValidate">
                        </asp:CustomValidator>

                    </div>



                    <asp:Button ID="btnCriarFuncionario" runat="server" autopostback="true" Text="Cadastrar funcionário"
                        CssClass="btn w-100" Style="background: #180e82; color: white; border-radius: 10px;"
                        OnClick="btnCriarFuncionario_Click"></asp:Button>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
