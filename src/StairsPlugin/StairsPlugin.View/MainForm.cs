namespace StairsPlugin.View
{
    using System;
    using System.Collections.Generic;
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

        private readonly Dictionary<NumericUpDown, string> _numericUpDownError;

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _numericUpDownError = new Dictionary<NumericUpDown, string>
            {
                { StairsHeightNumericUpDown, "" },
                { StairsWidthNumericUpDown, "" },
                { StairsThicknessNumericUpDown, "" },
                { StringerWidthNumericUpDown, "" },
                { StepLengthNumericUpDown, "" }
            };
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _builder.BuildStairs(_parameters);
            /*MessageBox.Show("Ширина балки W1: Значение не принадлежит диапазону допустимых значений.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.Width,
                (int)StairsWidthNumericUpDown.Value);

            StepLengthNumericUpDown.Value =
                _parameters.GetValue(StairsParameterType.StepLength);

            StringerWidthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StringerWidth)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StringerWidth)}мм".ToString();

            StepLengthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StepLength)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StepLength)}мм".ToString();
        }

        private void StairsHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _parameters.SetValue(
                    StairsParameterType.Height,
                    (int)StairsHeightNumericUpDown.Value);
                StairsHeightNumericUpDown.BackColor = _defaultBackColor;
            }
            catch (ArgumentException exception)
            {
                StairsHeightNumericUpDown.BackColor = _defaultBackColor;
                _numericUpDownError[StairsHeightNumericUpDown] = exception.Message;
            }
        }

        private void StairsWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.Width,
                (int)StairsWidthNumericUpDown.Value);

            StepLengthNumericUpDown.Value =
                _parameters.GetValue(StairsParameterType.StepLength);

            StringerWidthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StringerWidth)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StringerWidth)}мм".ToString();

            StepLengthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StepLength)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StepLength)}мм".ToString();
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

            StringerWidthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StringerWidth)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StringerWidth)}мм".ToString();

            StepLengthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StepLength)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StepLength)}мм".ToString();
        }

        private void StepLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _parameters.SetValue(
                StairsParameterType.StepLength,
                (int)StepLengthNumericUpDown.Value);

            StairsWidthNumericUpDown.Value =
                _parameters.GetValue(StairsParameterType.Width);

            StringerWidthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StringerWidth)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StringerWidth)}мм".ToString();

            StepLengthLimitLabel.Text =
                $"{_parameters.GetMinValue(StairsParameterType.StepLength)}-".ToString()
                + $"{_parameters.GetMaxValue(StairsParameterType.StepLength)}мм".ToString();
        }
    }
}
