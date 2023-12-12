namespace StairsPlugin.View
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Описывает главную форму.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            /*MessageBox.Show("Ширина балки W1: Значение не принадлежит диапазону допустимых значений.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        }

        private void StairsWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
        }

        private void StringerWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
        }

        private void StepLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
