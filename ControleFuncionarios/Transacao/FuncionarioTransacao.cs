using System;
using System.Collections;
using System.Data;

namespace ControleFuncionarios.Transacao
{
    public class FuncionarioTransacao
    {
        #region IncluirFuncionario
        public static void IncluirFuncionario(Hashtable htParametros)
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"INSERT INTO Funcionario (nomeFuncionario, dtAdmissao, idCargo)
                            VALUES (@nomeFuncionario, @dtAdmissao, @idCargo)";

            dados.ExecutarNonQuery(sql, htParametros);
        }
        #endregion

        #region AtualizarFuncionario
        public static void AtualizarFuncionario(Hashtable htParametros)
        {
            AcessarDados dados = new AcessarDados();
            DataTable dttFuncionario = ObterFuncionarioPorId((int)htParametros["@idFuncionario"]);            

            string sql = @"UPDATE Funcionario
                            SET nomeFuncionario = @nomeFuncionario, 
                                dtAdmissao = @dtAdmissao,
                                idCargo = @idCargo
                            WHERE idFuncionario = @idFuncionario;";

            dados.ExecutarNonQuery(sql, htParametros);

            if (dttFuncionario.Rows[0]["nomeFuncionario"].ToString() != htParametros["@nomeFuncionario"].ToString())
            {
                htParametros.Add("@valorAntigo", dttFuncionario.Rows[0]["nomeFuncionario"]);
                htParametros.Add("@valorNovo", htParametros["@nomeFuncionario"]);
                htParametros.Add("@campoAlterado", "Nome Funcionário");
                htParametros.Add("@dtHrAlteracao", DateTime.Now);

                AlteracaoTransacao.IncluirAlteracao(htParametros);
            }

            if (Convert.ToDateTime(dttFuncionario.Rows[0]["dtAdmissao"]) != Convert.ToDateTime(htParametros["@dtAdmissao"]))
            {
                htParametros.Add("@valorAntigo", dttFuncionario.Rows[0]["dtAdmissao"]);
                htParametros.Add("@valorNovo", htParametros["@dtAdmissao"]);
                htParametros.Add("@campoAlterado", "Data de admissão");
                htParametros.Add("@dtHrAlteracao", DateTime.Now);

                AlteracaoTransacao.IncluirAlteracao(htParametros);
            }

            if (dttFuncionario.Rows[0]["idCargo"].ToString() != htParametros["@idCargo"].ToString())
            {
                htParametros.Add("@valorAntigo", dttFuncionario.Rows[0]["idCargo"]);
                htParametros.Add("@valorNovo", htParametros["@idCargo"]);
                htParametros.Add("@campoAlterado", "Cargo");
                htParametros.Add("@dtHrAlteracao", DateTime.Now);

                AlteracaoTransacao.IncluirAlteracao(htParametros);
            }
        }
        #endregion

        #region ExibirFuncionarios
        public static DataTable ExibirFuncionarios()
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"SELECT *, CONCAT(idFuncionario, ' ', nomeFuncionario) AS idNome FROM Funcionario f
                            INNER JOIN Cargo c
                            ON f.idCargo = c.idCargo
                            WHERE statusFuncionario = 1";

            return dados.ExecutarSelect(sql);
        }
        #endregion

        #region ExibirTodosFuncionarios
        public static DataTable ExibirTodosFuncionarios()
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"SELECT * FROM Funcionario f
                            INNER JOIN Cargo c
                            ON f.idCargo = c.idCargo";

            return dados.ExecutarSelect(sql);
        }
        #endregion

        #region ObterFuncionarioPorId
        public static DataTable ObterFuncionarioPorId(int idFuncionario)
        {
            AcessarDados dados = new AcessarDados();
            string sql = @"SELECT * FROM Funcionario f
                            WHERE f.idFuncionario = @idFuncionario";

            Hashtable htParametros = new Hashtable();
            htParametros.Add("@idFuncionario", idFuncionario);

            return dados.ExecutarSelect(sql, htParametros);
        }
        #endregion

        #region DesligarFuncionario
        public static void DesligarFuncionario(int id)
        {
            AcessarDados dados = new AcessarDados();
            Hashtable htParametros = new Hashtable();
            htParametros.Add("@idFuncionario", id);

            string sql = @"UPDATE Funcionario 
                            SET statusFuncionario = 0
                            WHERE idFuncionario = @idFuncionario";

            dados.ExecutarNonQuery(sql, htParametros);
        }
        #endregion

        #region MediaSalarios
        public static DataTable MediaSalarios()
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"SELECT AVG(c.salario) AS MediaSalarios
                            FROM Funcionario f
                            INNER JOIN Cargo c 
                            ON f.idCargo = c.idCargo
                            WHERE f.statusFuncionario = 1";

            return dados.ExecutarSelect(sql);
        }
        #endregion

        #region RelatorioFuncionarios

        public static DataTable RelatorioFuncionarios()
        {
            AcessarDados dados = new AcessarDados();
            string sql = @"SELECT *, 
                            CASE 
                                WHEN f.statusFuncionario = 1 THEN 'Ativo'
                                ELSE 'Inativo'
                            END AS statusFuncionarioTexto
                            FROM Funcionario f
                            INNER JOIN Cargo c ON f.idCargo = c.idCargo    
                            LEFT JOIN Ferias fr ON f.idFuncionario = fr.idFuncionario
                            ORDER BY statusFuncionario DESC, nomeFuncionario";

            return dados.ExecutarSelect(sql);
        }
        #endregion
    }
}