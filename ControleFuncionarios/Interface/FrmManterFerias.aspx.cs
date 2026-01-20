using ControleFuncionarios.Transacao;
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

namespace ControleFuncionarios.Interface
{
    public partial class FrmCriarFerias : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherFuncionarios();

                if (Request.QueryString["id"] != null)
                {
                    int IdFerias = Convert.ToInt32(Request.QueryString["id"]);
                    PreencherFerias(IdFerias);

                    btnCadastrarFerias.Text = "Atualizar Férias";
                }
                else
                {
                    btnCadastrarFerias.Text = "Incluir Férias";
                }
            }
        }
        #endregion

        #region PreencherFuncionarios
        protected void PreencherFuncionarios()
        {
            DataTable dttCargo = FuncionarioTransacao.ExibirFuncionarios();
            ddlFuncionario.DataSource = dttCargo;
            ddlFuncionario.DataTextField = "idNome";
            ddlFuncionario.DataValueField = "idFuncionario";
            ddlFuncionario.DataBind();

            ddlFuncionario.Items.Insert(0, new ListItem("Selecione um funcionário", "0"));
            ddlFuncionario.SelectedIndex = 0;
        }
        #endregion

        #region PreencherFerias
        private void PreencherFerias(int idFerias)
        {
            DataTable dttFerias = FeriasTransacao.ObterFeriasPorId(idFerias);

            if (dttFerias.Rows.Count > 0)
            {
                ddlFuncionario.SelectedValue = dttFerias.Rows[0]["idFuncionario"].ToString();

                TxtDtInicio.Text = Convert.ToDateTime(dttFerias.Rows[0]["dtInicio"])
                                        .ToString("yyyy-MM-dd");

                TxtDtTermino.Text = Convert.ToDateTime(dttFerias.Rows[0]["dtTermino"])
                                        .ToString("yyyy-MM-dd");                
            }
        }
        #endregion

        #region btnCadastrarFerias_Click
        protected void btnCadastrarFerias_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Hashtable htParametros = new Hashtable();
                htParametros.Add("@idFuncionario", ddlFuncionario.SelectedValue);
                htParametros.Add("@dtInicio", TxtDtInicio.Text.Trim());
                htParametros.Add("@dtTermino", TxtDtTermino.Text.Trim());
                int idFerias = Convert.ToInt32(Request.QueryString["id"]);
                htParametros.Add("@idFerias", idFerias);

                if (DateTime.Today < Convert.ToDateTime(TxtDtInicio.Text))
                {
                    htParametros.Add("@statusFerias", "Pendente");
                }

                else if (DateTime.Today >= Convert.ToDateTime(TxtDtInicio.Text) &&
                         DateTime.Today <= Convert.ToDateTime(TxtDtTermino.Text))
                {
                    htParametros.Add("@statusFerias", "Em andamento");
                }

                else
                {
                    htParametros.Add("@statusFerias", "Concluída");
                }


                if (idFerias == 0)
                {
                    FeriasTransacao.IncluirFerias(htParametros);
                }
                else
                {
                    FeriasTransacao.AtualizarFerias(htParametros);
                }

                Response.Redirect("FrmFerias.aspx");
            }
        }
        #endregion  

        #region CustomValidator

        protected void cvFuncionario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string funcionario = ddlFuncionario.SelectedValue;
            if (string.IsNullOrEmpty(funcionario))
                args.IsValid = false;
        }

        protected void cvDtInicio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dataInicio;

            if (!DateTime.TryParse(TxtDtInicio.Text, out dataInicio))
                args.IsValid = false;
        }

        protected void cvDtTermino_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dataTermino;

            if (!DateTime.TryParse(TxtDtTermino.Text, out dataTermino))
                args.IsValid = false;
        }

        #endregion
    }
}