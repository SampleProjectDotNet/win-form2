using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace win_form.test
{
    [TestClass]
    public class SimpleWinFormsAppTests
    {
        [TestMethod]
        public void Form_ShouldHaveCorrectTitle()
        {
            // Arrange
            Form form = CreateCalculadoraForm();

            // Act
            string formTitle = form.Text;

            // Assert
            Assert.AreEqual("Calculadora Simples", formTitle);
        }

        [TestMethod]
        public void Form_ShouldHaveCorrectControls()
        {
            // Arrange
            Form form = CreateCalculadoraForm();

            // Act & Assert
            Assert.AreEqual(9, form.Controls.Count);
            Assert.IsTrue(form.Controls.OfType<TextBox>().Count() == 2);
            Assert.IsTrue(form.Controls.OfType<Button>().Count() == 4);
            Assert.IsTrue(form.Controls.OfType<Label>().Count() == 3);
        }

        [TestMethod]
        public void SomarButton_ShouldCalculateCorrectly()
        {
            // Arrange
            Form form = CreateCalculadoraForm();
            TextBox txtNumero1 = form.Controls.OfType<TextBox>().First();
            TextBox txtNumero2 = form.Controls.OfType<TextBox>().Last();
            Button btnSomar = form.Controls.OfType<Button>().First(b => b.Text == "Somar");
            Label lblResultado = form.Controls.OfType<Label>().First(l => l.BorderStyle == BorderStyle.FixedSingle);

            // Act
            txtNumero1.Text = "10";
            txtNumero2.Text = "5";
            btnSomar.PerformClick();

            // Assert
            Assert.AreEqual("Resultado: 15", lblResultado.Text);
        }

        [TestMethod]
        public void SubtrairButton_ShouldCalculateCorrectly()
        {
            // Arrange
            Form form = CreateCalculadoraForm();
            TextBox txtNumero1 = form.Controls.OfType<TextBox>().First();
            TextBox txtNumero2 = form.Controls.OfType<TextBox>().Last();
            Button btnSubtrair = form.Controls.OfType<Button>().First(b => b.Text == "Subtrair");
            Label lblResultado = form.Controls.OfType<Label>().First(l => l.BorderStyle == BorderStyle.FixedSingle);

            // Act
            txtNumero1.Text = "10";
            txtNumero2.Text = "5";
            btnSubtrair.PerformClick();

            // Assert
            Assert.AreEqual("Resultado: 5", lblResultado.Text);
        }

        [TestMethod]
        public void MultiplicarButton_ShouldCalculateCorrectly()
        {
            // Arrange
            Form form = CreateCalculadoraForm();
            TextBox txtNumero1 = form.Controls.OfType<TextBox>().First();
            TextBox txtNumero2 = form.Controls.OfType<TextBox>().Last();
            Button btnMultiplicar = form.Controls.OfType<Button>().First(b => b.Text == "Multiplicar");
            Label lblResultado = form.Controls.OfType<Label>().First(l => l.BorderStyle == BorderStyle.FixedSingle);

            // Act
            txtNumero1.Text = "10";
            txtNumero2.Text = "5";
            btnMultiplicar.PerformClick();

            // Assert
            Assert.AreEqual("Resultado: 50", lblResultado.Text);
        }

        [TestMethod]
        public void DividirButton_ShouldCalculateCorrectly()
        {
            // Arrange
            Form form = CreateCalculadoraForm();
            TextBox txtNumero1 = form.Controls.OfType<TextBox>().First();
            TextBox txtNumero2 = form.Controls.OfType<TextBox>().Last();
            Button btnDividir = form.Controls.OfType<Button>().First(b => b.Text == "Dividir");
            Label lblResultado = form.Controls.OfType<Label>().First(l => l.BorderStyle == BorderStyle.FixedSingle);

            // Act
            txtNumero1.Text = "10";
            txtNumero2.Text = "5";
            btnDividir.PerformClick();

            // Assert
            Assert.AreEqual("Resultado: 2", lblResultado.Text);
        }

        private Form CreateCalculadoraForm()
        {
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
            };

            btnSubtrair.Click += (sender, e) =>
            {
                if (double.TryParse(txtNumero1.Text, out double n1) && 
                    double.TryParse(txtNumero2.Text, out double n2))
                {
                    lblResultado.Text = $"Resultado: {n1 - n2}";
                }
            };

            btnMultiplicar.Click += (sender, e) =>
            {
                if (double.TryParse(txtNumero1.Text, out double n1) && 
                    double.TryParse(txtNumero2.Text, out double n2))
                {
                    lblResultado.Text = $"Resultado: {n1 * n2}";
                }
            };

            btnDividir.Click += (sender, e) =>
            {
                if (double.TryParse(txtNumero1.Text, out double n1) && 
                    double.TryParse(txtNumero2.Text, out double n2) && n2 != 0)
                {
                    lblResultado.Text = $"Resultado: {n1 / n2}";
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

            return form;
        }
    }
}