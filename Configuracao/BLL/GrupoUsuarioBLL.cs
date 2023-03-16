
using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class GrupoUsuarioBLL
    {
        public void Inserir(GrupoUsuario _grupousuario)
        {
            ValidarDados(_grupousuario);
            GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
            grupoUsuarioDAL.Inserir(_grupousuario);
            
        }
         public void Alterar(GrupoUsuario grupoUsuario)
        {
            ValidarDados(grupoUsuario);
            GrupoUsuarioDAL grupoUsuarioDAL = new GrupoUsuarioDAL();
            grupoUsuarioDAL.Alterar(grupoUsuario);
        }
         public void Excluir(int _Id)
        {
            new GrupoUsuarioDAL().Excluir(_Id);
        }

        public List<GrupoUsuario> BuscarTodos()
        {
            return new GrupoUsuarioDAL().BuscarTodos();
        }
          public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomeGrupo)
        {
            return new GrupoUsuarioDAL().BuscarPorNomeGrupo(_nomeGrupo);
        }
         public List<GrupoUsuario> BuscarPorId(int _Id)
        {
            return new GrupoUsuarioDAL().BuscarPorId(_Id);
        }


        private void ValidarDados(GrupoUsuario _grupoUsuario)
        {
            if (_grupoUsuario.NomeGrupo.Length <= 3)
                throw new Exception("o nome do grupo deve ter mais de 3 caracteres");

        }
    }
}
