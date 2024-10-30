using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _conexaoMySQL;

        public AlunoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update aluno set nome = @nome, email=@email, serie=@serie, turma=@turma," +
                                                    "telefone=@telefone, dataNasc=@dataNasc Where idAluno=@idAluno", conexao);

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = aluno.nome;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = aluno.email;
                cmd.Parameters.Add("@serie", MySqlDbType.VarChar).Value = aluno.serie;
                cmd.Parameters.Add("@turma", MySqlDbType.VarChar).Value = aluno.turma;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = aluno.telefone;
                cmd.Parameters.Add("@dataNasc", MySqlDbType.VarChar).Value = aluno.dataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@idAluno", MySqlDbType.VarChar).Value = aluno.idAluno;


                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into aluno(nome, email, serie, turma, telefone, dataNasc ) " +
                                                    "values (@nome, @email, @serie, @turma, @telefone, @dataNasc)", conexao);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = aluno.nome;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = aluno.email;
                cmd.Parameters.Add("@serie", MySqlDbType.VarChar).Value = aluno.serie;
                cmd.Parameters.Add("@turma", MySqlDbType.VarChar).Value = aluno.turma;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = aluno.telefone;
                cmd.Parameters.Add("@dataNasc", MySqlDbType.VarChar).Value = aluno.dataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from aluno where idAluno=@idAluno", conexao);
                cmd.Parameters.AddWithValue("@idAluno", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Aluno> ObterTodosAlunos()
        {
            List<Aluno> alunoList = new List<Aluno>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from aluno", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    alunoList.Add(
                        new Aluno
                        {
                            idAluno = Convert.ToInt32(dr["idAluno"]),
                            nome = (string)dr["nome"],
                            email = (string)dr["email"],
                            serie = (string)dr["serie"],
                            turma = (string)dr["turma"],
                            telefone = (string)dr["telefone"],
                            dataNasc = Convert.ToDateTime(dr["dataNasc"])
                        });
                }
                return alunoList;
            }
        }

        public Aluno ObterAluno(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from aluno " +
                                                    "where idAluno = @idAluno", conexao);
                cmd.Parameters.AddWithValue("@idAluno", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Aluno aluno = new Aluno();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    aluno.idAluno = Convert.ToInt32(dr["idAluno"]);
                    aluno.nome = (string)dr["nome"];
                    aluno.email = (string)dr["email"];
                    aluno.serie = (string)dr["serie"];
                    aluno.turma = (string)dr["turma"];
                    aluno.telefone = (string)dr["telefone"];
                    aluno.dataNasc = Convert.ToDateTime(dr["dataNasc"]);
                }
                return aluno;
            }
        }
    }
}
