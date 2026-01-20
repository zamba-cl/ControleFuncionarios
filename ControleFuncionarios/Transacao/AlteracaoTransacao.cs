using System.Collections;
using System.Data;

namespace ControleFuncionarios.Transacao
{
    public class AlteracaoTransacao
    {
        #region IncluirAlteracao
        public static void IncluirAlteracao(Hashtable htParametros)
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"INSERT INTO Alteracao (dtHrAlteracao, campoAlterado, valorAntigo, valorNovo, idFuncionario)
                            VALUES (@dtHrAlteracao, @campoAlterado, @valorAntigo, @valorNovo, @idFuncionario)";

            dados.ExecutarNonQuery(sql, htParametros);
        }
        #endregion

        #region ObterAlteracao
        public static DataTable ObterAlteracao()
        {
            AcessarDados dados = new AcessarDados();
                         
            string sql = @"SELECT a.campoAlterado, a.valorAntigo, a.valorNovo, a.idFuncionario, a.dtHrAlteracao, f.nomeFuncionario, f.idCargo, c.idCargo, c.nomeCargo 
                                    FROM Alteracao a
                                    INNER JOIN Funcionario f ON a.idFuncionario = f.idFuncionario
                                    INNER JOIN Cargo c ON f.idCargo = c.idCargo
                                    ORDER BY dtHrAlteracao DESC";

            return dados.ExecutarSelect(sql);
        }
        #endregion
    }
}