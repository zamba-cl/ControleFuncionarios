using ControleFuncionarios.Transacao;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ControleFuncionarios.Interface
{
    public partial class FrmFuncionario : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {

            ObterDadosFuncionarios();

            if (!IsPostBack)
            {
                PreencherCargos();
            }
        }
        #endregion

        #region ObterDadosFuncionarios
        protected void ObterDadosFuncionarios()
        {
            DataTable dttFuncionarios = FuncionarioTransacao.ExibirFuncionarios();

            ViewState["dttFuncionarios"] = dttFuncionarios;

            PreencherFuncionarios(dttFuncionarios);
        }
        #endregion

        #region btnFiltrar_Click
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataTable dttFiltro = (DataTable)ViewState["dttFuncionarios"];

            string nome = txtPesquisar.Text;
            string cargo = ddlCargo.SelectedValue;

            DataView dv = dttFiltro.DefaultView;

            string filtro = "1 = 1";

            if (!string.IsNullOrEmpty(nome))
                filtro += $" AND nomeFuncionario LIKE '%{nome}%'";

            if (cargo != "0")
                filtro += $" AND idCargo = '{cargo}'";

            dv.RowFilter = filtro;

            dttFiltro = dv.ToTable();


            PreencherFuncionarios(dttFiltro);
        }
        #endregion

        #region PreencherFuncionarios
        private void PreencherFuncionarios(DataTable dttFuncionarios)
        {
            rptFuncionarios.DataSource = dttFuncionarios;
            rptFuncionarios.DataBind();
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

        #region btnConfirmarDesligamento_Click
        protected void btnConfirmarDesligamento_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hfFuncionarioId.Value);
            FuncionarioTransacao.DesligarFuncionario(id);
        }
        #endregion
    }
}