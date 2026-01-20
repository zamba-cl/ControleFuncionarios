using ControleFuncionarios.Transacao;
using System;
using System.Data;
using System.Web.UI;

namespace ControleFuncionarios.Interface
{
    public partial class FrmCargos : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherCargos();
            }            
        }
        #endregion

        #region PreencherCargos
        private void PreencherCargos()
        {
            DataTable dttCargos = CargoTransacao.ObterCargosSalario();
            grdCargos.DataSource = dttCargos;
            grdCargos.DataBind();
        }
        #endregion

        #region grdCargos_RowCommand
        protected void grdCargos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idCargo = Convert.ToInt32(grdCargos.DataKeys[index].Value);

                Response.Redirect($"FrmManterCargo.aspx?id={idCargo}");
            }
        }
        #endregion

        #region btnConfirmarExcluirCargo_Click
        protected void btnConfirmarExcluirCargo_Click(object sender, EventArgs e)
        {
            int idCargo = int.Parse(hfIdCargo.Value);

            if (CargoTransacao.CargoPossuiFuncionarios(idCargo))
            {

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "alerta",
                    "alert('Não é possível excluir este cargo porque existem funcionários vinculados a ele.');",
                    true
                );
                return;
            }

            CargoTransacao.ExcluirCargo(idCargo);
            PreencherCargos();
        }
        #endregion
    }
}