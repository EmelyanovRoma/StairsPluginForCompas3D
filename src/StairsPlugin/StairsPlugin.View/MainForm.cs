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
        private readonly Dictionary<NumericUpDown, string> _numericUpDownErrors;

        /// <summary>
        /// Словарь NumericUpDown по StairsParametersType.
        /// </summary>
        private readonly Dictionary<NumericUpDown, StairsParameterType> _numericUpDownType;

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _numericUpDownErrors = new Dictionary<NumericUpDown, string>
            {
                { StairsHeightNumericUpDown, "" },
                { StairsWidthNumericUpDown, "" },
                { StairsThicknessNumericUpDown, "" },
                { StringerWidthNumericUpDown, "" },
                { StepLengthNumericUpDown, "" }
            };

            _numericUpDownType = new Dictionary<NumericUpDown, StairsParameterType>
            {
                { StairsHeightNumericUpDown, StairsParameterType.Height },
                { StairsWidthNumericUpDown, StairsParameterType.Width },
                { StairsThicknessNumericUpDown, StairsParameterType.Thickness },
                { StringerWidthNumericUpDown, StairsParameterType.StringerWidth },
                { StepLengthNumericUpDown, StairsParameterType.StepLength },
                { StepHeightNumericUpDown, StairsParameterType.StepHeight },
                { StepsGapNumericUpDown, StairsParameterType.StepGap }
            };
        }

        /// <summary>
        /// Кнопка построения лестницы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (CheckFormOnErrors())
            {
                _builder.BuildStairs(_parameters);
            }
        }

        /// <summary>
        /// Обработчик изменения значения в NumericUpDown элементе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;

            // TODO: refactor
            switch (_numericUpDownType[numericUpDown])
            {
                case StairsParameterType.Height:
                {
                    _parameters.SetValue(
                        StairsParameterType.Height,
                        (int)numericUpDown.Value);
                    break;
                }

                case StairsParameterType.Width:
                {
                    _parameters.SetValue(
                        StairsParameterType.Width,
                        (int)numericUpDown.Value);

                    StepLengthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.StepLength);
                    StringerWidthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.StringerWidth);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        StairsParameterType.StringerWidth);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        StairsParameterType.StepLength);
                    break;
                }

                case StairsParameterType.Thickness:
                {
                    _parameters.SetValue(
                        StairsParameterType.Thickness,
                        (int)numericUpDown.Value);

                    break;
                }

                case StairsParameterType.StringerWidth:
                {
                    SetParameterValue(numericUpDown);
                    StairsWidthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.Width);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        _numericUpDownType[numericUpDown]);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        StairsParameterType.StepLength);

                    break;
                }

                case StairsParameterType.StepLength:
                {
                    SetParameterValue(numericUpDown);
                    StairsWidthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.Width);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        StairsParameterType.StringerWidth);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        _numericUpDownType[numericUpDown]);
                    break;
                }

                case StairsParameterType.StepHeight:
                {
                    _parameters.SetValue(
                        StairsParameterType.StepHeight,
                        (int)numericUpDown.Value);

                    break;
                }

                case StairsParameterType.StepGap:
                {
                    _parameters.SetValue(
                        StairsParameterType.StepGap,
                        (int)numericUpDown.Value);

                    break;
                }
            }
        }

        // TODO: rsdn

        /// <summary>
        /// Обработчик события, вызывающийся при уходе с NumericUpDown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown_Leave(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;

            if (numericUpDown.Text == "")
            {
                numericUpDown.Text = _parameters.GetValue(
                    _numericUpDownType[numericUpDown]).ToString();
            }
        }

        /// <summary>
        /// Задает значение зависимого параметра лестницы.
        /// </summary>
        /// <param name="numericUpDown">Изменяемый NumericUpDown элемент.</param>
        private void SetParameterValue(NumericUpDown numericUpDown)
        {
            try
            {
                _parameters.SetValue(
                    _numericUpDownType[numericUpDown],
                    (int)numericUpDown.Value);

                numericUpDown.BackColor = _defaultBackColor;
                _numericUpDownErrors[numericUpDown] = "";
            }
            catch (ArgumentException exception)
            {
                numericUpDown.BackColor = _errorBackColor;
                _numericUpDownErrors[numericUpDown] = exception.Message;
            }
        }

        /// <summary>
        /// Изменяет надписи лимитов на форме.
        /// </summary>
        /// <param name="label">Изменяемая надпись.</param>
        /// <param name="type">Тип параметра лестницы.</param>
        private void ChangeLimitLabelText(Label label, StairsParameterType type)
        {
            label.Text = $"{_parameters.GetMinValue(type)}-".ToString()
                         + $"{_parameters.GetMaxValue(type)}мм".ToString();
        }

        /// <summary>
        /// Проверяет NumericUpDown элементы на ошибки заполнения.
        /// </summary>
        /// <returns>false - есть ошибки; true- ошибок нет.</returns>
        private bool CheckFormOnErrors()
        {
            var allErrors = "";

            foreach (var error in _numericUpDownErrors)
            {
                if (error.Value != "")
                {
                    allErrors += error.Value + "\n";
                }
            }

            if (allErrors != "")
            {
                MessageBox.Show(
                    allErrors,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
