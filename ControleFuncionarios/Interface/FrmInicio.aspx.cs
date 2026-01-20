using ControleFuncionarios.Transacao;
using System;
using System.Data;

namespace ControleFuncionarios.Interface
{
    public partial class FrmInicio : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherDadosFuncionarios();
            }
        }
        #endregion

        #region PreencherDadosFuncionarios
        protected void PreencherDadosFuncionarios()
        {
            DataTable dttFuncionario = FuncionarioTransacao.ExibirFuncionarios();
            rptFuncionarios.DataSource = dttFuncionario;
            rptFuncionarios.DataBind();
        }
        #endregion
    }
}