using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cadastro_clientes
{
    public partial class Form1 : Form
    {
        DateTime data_hora;
        public Form1()
        {
            InitializeComponent();
        }

        private void limparTextBoxes(Control.ControlCollection controles)
        {
            //Faz um laço para todos os controles
            foreach (Control ctrl in controles)
            {
                //Se o controle for um MaskedTextBox...
                if (ctrl is MaskedTextBox) 
                {
                    ((MaskedTextBox)(ctrl)).Text = String.Empty;
                }
                //Se o controle for um TextBox...
                else if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
                //Se o controle for um ComboBox...
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)(ctrl)).Text = String.Empty;
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Faz com que fique impossivel arrastar a borda
            FormBorderStyle = FormBorderStyle.FixedSingle;

            //Cria a pasta no diretorio X
            DirectoryInfo CriarPasta = new DirectoryInfo(@"C:\\Banco De Dados\\Cadastro Clientes");

            //Se Caso a pasta existir Returna para o FORM , caso NÃO ele cria
            if (CriarPasta.Exists)
            {
                return;

            }
            else
            {
                CriarPasta.Create();
            }

           
        }
        //Mostra a hora e data em uma LABEL 
        private void timer1_Tick(object sender, EventArgs e)
        {
            data_hora = DateTime.Now;
            lbdataehora.Text = data_hora.ToLongDateString() + " / " + data_hora.ToLongTimeString();
        }
        //Botão de Sair
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Botão para gravar cadastros
        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter arquivo;
            String caminho = "C:\\Banco De Dados\\Cadastro Clientes\\CadastroClientes.txt";
            arquivo = File.AppendText(caminho);
            arquivo.WriteLine(" ");
            arquivo.WriteLine("Nome: " + txt1.Text);           
            arquivo.WriteLine("Endereço: " + txt2.Text);          
            arquivo.WriteLine("Bairro: " + txt3.Text);
            arquivo.WriteLine("Estado: " + txt4.Text);
            arquivo.WriteLine("Telefone: " + txt5.Text);
            arquivo.WriteLine("Celular: " + txt6.Text);
            arquivo.WriteLine("Email: " + txt7.Text);
            arquivo.WriteLine("Cadastro Realizado: " + lbdataehora.Text + Environment.NewLine);
            arquivo.WriteLine("=================================================================");

            //Fecha o arquivo apos registrar as informacões no arquivo "Cadastro"
            arquivo.Close();

            //Mensagem informando que o cadastro foi realizado
            MessageBox.Show("Cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Cria um botão com dialogo para continuar , S/N
            DialogResult dialogResult = MessageBox.Show("Deseja cadastrar outro cliente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //Cria um IF para o botao acima , se caso SIM , ele returna para o FORM e o lIMPA os campos , caso NÃO ele o FECHA !
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                limparTextBoxes(this.Controls);
                return;
            }

            //Caso NÃO ele o FECHA !
            else
            { 
                Application.Exit();
            }


        }

        private void txt6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        //Botao para mostrar os Cadastros
        private void button3_Click(object sender, EventArgs e)
        {
            string caminho = "C:\\Banco De Dados\\Cadastro Clientes\\CadastroClientes.txt";
            System.Diagnostics.Process.Start("NOTEPAD", caminho);
        }
    }
    
}
