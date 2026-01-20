using ControleFuncionarios.Transacao;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ControleFuncionarios.Interface
{
    public partial class FrmFerias : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherFerias();
            }
        }
        #endregion

        #region PreencherFerias
        protected void PreencherFerias()
        {
            DataTable dttFerias = FeriasTransacao.ExibirFerias();
            grdFerias.DataSource = dttFerias;
            grdFerias.DataBind();
        }
        #endregion

        #region grdFerias_RowCommand
        protected void grdFerias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idFerias = Convert.ToInt32(grdFerias.DataKeys[index].Value);

                Response.Redirect($"FrmManterFerias.aspx?id={idFerias}");
            }
        }
        #endregion

        #region btnConfirmarExcluirFerias_Click
        protected void btnConfirmarExcluirFerias_Click(object sender, EventArgs e)
        {
            int idFerias = int.Parse(hfIdFerias.Value);

            FeriasTransacao.ExcluirFerias(idFerias);
            PreencherFerias();
        }
        #endregion
    }
}