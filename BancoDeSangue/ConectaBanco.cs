using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace BancoDeSangue
{
    class ConectaBanco
    {
        MySqlConnection conexao=new MySqlConnection("server=localhost;user id=root;password=Projetosangue123;database=sisbancosangue");
        public string mensagem;
        public DataTable listanomes ()
        {
            MySqlCommand cmd = new MySqlCommand("lista_nomes", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_nomes 
        public bool insereNome(Nomes n)
        {
            MySqlCommand cmd = new MySqlCommand("insere_nome", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", n.Nome);
            cmd.Parameters.AddWithValue("sexo", n.Sexo);
            cmd.Parameters.AddWithValue("tipo_sanguineo", n.Tipo_sanguineo);
            cmd.Parameters.AddWithValue("endereco", n.Endereco);
            cmd.Parameters.AddWithValue("telefone", n.Telefone);
            try
            {
                conexao.Open (); //executa o comando
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            { 
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }

        } // fim insereNome

         public bool deletaNome(int idbancosangue)
        {
            MySqlCommand cmd = new MySqlCommand("deleta_nome", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idbancosangue", idbancosangue);
            try
            {
                conexao.Open (); //executa o comando
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            { 
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }

        } // fim DeletaNome

        public bool AlteraNome(Nomes n, int idbancosangue)
        {
            MySqlCommand cmd = new MySqlCommand("altera_nome", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", idbancosangue);
            cmd.Parameters.AddWithValue("nome", n.Nome);
            cmd.Parameters.AddWithValue("sexo", n.Sexo);
            cmd.Parameters.AddWithValue("tipo_sanguineo", n.Tipo_sanguineo);
            cmd.Parameters.AddWithValue("endereco", n.Endereco);
            cmd.Parameters.AddWithValue("telefone", n.Telefone);
            try
            {
                conexao.Open(); //executa o comando
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }

        } // fim DeletaNome

    }
}
