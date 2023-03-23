using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.DataSource = new UsuarioBLL().BuscarTodos();
        }

        private void buttonExcluirUsuario_Click(object sender, EventArgs e)
        {
            if (usuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Nao existe registro para ser excluir. ");
                return;
            }

            if (MessageBox.Show("deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int Id = ((Usuario)usuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(Id);
            usuarioBindingSource.RemoveCurrent();
            MessageBox.Show("registro excluido com sucesso!");
        }

        private void buttonAdicionarUsuario_Click(object sender, EventArgs e)
        {
            using (FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
              buttonBuscar_Click(null, null);
        }

        private void buttonAltear_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)usuarioBindingSource.Current).Id;
            using (FormCadastroUsuario frm = new FormCadastroUsuario(id))
            {
                frm.ShowDialog();
            }
             buttonBuscar_Click(null,null);
        }

        private void buttonadicianarGrupoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioBindingSource.Count == 0)
                    throw new Exception("Não existe usuário selecionado para adicionar um grupo.");

                using (Form1ConsultaGrupoUsuariocs frm = new Form1ConsultaGrupoUsuariocs())
                {
                    frm.ShowDialog();
                    if (frm.Id != 0)
                    {
                        int idUsuario = ((Usuario)usuarioBindingSource.Current).Id;
                        new UsuarioBLL().AdicionarGrupoUsuario(idUsuario,frm.Id);
                    }
                }
                buttonBuscar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExcluirGrupoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                int idGrupoUsuario = ((GrupoUsuario)grupoUsuariosBindingSource.Current).Id;
                int IdUsuario = ((Usuario)usuarioBindingSource.Current).Id;
                new UsuarioBLL().RemoverGrupoUsuario(IdUsuario, idGrupoUsuario);
                grupoUsuariosBindingSource.RemoveCurrent();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
