using System;
using System.Windows.Forms;
using System.Drawing;

namespace win_form
{
    class SimpleWinFormsApp
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Criação do formulário
            Form form = new Form
            {
                Text = "Calculadora Simples",
                Width = 300,
                Height = 250,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Criação das caixas de texto para entrada de números
            TextBox txtNumero1 = new TextBox
            {
                Location = new Point(100, 30),
                Size = new Size(100, 25)
            };

            TextBox txtNumero2 = new TextBox
            {
                Location = new Point(100, 70),
                Size = new Size(100, 25)
            };

            // Criação dos rótulos
            Label lblNumero1 = new Label
            {
                Text = "Número 1:",
                Location = new Point(30, 33),
                AutoSize = true
            };

            Label lblNumero2 = new Label
            {
                Text = "Número 2:",
                Location = new Point(30, 73),
                AutoSize = true
            };

            // Criação dos botões de operação
            Button btnSomar = new Button
            {
                Text = "Somar",
                Location = new Point(30, 110),
                Size = new Size(80, 30)
            };

            Button btnSubtrair = new Button
            {
                Text = "Subtrair",
                Location = new Point(120, 110),
                Size = new Size(80, 30)
            };

            Button btnMultiplicar = new Button
            {
                Text = "Multiplicar",
                Location = new Point(30, 150),
                Size = new Size(80, 30)
            };

            Button btnDividir = new Button
            {
                Text = "Dividir",
                Location = new Point(120, 150),
                Size = new Size(80, 30)
            };

            // Rótulo para mostrar o resultado
            Label lblResultado = new Label
            {
                Text = "Resultado: ",
                Location = new Point(30, 190),
                Size = new Size(240, 25),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Eventos dos botões
            btnSomar.Click += (sender, e) =>
            {
                if (double.TryParse(txtNumero1.Text, out double n1) && 
                    double.TryParse(txtNumero2.Text, out double n2))
                {
                    lblResultado.Text = $"Resultado: {n1 + n2}";
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos.");
                }
            };

            btnSubtrair.Click += (sender, e) =>
            {
                if (double.TryParse(txtNumero1.Text, out double n1) && 
                    double.TryParse(txtNumero2.Text, out double n2))
                {
                    lblResultado.Text = $"Resultado: {n1 - n2}";
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos.");
                }
            };

            btnMultiplicar.Click += (sender, e) =>
            {
                if (double.TryParse(txtNumero1.Text, out double n1) && 
                    double.TryParse(txtNumero2.Text, out double n2))
                {
                    lblResultado.Text = $"Resultado: {n1 * n2}";
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos.");
                }
            };

            btnDividir.Click += (sender, e) =>
            {
                if (double.TryParse(txtNumero1.Text, out double n1) && 
                    double.TryParse(txtNumero2.Text, out double n2))
                {
                    if (n2 != 0)
                    {
                        lblResultado.Text = $"Resultado: {n1 / n2}";
                    }
                    else
                    {
                        MessageBox.Show("Não é possível dividir por zero.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos.");
                }
            };

            // Adiciona os controles ao formulário
            form.Controls.Add(txtNumero1);
            form.Controls.Add(txtNumero2);
            form.Controls.Add(lblNumero1);
            form.Controls.Add(lblNumero2);
            form.Controls.Add(btnSomar);
            form.Controls.Add(btnSubtrair);
            form.Controls.Add(btnMultiplicar);
            form.Controls.Add(btnDividir);
            form.Controls.Add(lblResultado);

            // Executa a aplicação
            Application.Run(form);
        }
    }
}