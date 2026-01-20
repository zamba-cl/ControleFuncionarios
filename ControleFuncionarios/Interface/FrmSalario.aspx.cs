using ControleFuncionarios.Transacao;
using System;
using System.Data;

namespace ControleFuncionarios.Interface
{
    public partial class FrmSalario : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarMediaSalarios();
            }
        }
        #endregion

        #region CarregarMediaSalarios
        private void CarregarMediaSalarios()
        {
            DataTable dttMedia = FuncionarioTransacao.MediaSalarios();

            if (dttMedia.Rows.Count > 0 && dttMedia.Rows[0]["MediaSalarios"] != DBNull.Value)
            {
                decimal media = Convert.ToDecimal(dttMedia.Rows[0]["MediaSalarios"]);
                lblMediaSalarios.Text = media.ToString("C");
            }
            else
            {
                lblMediaSalarios.Text = "R$ 0,00";
            }
        }
        #endregion
    }
}