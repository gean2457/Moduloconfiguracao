

using Models;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class PermissaoDAL
    {
        public void Inserir(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Permissao(Descricao)
                                VALUES(@Descricao)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Descricrao", _permissao.Descricao);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery(); 


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar inserir um usuario no banco de dados: ", ex);
            }
        }
        public List<Permissao> BuscarTodos()
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<Permissao> permissaos = new List<Permissao>();
            Permissao permissao;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id , Descricao FROM Permissao";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        permissao = new Permissao();
                        permissao.Id = Convert.ToInt32(rd["ID"]);
                       permissao.Descricao = rd["Descricao"].ToString();
                        permissaos.Add(permissao);

                    }
                }
                return permissaos;
            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu um erro ao tentar buscar todos os NomeGrupo banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<Permissao> permissaos = new List<Permissao>();
            Permissao permissao;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Desacricao FROM Permissao WHERE Descricao = @Descricao";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Descricao", _descricao);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                       permissao = new Permissao();
                        permissao.Id = Convert.ToInt32(rd["ID"]);
                        permissao.Descricao = rd["Descricao"].ToString();
                        permissaos.Add(permissao);

                    }
                }
                return permissaos;
            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu um erro ao tentar buscar por Descricao no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao> BuscarPorId(int _Id)
        {

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<Permissao> permissaos = new List<Permissao>();
            Permissao permissao;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id , Descricao FROM Permissao WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _Id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        permissao = new Permissao();
                        permissao.Id = Convert.ToInt32(rd["ID"]);
                        permissao.Descricao = rd["Descricao"].ToString();
                        permissaos.Add(permissao);

                    }
                }
                return permissaos;
            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu um erro ao tentar buscar por ID no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Alterar(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "UPDATE Permissao SET Descricao = @Descricao WHERE Id = @Id ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _permissao.Descricao);
                cmd.Parameters.AddWithValue("@ID", _permissao.Id);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar alterar uma permissao no banco de dados: ", ex);
            }
        }
        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Permissao WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", _id);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar excluir uma permissao no banco de dados: ", ex);
            }
        }
    }
}
