<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmManterCargo.aspx.cs" Inherits="ControleFuncionarios.Interface.FrmManterCargo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid py-5">
        <div class="row d-flex justify-content-center">
            <div class="col-md-6">
                <div class="card p-4 shadow"
                    style="background: #e5e5e5; border: 2px solid #180e82; border-radius: 15px;">

                    <h4 class="text-center mb-4">Cadastro de cargos</h4>


                    <div class="mb-3">
                        <label class="form-label">Cargo</label>
                        <asp:TextBox ID="TxtCargo" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:CustomValidator
                            ID="cvCargo" runat="server"
                            ControlToValidate="TxtCargo"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            OnServerValidate="cvCargo_ServerValidate"
                            ValidateEmptyText="true">
                        </asp:CustomValidator>

                    </div>

                    <div class="mb-3">
                        <label class="form-label">Salario</label>
                        <asp:TextBox ID="TxtSalario" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:CustomValidator
                            ID="cvSalario" runat="server"
                            ControlToValidate="TxtSalario"
                            ErrorMessage="Campo obrigatório."
                            CssClass="text-danger"
                            OnServerValidate="cvSalario_ServerValidate"
                            ValidateEmptyText="true">
                        </asp:CustomValidator>

                    </div>

                    <asp:Button ID="btnCriarCargo" runat="server" autopostback="true" Text="Cadastrar cargo"
                        CssClass="btn w-100" Style="background: #180e82; color: white; border-radius: 10px;"
                        OnClick="btnCriarCargo_Click"></asp:Button>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
