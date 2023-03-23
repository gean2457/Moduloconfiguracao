using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario , string _confirmacaoDaSenha)
        {
            ValidarDados(_usuario, _confirmacaoDaSenha);
             UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario, _confirmacaoDaSenha);
           // pode ser usada essas duas formas
           //new UsuarioDAL().Inserir(_usuario);
            
            
            
        }
        public void Alterar(Usuario _usuario, string _confirmacaoDaSenha)
        {
            ValidarDados(_usuario , _confirmacaoDaSenha);
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario, _confirmacaoDaSenha);

        }

        public void Excluir(int _Id)
        {
            new UsuarioDAL().Excluir(_Id);
        }
         public List<Usuario> BuscarTodos()
        {
             return new UsuarioDAL().BuscarTodos(); 
        }
          public Usuario BuscarPorId(int _Id)
        {
            return new UsuarioDAL().BuscarPorId(_Id);
        }
         public Usuario BuscarPorCPF(string _cPF)
        {
            return new UsuarioDAL().BuscarPorCPF(_cPF);
        }
         public List<Usuario> BuscarPorNome(string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
          public Usuario BuscarPorNomeUsuario(string _nomeusuario)
        {
            return new UsuarioDAL().BuscarPorNomeUsuario(_nomeusuario);
        }
         private void ValidarDados(Usuario _usuario , string _confirmacaoDaSenha)
        {
            if (_usuario.Senha != _confirmacaoDaSenha)
                throw new Exception("A senha e a validação da senha devem ser iguais.");
            if (_usuario.Senha.Length <= 3)
                throw new Exception("a senha deve ter mais de 3 caracteres");
           
             if(_usuario.Nome.Length<= 2)
                throw new Exception("O nome deve ter mais de 2 caracteres.");
        }

        public void AdicionarGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            if(!new UsuarioDAL().UsuarioPertenceAoGrupo(_idUsuario,_idGrupoUsuario))
            new UsuarioDAL().AdicionarGrupoUsuario(_idUsuario, _idGrupoUsuario);
        }

        public void RemoverGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            new UsuarioDAL().RemoverGrupousuario(_idUsuario, _idGrupoUsuario);
        }
        
    }
}
