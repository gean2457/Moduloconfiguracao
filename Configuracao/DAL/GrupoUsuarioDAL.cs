

using Models;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace DAL
{
    public class GrupoUsuarioDAL
    {
        public void Inserir(GrupoUsuario _grupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO GRupoUsuario(NomeGrupo)
                                VALUES(@NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario.NomeGrupo);
                
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar inserir um usuario no banco de dados: ", ex);
            }
        }
        public List<GrupoUsuario> BuscarTodos()
        {
            throw new NotImplementedException();
        }
        public List<GrupoUsuario> BuscarPorNomeUsuario()
        {
            throw new NotImplementedException();
        }
        public List<GrupoUsuario> BuscarPorId(int _Id)
        {
            throw new NotImplementedException();
        }
        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "UPDATE GrupoUsuario SET NomeGrupo = @NomeGrupo WHERE Id = @Id ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _grupoUsuario.NomeGrupo);
                cmd.Parameters.AddWithValue("@ID", _grupoUsuario.Id);
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
                cmd.CommandText = "DELETE FROM GrupoUsuario WHERE Id = @Id";
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
