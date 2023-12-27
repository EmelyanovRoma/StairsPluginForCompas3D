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
        private readonly Dictionary<NumericUpDown, string> _errorsDictionary;

        /// <summary>
        /// Словарь NumericUpDown.
        /// </summary>
        private readonly Dictionary<NumericUpDown, StairsParameterType> _numericUpDownDictionary;

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _errorsDictionary = new Dictionary<NumericUpDown, string>
            {
                { StairsHeightNumericUpDown, "" },
                { StairsWidthNumericUpDown, "" },
                { StairsThicknessNumericUpDown, "" },
                { StringerWidthNumericUpDown, "" },
                { StepLengthNumericUpDown, "" }
            };

            _numericUpDownDictionary = new Dictionary<NumericUpDown, StairsParameterType>
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
            if (CheckFormsOnErrors())
            {
                _builder.BuildStairs(_parameters);
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;

            switch (numericUpDown.Name)
            {
                case "StairsHeightNumericUpDown":
                    _parameters.SetValue(
                        StairsParameterType.Height,
                        (int)numericUpDown.Value);
                    break;

                case "StairsWidthNumericUpDown":
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

                case "StairsThicknessNumericUpDown":
                    _parameters.SetValue(
                        StairsParameterType.Thickness,
                        (int)numericUpDown.Value);

                    break;

                case "StringerWidthNumericUpDown":
                    SetParameterValue(numericUpDown);
                    StairsWidthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.Width);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        _numericUpDownDictionary[numericUpDown]);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        StairsParameterType.StepLength);

                    break;

                case "StepLengthNumericUpDown":
                    SetParameterValue(numericUpDown);
                    StairsWidthNumericUpDown.Value =
                        _parameters.GetValue(StairsParameterType.Width);

                    ChangeLimitLabelText(
                        StringerWidthLimitLabel,
                        StairsParameterType.StringerWidth);
                    ChangeLimitLabelText(
                        StepLengthLimitLabel,
                        _numericUpDownDictionary[numericUpDown]);
                    break;
            }
        }

        private void NumericUpDown_Leave(object sender, EventArgs e)
        {
            var numericUpDown = (NumericUpDown)sender;

            if (numericUpDown.Text == "")
            {
                numericUpDown.Text = _parameters.GetValue(
                    _numericUpDownDictionary[numericUpDown]).ToString();
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
                    _numericUpDownDictionary[numericUpDown],
                    (int)numericUpDown.Value);

                numericUpDown.BackColor = _defaultBackColor;
                _errorsDictionary[numericUpDown] = "";
            }
            catch (ArgumentException exception)
            {
                numericUpDown.BackColor = _errorBackColor;
                _errorsDictionary[numericUpDown] = exception.Message;
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
        private bool CheckFormsOnErrors()
        {
            var allErrors = "";

            foreach (var error in _errorsDictionary)
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
