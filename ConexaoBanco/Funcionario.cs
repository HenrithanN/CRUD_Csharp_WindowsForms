using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConexaoBanco
{
    class Funcionario
    {
        SqlConnection con = new SqlConnection("Data Source=Servidor;" + "initial Catalog=Banco de Dados;" + "User id=ID;" + "password=Senha");
        SqlCommand cmd = new SqlCommand();
        public int idFuncionario { get; set; }

        public string Nome { get; set; }
        public DataTable Pesquisar()
        {
            try {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM FUNCIONARIO";
                DataTable dt = new DataTable();
                adp.SelectCommand = cmd;
                adp.Fill(dt);

                con.Close();

                return dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro desconhecido");
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        

            public bool Salvar()
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT FUNCIONARIO(IDFUNCIONARIO, NOME)" + "VALUES(@COD,@CLIENTE)";

                cmd.Parameters.AddWithValue("@COD", idFuncionario);
                cmd.Parameters.AddWithValue("@CLIENTE", Nome);
                cmd.ExecuteNonQuery();

                con.Close();


                return true;
            }
     }
}
