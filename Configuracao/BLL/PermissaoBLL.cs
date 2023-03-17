using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PermissaoBLL
    {
       public void Inserir(Permissao _permissao)
        {
            ValidarDados(_permissao);
            PermissaoDAL permissaoDAL = new PermissaoDAL();
              permissaoDAL.Inserir(_permissao);
        }
         public void Alterar(Permissao _permissao)
        {
            ValidarDados(_permissao);
            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Alterar(_permissao);    
        }
         public void Excluir(int _Id)
        {
            new PermissaoDAL().Excluir(_Id);
        }
        public List<Permissao> BuscarPorTodos()
        {
            return new PermissaoDAL().BuscarTodos();
        }
        public List<Permissao> BuscarPorDescricao(string _descricrao)
        {
            return new PermissaoDAL().BuscarPorDescricao(_descricrao);
        }
         public List<Permissao> BuscarPorId(int _Id)
        {
            return new PermissaoDAL().BuscarPorId(_Id);
        }
         private void ValidarDados(Permissao _permissao)
        {
            if (_permissao.Descricao.Length <= 3)
                throw new Exception("Os caracteres nao pode ser menor que 3 ");
        }
    }
}
