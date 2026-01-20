using ControleFuncionarios.Transacao;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFuncionarios.Interface
{
    public partial class FrmManterFuncionario : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherCargos();

                if (Request.QueryString["id"] != null)
                {
                    int IdFuncionario = Convert.ToInt32(Request.QueryString["id"]);
                    PreencherFuncionario(IdFuncionario);

                    btnCriarFuncionario.Text = "Atualizar Funcionário";
                }
                else
                {
                    btnCriarFuncionario.Text = "Cadastrar Funcionário";
                }
            }
        }
        #endregion

        #region btnCriarFuncionario_Click
        protected void btnCriarFuncionario_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            Hashtable htParametros = new Hashtable();
            htParametros.Add("@nomeFuncionario", TxtNomeFuncionario.Text.Trim());
            htParametros.Add("@dtAdmissao", TxtDtAdmissao.Text.Trim());
            htParametros.Add("@idCargo", ddlCargo.SelectedValue);

            int idFuncionario = Convert.ToInt32(Request.QueryString["id"]);
            if (idFuncionario == 0)
            {
                FuncionarioTransacao.IncluirFuncionario(htParametros);
            }
            else
            { 
                htParametros.Add("@idFuncionario", idFuncionario);

                FuncionarioTransacao.AtualizarFuncionario(htParametros);
            }

            Response.Redirect("FrmFuncionario.aspx");
        }
        #endregion

        #region PreencherCargos
        protected void PreencherCargos()
        {
            DataTable dttCargo = CargoTransacao.ObterCargos();

            ddlCargo.DataSource = dttCargo;
            ddlCargo.DataTextField = "nomeCargo";
            ddlCargo.DataValueField = "idCargo";
            ddlCargo.DataBind();

            ddlCargo.Items.Insert(0, new ListItem("Selecione um cargo", "0"));
            ddlCargo.SelectedIndex = 0;
        }
        #endregion

        #region PreencherFuncionario
        private void PreencherFuncionario(int idFuncionario)
        {
            DataTable dttFuncionarios = FuncionarioTransacao.ObterFuncionarioPorId(idFuncionario);

            if (dttFuncionarios.Rows.Count > 0)
            {
                TxtNomeFuncionario.Text = dttFuncionarios.Rows[0]["nomeFuncionario"].ToString();

                TxtDtAdmissao.Text = Convert.ToDateTime(dttFuncionarios.Rows[0]["dtAdmissao"])
                                        .ToString("yyyy-MM-dd");

                ddlCargo.SelectedValue = dttFuncionarios.Rows[0]["idCargo"].ToString();
            }
        }
        #endregion

        #region Custom Validators

        protected void cvNomeFuncionario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(TxtNomeFuncionario.Text);
        }

        protected void cvDtAdmissao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime data;
            args.IsValid = DateTime.TryParse(TxtDtAdmissao.Text, out data);
        }

        protected void cvCargos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlCargo.SelectedValue != "0";
        }

        #endregion
    }
}
