using System;
using System.Web.UI;

namespace ControleFuncionarios
{
    public partial class SiteMaster : MasterPage
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcarPaginaAtiva();
            }
        }
        #endregion

        #region MarcarPaginaAtiva
        private void MarcarPaginaAtiva()
        {
            string paginaAtual = System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower();

            if (paginaAtual == "frminicio") AtivarMenu(lnkInicio);
            else if (paginaAtual == "frmfuncionario") AtivarMenu(lnkFuncionario);
            else if (paginaAtual == "frmsalario") AtivarMenu(lnkSalario);
            else if (paginaAtual == "frmferias") AtivarMenu(lnkFerias);
            else if (paginaAtual == "frmrelatorio") AtivarMenu(lnkRelatorio);
            else if (paginaAtual == "frmalteracoes") AtivarMenu(lnkAlteracoes);
            else if (paginaAtual == "frmcargos") AtivarMenu(lnkCargos);
        }
        #endregion

        #region AtivarMenu
        private void AtivarMenu(System.Web.UI.HtmlControls.HtmlAnchor link)
        {
            if (link != null)
            {
                link.Attributes["class"] = "nav-link.active text-light";
            }
        }
        #endregion
    }
}
