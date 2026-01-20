using ControleFuncionarios.Transacao;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;

namespace ControleFuncionarios.Interface
{
    public partial class FrmRelatorio : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherRelatorio();
            }
        }
        #endregion

        #region PreencherRelatorio
        protected void PreencherRelatorio()
        {
            DataTable dttFerias = FuncionarioTransacao.RelatorioFuncionarios();
            grdRelatorio.DataSource = dttFerias;
            grdRelatorio.DataBind();
        }
        #endregion

        #region btnExportarPdf_Click
        protected void btnExportarPdf_Click(object sender, EventArgs e)
        {
            DataTable dtt = FuncionarioTransacao.RelatorioFuncionarios();

            Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            MemoryStream ms = new MemoryStream();
            PdfWriter.GetInstance(doc, ms);

            doc.Open();

            Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15);
            Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
            Font fontCell = FontFactory.GetFont(FontFactory.HELVETICA, 8);

            Paragraph titulo = new Paragraph("Relatório de Funcionários", fontTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 15f;
            doc.Add(titulo);

            PdfPTable tabela = new PdfPTable(9);
            tabela.WidthPercentage = 100;
            tabela.SetWidths(new float[] { 4, 14, 12, 10, 8, 10, 10, 10, 8 });

            string[] headers = { "ID", "Nome", "Cargo", "Admissão", "Salário", "Início Férias", "Fim Férias", "Status Férias", "Status"};

            foreach (string header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, fontHeader));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Padding = 5;
                tabela.AddCell(cell);
            }

            foreach (DataRow row in dtt.Rows)
            {
                tabela.AddCell(CriarCelula(row["idFuncionario"], fontCell, Element.ALIGN_CENTER));
                tabela.AddCell(CriarCelula(row["nomeFuncionario"], fontCell, Element.ALIGN_LEFT));
                tabela.AddCell(CriarCelula(row["nomeCargo"], fontCell, Element.ALIGN_LEFT));


                tabela.AddCell(CriarCelula(
                    row["dtAdmissao"] != DBNull.Value
                        ? Convert.ToDateTime(row["dtAdmissao"]).ToString("dd/MM/yyyy")
                        : "-",
                    fontCell,
                    Element.ALIGN_CENTER));

                
                tabela.AddCell(CriarCelula(
                    row["salario"] != DBNull.Value
                        ? Convert.ToDecimal(row["salario"]).ToString("C2")
                        : "-",
                    fontCell,
                    Element.ALIGN_RIGHT));

                
                tabela.AddCell(CriarCelula(
                    row["dtInicio"] != DBNull.Value
                        ? Convert.ToDateTime(row["dtInicio"]).ToString("dd/MM/yyyy")
                        : "-",
                    fontCell,
                    Element.ALIGN_CENTER));

               
                tabela.AddCell(CriarCelula(
                    row["dtTermino"] != DBNull.Value
                        ? Convert.ToDateTime(row["dtTermino"]).ToString("dd/MM/yyyy")
                        : "-",
                    fontCell,
                    Element.ALIGN_CENTER));

                tabela.AddCell(CriarCelula(row["statusFerias"], fontCell, Element.ALIGN_CENTER));
                tabela.AddCell(CriarCelula(row["statusFuncionarioTexto"], fontCell, Element.ALIGN_CENTER));
            }

            doc.Add(tabela);
            doc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=RelatorioFuncionarios.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }


        private PdfPCell CriarCelula(object texto, Font fonte, int alinhamento)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto?.ToString(), fonte));
            cell.HorizontalAlignment = alinhamento;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 4;
            cell.NoWrap = false;
            return cell;
        }
        #endregion
    }
}