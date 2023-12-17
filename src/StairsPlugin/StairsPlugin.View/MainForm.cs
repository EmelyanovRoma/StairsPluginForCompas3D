namespace StairsPlugin.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using StairsPlugin.KompasWrapper;
    using StairsPlugin.Model;

    /// <summary>
    /// Описывает главную форму.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Параметры лестницы.
        /// </summary>
        private readonly StairsParameters _parameters = new StairsParameters();

        /// <summary>
        /// Соединитель с API КОМПАС-3D.
        /// </summary>
        private readonly StairsBuilder _builder = new StairsBuilder();

        /// <summary>
        /// Цвет numericUpDown при наличии ошибки.
        /// </summary>
        private readonly Color _errorBackColor = Color.LightPink;

        /// <summary>
        /// Стандартный цвет numericUpDown.
        /// </summary>
        private readonly Color _defaultBackColor = Color.White;

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _builder.BuildStairs(_parameters);
            /*MessageBox.Show("Ширина балки W1: Значение не принадлежит диапазону допустимых значений.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        }

        private void StairsHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.Height,
                (int)StairsHeightNumericUpDown.Value);
        }

        private void StairsWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.Width,
                (int)StairsWidthNumericUpDown.Value);

            StepLengthNumericUpDown.Value =
                _parameters.GetValue(StairsParameterType.StepLength);
        }

        private void StairsThicknessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.Thickness,
                (int)StairsThicknessNumericUpDown.Value);
        }

        private void StringerWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.StringerWidth,
                (int)StringerWidthNumericUpDown.Value);

            StairsWidthNumericUpDown.Value =
                _parameters.GetValue(StairsParameterType.Width);
        }

        private void StepLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.StepLength,
                (int)StepLengthNumericUpDown.Value);

            StairsWidthNumericUpDown.Value =
                _parameters.GetValue(StairsParameterType.Width);
        }
    }
}
