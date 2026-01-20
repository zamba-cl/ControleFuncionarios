using ControleFuncionarios.Transacao;
using System;
using System.Data;

namespace ControleFuncionarios.Interface
{
    public partial class FrmAlteracoes : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherAlteracao();
            }
        }
        #endregion

        #region PreencherAlteracao
        private void PreencherAlteracao()
        {
            DataTable dttAlteracoes = AlteracaoTransacao.ObterAlteracao();
            grdAlteracoes.DataSource = dttAlteracoes;
            grdAlteracoes.DataBind();
        }
        #endregion
    }
}