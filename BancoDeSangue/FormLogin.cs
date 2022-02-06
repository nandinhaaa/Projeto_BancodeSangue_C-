using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BancoDeSangue
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "bancodesangue"&txtSenha.Text == "1234")
            {
                Sistema sis = new Sistema();
                sis.Show();
            }// fim if
            else
                MessageBox.Show("Chave de acesso incorreta!");
        }
    }
}
