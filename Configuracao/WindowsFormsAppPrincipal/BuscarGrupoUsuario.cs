using BLL;
using Models;
using System;
using System.Windows.Forms;


namespace WindowsFormsAppPrincipal
{
    public partial class BuscarGrupoUsuario : Form
    {
        public BuscarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscarPorGRUpo_Click(object sender, EventArgs e)
        {
            grupoUsuarioBindingSource.DataSource = new GrupoUsuarioBLL().BuscarTodos();
        }

        private void buttonExcluirGrupo_Click(object sender, EventArgs e)
        {
            if(grupoUsuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Nao existe registro para ser excluido");
                return;
            }
             if(MessageBox.Show("deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int Id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            new GrupoUsuarioBLL().Excluir(Id);
            grupoUsuarioBindingSource.RemoveCurrent();
            MessageBox.Show("Registro excluido com sucesso!");
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using (FormCadastroGrupoUsuario frm = new FormCadastroGrupoUsuario())
            {
                frm.ShowDialog();
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcluirPermissao_Click(object sender, EventArgs e)
        {

        }
    }
}
