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
        private readonly Color _errorBackColor = Color.LightCoral;

        /// <summary>
        /// Стандартный цвет numericUpDown.
        /// </summary>
        private readonly Color _defaultBackColor = Color.White;

        /// <summary>
        /// Словарь ошибок.
        /// </summary>
        private readonly Dictionary<NumericUpDown, string> _numericUpDownError;

        /// <summary>
        /// Словарь NumericUpDown.
        /// </summary>
        private readonly Dictionary<NumericUpDown, StairsParameterType> _numericUpDown;

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

            _numericUpDown = new Dictionary<NumericUpDown, StairsParameterType>
            {
                { StairsHeightNumericUpDown, StairsParameterType.Height },
                { StairsWidthNumericUpDown, StairsParameterType.Width },
                { StairsThicknessNumericUpDown, StairsParameterType.Thickness },
                { StringerWidthNumericUpDown, StairsParameterType.StringerWidth },
                { StepLengthNumericUpDown, StairsParameterType.StepLength }
            };
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            _builder.BuildStairs(_parameters);
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;

            switch (numericUpDown.Name)
            {
                case "StairsHeightNumericUpDown":
                {
                    try
                    {
                        _parameters.SetValue(
                            StairsParameterType.Height,
                            (int)numericUpDown.Value);
                        numericUpDown.BackColor = _defaultBackColor;
                    }
                    catch (ArgumentException exception)
                    {
                        numericUpDown.BackColor = _errorBackColor;
                        _numericUpDownError[numericUpDown] = exception.Message;
                    }

                    break;
                }

                case "StairsWidthNumericUpDown":
                {
                    _parameters.SetValue(
                        StairsParameterType.Width,
                        (int)numericUpDown.Value);

                    StepLengthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.StepLength);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        StairsParameterType.StringerWidth);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        StairsParameterType.StepLength);
                    break;
                }

                case "StairsThicknessNumericUpDown":
                {
                    _parameters.SetValue(
                        StairsParameterType.Thickness,
                        (int)numericUpDown.Value);
                    break;
                }

                case "StringerWidthNumericUpDown":
                {
                    SetParameterValue(numericUpDown);

                    StairsWidthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.Width);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        _numericUpDown[numericUpDown]);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        StairsParameterType.StepLength);
                    break;
                }

                case "StepLengthNumericUpDown":
                {
                    _parameters.SetValue(
                        StairsParameterType.StepLength,
                        (int)numericUpDown.Value);

                    StairsWidthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.Width);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        StairsParameterType.StringerWidth);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        StairsParameterType.StepLength);
                    break;
                }
            }
        }

        private void SetParameterValue(NumericUpDown numericUpDown)
        {
            try
            {
                _parameters.SetValue(
                    _numericUpDown[numericUpDown],
                    (int)numericUpDown.Value);
                numericUpDown.BackColor = _defaultBackColor;
                _numericUpDownError[numericUpDown] = "";
            }
            catch (ArgumentException exception)
            {
                numericUpDown.BackColor = _errorBackColor;
                _numericUpDownError[numericUpDown] = exception.Message;
            }
        }

        private void ChangeLimitLabelText(
            Label label,
            StairsParameterType type)
        {
            label.Text = $"{_parameters.GetMinValue(type)}-".ToString()
                         + $"{_parameters.GetMaxValue(type)}мм".ToString();
        }
    }
}
