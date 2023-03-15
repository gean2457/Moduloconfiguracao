

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
            throw new NotImplementedException();
        }
        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            throw new NotImplementedException();
        }
        public List<Permissao> BuscarPorId(int _Id)
        {
            throw new NotImplementedException();
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

                throw new Exception("ocorreu erro ao tentar inserir um usuario no banco de dados: ", ex);
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

                throw new Exception("ocorreu erro ao tentar excluir um usuario no banco de dados: ", ex);
            }
        }
    }
}
