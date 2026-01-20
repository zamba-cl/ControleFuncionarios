using System.Collections;
using System.Data;

namespace ControleFuncionarios.Transacao
{
    public class FeriasTransacao
    {
        public static void IncluirFerias(Hashtable htParametros)
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"INSERT INTO Ferias (dtInicio, dtTermino, idFuncionario, statusFerias)
                            VALUES (@dtInicio, @dtTermino, @idFuncionario, @statusFerias)";

            dados.ExecutarNonQuery(sql, htParametros);
        }

        public static DataTable ExibirFerias()
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"SELECT * FROM Ferias f
                            INNER JOIN Funcionario u
                            ON f.idFuncionario = u.idFuncionario
                            WHERE u.statusFuncionario = 1
                            ORDER BY statusFerias, nomeFuncionario";

            return dados.ExecutarSelect(sql);
        }

        public static void AtualizarFerias(Hashtable htParametros)
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"UPDATE Ferias
                            SET dtInicio = @dtInicio,
                                dtTermino = @dtTermino,
                                idFuncionario = @idFuncionario, 
                                statusFerias = @statusFerias
                            WHERE idFerias = @idFerias";

            dados.ExecutarNonQuery(sql, htParametros);
        }

        public static DataTable ObterFeriasPorId(int idFerias)
        {
            AcessarDados dados = new AcessarDados();

            Hashtable htParametros = new Hashtable();
            htParametros.Add("@idFerias", idFerias);

            string sql = @"SELECT * FROM Ferias f
                            INNER JOIN Funcionario u
                            ON f.idFuncionario = u.idFuncionario
                            WHERE u.statusFuncionario = 1 AND f.idFerias = @idFerias";

            return dados.ExecutarSelect(sql, htParametros);
        }

        public static void ExcluirFerias(int idFerias)
        {
            AcessarDados dados = new AcessarDados();

            Hashtable htParametros = new Hashtable();
            htParametros.Add("@idFerias", idFerias);

            string sql = @"DELETE Ferias
                            WHERE idFerias = @idFerias";

            dados.ExecutarNonQuery(sql, htParametros);
        }
    }
}