<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmManterFerias.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmCriarFerias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid py-5">
        <div class="row d-flex justify-content-center">
            <div class="col-md-6">
                <div class="card p-4 shadow"
                    style="background: #e5e5e5; border: 2px solid #180e82; border-radius: 15px;">

                    <h4 class="text-center mb-4">Cadastro de férias</h4>


                    <div class="mb-3">
                        <label class="form-label">Funcionário</label>

                        <asp:DropDownList ID="ddlFuncionario" runat="server"
                            CssClass="form-select">
                        </asp:DropDownList>

                        <asp:CustomValidator
                            ID="cvFuncionario"
                            runat="server"
                            ControlToValidate="ddlFuncionario"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            ValidateEmptyText="true"
                            OnServerValidate="cvFuncionario_ServerValidate">
                        </asp:CustomValidator>

                    </div>

                    <div class="mb-3">
                        <label class="form-label">Data de início</label>
                        <asp:TextBox ID="TxtDtInicio"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
                        </asp:TextBox>

                        <asp:CustomValidator
                            ID="cvDtInicio"
                            runat="server"
                            ControlToValidate="TxtDtInicio"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            ValidateEmptyText="true"
                            OnServerValidate="cvDtInicio_ServerValidate">
                        </asp:CustomValidator>

                    </div>

                    <div class="mb-3">
                        <label class="form-label">Data de término</label>
                        <asp:TextBox ID="TxtDtTermino"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
                        </asp:TextBox>

                        <asp:CustomValidator
                            ID="cvDtTermino"
                            runat="server"
                            ControlToValidate="TxtDtTermino"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            ValidateEmptyText="true"
                            OnServerValidate="cvDtTermino_ServerValidate">
                        </asp:CustomValidator>

                    </div>

                    <asp:Button ID="btnCadastrarFerias" runat="server" autopostback="true" Text="Cadastrar férias"
                        CssClass="btn w-100" Style="background: #180e82; color: white; border-radius: 10px;"
                        OnClick="btnCadastrarFerias_Click"></asp:Button>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
