using System;
using System.Collections;
using System.Data;

namespace ControleFuncionarios.Transacao
{
    public class CargoTransacao
    {
        public static void IncluirCargo(Hashtable htParametros)
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"INSERT INTO Cargo (nomeCargo, salario)
                            VALUES (@nomeCargo, @salario)";

            dados.ExecutarNonQuery(sql, htParametros);
        }

        public static void ExcluirCargo(int idCargo)
        {
            AcessarDados dados = new AcessarDados();

            Hashtable htParametros = new Hashtable();
            htParametros.Add("@idCargo", idCargo);
             
            string sql = @"DELETE FROM Cargo
                            WHERE idCargo = @idCargo";

            dados.ExecutarNonQuery(sql, htParametros);
        }

        public static void AtualizarCargo(Hashtable htParametros)
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"UPDATE Cargo
                            SET nomeCargo = @nomeCargo,
                                salario = @salario
                            WHERE idCargo = @idCargo";
            dados.ExecutarNonQuery(sql, htParametros);
        }
        public static DataTable ObterCargos()
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"SELECT idCargo, nomeCargo
                            FROM Cargo";

            return dados.ExecutarSelect(sql);
        }

        public static DataTable ObterCargosSalario()
        {
            AcessarDados dados = new AcessarDados();

            string sql = @"SELECT c.idCargo, c.nomeCargo, c.salario,
                            COUNT(f.idFuncionario) AS quantidadeFuncionarios
                            FROM Cargo c
                            LEFT JOIN Funcionario f ON f.idCargo = c.idCargo
                            GROUP BY c.idCargo, c.nomeCargo, c.salario;";

            return dados.ExecutarSelect(sql);
        }

        public static DataTable ObterCargoPorId(int idCargo)
        {
            AcessarDados dados = new AcessarDados();

            Hashtable htParametros = new Hashtable();
            htParametros.Add("@idCargo", idCargo);

            string sql = @"SELECT * FROM Cargo c
                            WHERE c.idCargo = @idCargo";
            
            return dados.ExecutarSelect(sql, htParametros);
        }

        public static bool CargoPossuiFuncionarios(int idCargo)
        {
            AcessarDados dados = new AcessarDados();
            Hashtable htParametros = new Hashtable();
            htParametros.Add("@idCargo", idCargo);

            string sql = @"SELECT COUNT(*) 
                   FROM Funcionario
                   WHERE idCargo = @idCargo AND statusFuncionario = 1";

            int qtd = Convert.ToInt32(dados.ExecutarScalar(sql, htParametros));

            return qtd > 0;
        }
    }
}