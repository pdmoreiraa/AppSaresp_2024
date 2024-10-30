using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class ProfessorAplicadorRepository : IProfessorAplicadorRepository
    {
        private readonly string _conexaoMySQL;

        public ProfessorAplicadorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(ProfessorAplicador professorAplicador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update professorAplicador set nome = @nome, CPF=@CPF, RG=@RG," +
                                                    "telefone=@telefone, dataNasc=@dataNasc Where idProfessor=@idProfessor", conexao);

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = professorAplicador.nome;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = professorAplicador.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professorAplicador.RG;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = professorAplicador.telefone;
                cmd.Parameters.Add("@dataNasc", MySqlDbType.VarChar).Value = professorAplicador.dataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@idProfessor", MySqlDbType.VarChar).Value = professorAplicador.idProfessor;


                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(ProfessorAplicador professorAplicador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into professorAplicador(nome, CPF, RG, telefone, dataNasc) " +
                                                    "values (@nome, @CPF, @RG, @telefone, @dataNasc)", conexao);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = professorAplicador.nome;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = professorAplicador.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professorAplicador.RG;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = professorAplicador.telefone;
                cmd.Parameters.Add("@dataNasc", MySqlDbType.VarChar).Value = professorAplicador.dataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from professorAplicador where idProfessor=@idProfessor", conexao);
                cmd.Parameters.AddWithValue("@idProfessor", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<ProfessorAplicador> ObterTodosProfessores()
        {
            List<ProfessorAplicador> professorList = new List<ProfessorAplicador>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from professorAplicador", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    professorList.Add(
                        new ProfessorAplicador
                        {
                            idProfessor = Convert.ToInt32(dr["idProfessor"]),
                            nome = (string)dr["nome"],
                            CPF = (string)dr["CPF"],
                            RG = (string)dr["RG"],
                            telefone = (string)dr["telefone"],
                            dataNasc = Convert.ToDateTime(dr["dataNasc"]),
                        });
                }
                return professorList;
            }
        }

        public ProfessorAplicador ObterProfessor(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from professorAplicador " +
                                                    "where idProfessor = @idProfessor", conexao);
                cmd.Parameters.AddWithValue("@idProfessor", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                ProfessorAplicador professorAplicador = new ProfessorAplicador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    professorAplicador.idProfessor = Convert.ToInt32(dr["idProfessor"]);
                    professorAplicador.nome = (string)dr["nome"];
                    professorAplicador.CPF = (string)dr["CPF"];
                    professorAplicador.RG = (string)dr["RG"];
                    professorAplicador.telefone = (string)dr["telefone"];
                    professorAplicador.dataNasc = Convert.ToDateTime(dr["dataNasc"]);
                }
                return professorAplicador;
            }
        }
    }
}
