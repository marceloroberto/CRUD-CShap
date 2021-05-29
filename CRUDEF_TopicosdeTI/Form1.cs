using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity; // Declarando a variável do Entity Framework

namespace CRUDEF_TopicosdeTI
{
    public partial class Form1 : Form
    {

        void limpar()
        {
            tb_nome.Clear();
            tb_sobrenome.Clear();
            tb_cidade.Clear();
            tb_endereco.Clear();
            tb_nome.Focus();
            b_salvar.Text = "Salvar";
            cli.cli_codigo = 0;
        }

        void preenchegrid()
        {
            grid.AutoGenerateColumns = false;
            using (DBEntidade db = new DBEntidade())
            {
                grid.DataSource = db.Cliente.ToList<Cliente>();
            }
        }

        Cliente cli = new Cliente(); // Faz a instância do banco

        public Form1()
        {
            InitializeComponent();
        }

        private void b_cancelar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            limpar();
            preenchegrid();
        }

        private void b_salvar_Click(object sender, EventArgs e)
        {
            cli.cli_nome = tb_nome.Text.Trim();
            cli.cli_sobrenome = tb_sobrenome.Text.Trim();
            cli.cli_cidade = tb_cidade.Text.Trim();
            cli.cli_endereco = tb_endereco.Text.Trim();

            DBEntidade db = new DBEntidade();

            if (cli.cli_codigo == 0)
                db.Cliente.Add(cli);
            else            
                db.Entry(cli).State = EntityState.Modified; // Colocar a biblioteca using System.Data.Entity;
            db.SaveChanges();

            limpar();
            preenchegrid();

            MessageBox.Show("Dados gravados com sucesso");

        }
    }
}
