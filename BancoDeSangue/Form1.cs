using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeSangue
{
    public partial class Sistema : Form
    {
        int idAlterar;
        public Sistema()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PainelCentro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btMaximizar.Visible = false;
            btRestaurar.Visible = true;
        }

        private void btRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btRestaurar.Visible = false;
            btMaximizar.Visible = true;
        }

        private void btMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Titulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        void listaDGNomes()
        {
            ConectaBanco con = new ConectaBanco();
            dgNomes.DataSource = con.listanomes();
            lblMensagem.Text = con.mensagem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                listaDGNomes();

            }

        }

        private void bntConfirma_Click(object sender, EventArgs e)
        {
            Nomes n = new Nomes();
            //tNomes n [100];
            n.Nome = txtnome.Text;
            n.Sexo = txtsexo.Text;
            n.Tipo_sanguineo = txttipo_sanguineo.Text;
            n.Endereco = txtendereco.Text;
            n.Telefone = txttelefone.Text;
            ConectaBanco con = new ConectaBanco();
            bool r = con.insereNome(n);
            if (r == true)
            {
                MessageBox.Show("Dados adicionados com sucesso! :)");
                listaDGNomes();
                limpaCampos();
                txtnome.Focus(); // cursor vai para o txtnome
            }
            else
                lblMensagem.Text = con.mensagem;

            void limpaCampos()
            {
                txtnome.Clear();
                txtsexo.Clear();
                txttipo_sanguineo.Clear();
                txtendereco.Clear();
                txttelefone.Clear();
            }// fim limpa campos

        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgNomes.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("nome like '{0}%'", txtBusca.Text);
        }

        private void bntRemove_Click_1(object sender, EventArgs e)
        {
            {
                int linha = dgNomes.CurrentRow.Index;
                int id = Convert.ToInt32(
                        dgNomes.Rows[linha].Cells["idbancodesangue"].Value.ToString());
                DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                    "Remove Nome", MessageBoxButtons.OKCancel);
                if (resp == DialogResult.OK)
                {
                    ConectaBanco con = new ConectaBanco();
                    bool retorno = con.deletaNome(id);
                    if (retorno == true)
                    {
                        MessageBox.Show("Nome excluído com sucesso!");
                        listaDGNomes();
                    }// fim if retorno true
                    else
                        MessageBox.Show(con.mensagem);
                }// fim if Ok Cancela
                else
                    MessageBox.Show("Exclusão cancelada");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgNomes.CurrentRow.Index;
            idAlterar = Convert.ToInt32(
                    dgNomes.Rows[linha].Cells["idbancodesangue"].Value.ToString());
            txtAlteraNome.Text = dgNomes.Rows[linha].Cells["nome"].Value.ToString();
            txtAlteraSexo.Text = dgNomes.Rows[linha].Cells["sexo"].Value.ToString();
            txtAlteraTipoSanguineo.Text = dgNomes.Rows[linha].Cells["tipo_sanguineo"].Value.ToString();
            txtAlteraEndereco.Text = dgNomes.Rows[linha].Cells["endereco"].Value.ToString();
            txtAlteraTelefone.Text = dgNomes.Rows[linha].Cells["telefone"].Value.ToString();
            tabControl.SelectedTab = tabAlterar;
        }

        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            Nomes n = new Nomes();
            n.Nome = txtAlteraNome.Text;
            n.Sexo = txtAlteraSexo.Text;
            n.Tipo_sanguineo = txtAlteraTipoSanguineo.Text;
            n.Endereco = txtAlteraEndereco.Text;
            n.Telefone = txtAlteraTelefone.Text;
            ConectaBanco con = new ConectaBanco();
            bool ret = con.AlteraNome(n, idAlterar);
            if (ret == true)
            {
                MessageBox.Show("Dados alterados com sucesso!");
                listaDGNomes();
                tabControl.SelectedTab = tabBuscar;
            }// fim if true
            else
                MessageBox.Show(con.mensagem);
        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
