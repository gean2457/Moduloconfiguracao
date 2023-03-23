

using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario, string _confirmacaoDaSenha)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario(Nome,NomeUsuario,Email, CPF, Ativo, Senha)
                                VALUES(@Nome,@NomeUsuario,@Email,@CPF,@Ativo,@Senha)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar inserir um usuario no banco de dados: ", ex);
            }
              finally
            {
                cn.Close();
            }

        }
        public List<Usuario> BuscarTodos()
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id , Nome,NomeUsuario,Email, CPF, Ativo, Senha FROM Usuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);
                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu um erro ao tentar buscar todos os usuarios no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public Usuario BuscarPorNomeUsuario(string _NomeUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id , Nome,NomeUsuario,Email, CPF, Ativo, Senha FROM Usuario WHERE NomeUsuario = @NomeUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeUsuario", _NomeUsuario);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                       


                    }
                }
                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao tentar buscar por Nome usuario ", ex);
            }
            finally { 
                cn.Close(); 
            }
        }
        public Usuario BuscarPorId(int _Id)
        {

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id , Nome,NomeUsuario,Email, CPF, Ativo, Senha FROM Usuario WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _Id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();
                        

                    }
                }
                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao tentar buscar por id ",ex);
            }
             finally
            {
                cn.Close();
            }
        }
        public void Alterar(Usuario _usuario, string _confirmacaoDaSenha)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "UPDATE Usuario SET Nome = @Nome, NomeUsuario = @NomeUsuario, Email = @Email , CPF = @CPF , Ativo = @Ativo , Senha = @Senha WHERE Id = @Id ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@ID", _usuario.Id);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar alterar um usuario no banco de dados: ", ex);
            }
             finally
            {
                cn.Close();
            }
        }

        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Usuario WHERE Id = @Id";
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
             finally
            {
                cn.Close();
            }
        }

           public Usuario BuscarPorCPF(string _cPF)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            Usuario usuario = new Usuario();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id , Nome,NomeUsuario,Email, CPF, Ativo, Senha FROM Usuario WHERE CPF = @CPF";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@CPF", _cPF);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();


                    }
                }
                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao tentar buscar por id ", ex);
            }
        }
              public List<Usuario> BuscarPorNome(string _nome)
        {
             List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id , Nome,NomeUsuario,Email, CPF, Ativo, Senha FROM Usuario WHERE Nome LIKE @Nome";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nome","%" + _nome + "%");
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(rd["ID"]);
                        usuario.Nome = rd["Nome"].ToString();
                        usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                        usuario.Email = rd["Email"].ToString();
                        usuario.CPF = rd["CPF"].ToString();
                        usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                        usuario.Senha = rd["Senha"].ToString();


                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu um erro ao tentar buscar por Nome",ex);
            }
            finally
            {
                cn.Close();
            }

        }

        public void AdicionarGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO UsuarioGrupoUsuario(IdUsuario,IdGrupoUsuario)
                                VALUES(@IdUsuario,@IdGrupoUsuario)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", _idUsuario);
                cmd.Parameters.AddWithValue("@IdGrupoUsuario", _idGrupoUsuario);
               
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar inserir um usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public bool UsuarioPertenceAoGrupo(int _idUsuario, int _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

          
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT 1 FROM UsuarioGrupoUsuario Where IdUsuario = @IdUsuario AND IdGrupoUsuario = @IdGrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdGrupoUsuario", _idGrupoUsuario);
                cmd.Parameters.AddWithValue("@IdUsuario", _idUsuario);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return true;

                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("ocorreu um erro ao tentar existencia de grupoi vinculado ao usuario no banco de dados ", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void RemoverGrupousuario(int _idUsuario, int _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM UsuarioGrupoUsuario WHERE IdUsuario = @IdUsuario AND IdGrupoUsuario = @IdGrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", _idUsuario);
                cmd.Parameters.AddWithValue("@IdGrupoUsuario", _idGrupoUsuario);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw new Exception("ocorreu erro ao tentar remover um grupo do usuario no banco de dados: ", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
    }





