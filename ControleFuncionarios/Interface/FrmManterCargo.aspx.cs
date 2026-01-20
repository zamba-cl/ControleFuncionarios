using ControleFuncionarios.Transacao;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFuncionarios.Interface
{
    public partial class FrmManterCargo : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    int IdCargo = Convert.ToInt32(Request.QueryString["id"]);
                    PreencherCargos(IdCargo);

                    btnCriarCargo.Text = "Atualizar Cargo";
                }
                else
                {
                    btnCriarCargo.Text = "Incluir Cargo";
                }
            }
        }
        #endregion

        #region PreencherCargos
        private void PreencherCargos(int idCargo)
        {
            DataTable dttCargos = CargoTransacao.ObterCargoPorId(idCargo);

            if (dttCargos.Rows.Count > 0)
            {
                TxtCargo.Text = dttCargos.Rows[0]["nomeCargo"].ToString();
                TxtSalario.Text = dttCargos.Rows[0]["salario"].ToString();                
            }
        }
        #endregion

        #region btnCriarCargo_Click
        protected void btnCriarCargo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Hashtable htParametros = new Hashtable();
                htParametros.Add("@nomeCargo", TxtCargo.Text.Trim());
                htParametros.Add("@salario", Convert.ToDecimal(TxtSalario.Text));

                if (Request.QueryString["id"] != null)
                {
                    htParametros.Add("@idCargo", Convert.ToInt32(Request.QueryString["id"]));
                    CargoTransacao.AtualizarCargo(htParametros);
                }
                else
                {
                    CargoTransacao.IncluirCargo(htParametros);
                }

                Response.Redirect("FrmCargos.aspx");
            }
        }
        #endregion

        #region CustomValidator

        protected void cvCargo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string cargo = TxtCargo.Text.Trim();

            if (string.IsNullOrEmpty(cargo))
                args.IsValid = false;
        }

        protected void cvSalario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string salarioTexto = TxtSalario.Text.Trim();
            decimal salario;

            if (string.IsNullOrEmpty(salarioTexto))
            {
                args.IsValid = false;
                return;
            }

            if (!decimal.TryParse(salarioTexto, out salario))
            {
                args.IsValid = false;
                return;
            }

            if (salario <= 0)
            {
                args.IsValid = false;
                return;
            }

            args.IsValid = true;
        }

        #endregion

    }
}