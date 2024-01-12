namespace StairsPlugin.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Описывает параметры лестницы.
    /// </summary>
    public class StairsParameters
    {
        /// <summary>
        /// Словарь, содержащий параметры лестницы.
        /// </summary>
        private readonly Dictionary<StairsParameterType,
            StairsParameter> _stairsParameters =
            new Dictionary<StairsParameterType, StairsParameter>
            {
                {
                    StairsParameterType.Height, new StairsParameter(
                        10000, 1000, 1000)
                },
                {
                    StairsParameterType.Width, new StairsParameter(
                        1000, 190, 190)
                },
                {
                    StairsParameterType.Thickness, new StairsParameter(
                        50, 20, 20)
                },
                {
                    StairsParameterType.StringerWidth, new StairsParameter(
                        50, 20, 20)
                },
                {
                    StairsParameterType.StepLength, new StairsParameter(
                        960, 150, 150)
                },
                {
                    StairsParameterType.StepHeight, new StairsParameter(
                        50, 20, 20)
                },
                {
                    StairsParameterType.StepsGap, new StairsParameter(
                        350, 250, 300)
                }
            };

        /// <summary>
        /// Создает экземпляр <see cref="StairsParameters"/>.
        /// </summary>
        public StairsParameters() { }

        /// <summary>
        /// Возвращает значение параметра лестницы.
        /// </summary>
        /// <param name="type">Тип параметра лестницы.</param>
        /// <returns>Значение параметра лестницы.</returns>
        public int GetValue(StairsParameterType type)
        {
            return _stairsParameters[type].Value;
        }

        /// <summary>
        /// Возвращает минимальное значение параметра лестницы.
        /// </summary>
        /// <param name="type">Тип параметра лестницы.</param>
        /// <returns>Минимальное значение параметра лестницы.</returns>
        public int GetMinValue(StairsParameterType type)
        {
            return _stairsParameters[type].MinValue;
        }

        /// <summary>
        /// Возвращает максимальное значение параметра лестницы.
        /// </summary>
        /// <param name="type">Тип параметра лестницы.</param>
        /// <returns>Максимальное значение параметра лестницы.</returns>
        public int GetMaxValue(StairsParameterType type)
        {
            return _stairsParameters[type].MaxValue;
        }

        /// <summary>
        /// Задает значение параметра лестницы.
        /// </summary>
        /// <param name="type">Тип параметра лестницы.</param>
        /// <param name="value">Новое значение параметра лестницы.</param>
        public void SetValue(StairsParameterType type, int value)
        {
            CrossValidation(type, value);
            _stairsParameters[type].Value = value;

            switch (type)
            {
                case StairsParameterType.Width:
                    AdjustWidthParameters();
                    break;

                case StairsParameterType.StepLength:
                    RecalculateStairsWidth();
                    break;

                case StairsParameterType.StringerWidth:
                    AdjustStepLengthParameter();
                    break;
            }
        }

        /// <summary>
        /// Устанавливает длину ступени и ширину балки.
        /// </summary>
        private void AdjustWidthParameters()
        {
            var widthParameter = _stairsParameters[StairsParameterType.Width];
            var stringerWidthParameter = _stairsParameters[StairsParameterType.StringerWidth];
            var stepLengthParameter = _stairsParameters[StairsParameterType.StepLength];

            if (widthParameter.Value - (2 * stringerWidthParameter.Value) <
                stepLengthParameter.MinValue)
            {
                stringerWidthParameter.Value -= (int)Math.Ceiling(
                    (decimal)(stepLengthParameter.MinValue -
                              (widthParameter.Value - (2 * stringerWidthParameter.Value))) / 2);
            }

            RecalculateStepLength();

            var newStringerWidthMaxValue =
                (widthParameter.MaxValue - stepLengthParameter.Value) / 2;
            stringerWidthParameter.MaxValue =
                Math.Min(newStringerWidthMaxValue, 50);

            stringerWidthParameter.Value =
                (widthParameter.Value - stepLengthParameter.Value) / 2;
        }

        /// <summary>
        /// Устанавливает ширину лестницы.
        /// </summary>
        private void AdjustStepLengthParameter()
        {
            var widthParameter = _stairsParameters[StairsParameterType.Width];
            var stringerWidthParameter = _stairsParameters[StairsParameterType.StringerWidth];
            var stepLengthParameter = _stairsParameters[StairsParameterType.StepLength];

            RecalculateStairsWidth();

            stepLengthParameter.MaxValue =
                widthParameter.MaxValue - (2 * stringerWidthParameter.Value);
        }

        /// <summary>
        /// Пересчитывает ширину лестницы.
        /// </summary>
        private void RecalculateStairsWidth()
        {
            _stairsParameters[StairsParameterType.Width].Value =
                _stairsParameters[StairsParameterType.StepLength].Value +
                (2 * _stairsParameters[StairsParameterType.StringerWidth].Value);
        }

        /// <summary>
        /// Пересчитывает ширину лестницы.
        /// </summary>
        private void RecalculateStepLength()
        {
            _stairsParameters[StairsParameterType.StepLength].Value =
                _stairsParameters[StairsParameterType.Width].Value -
                (2 * _stairsParameters[StairsParameterType.StringerWidth].Value);
        }

        /// <summary>
        /// Кросс-валидация.
        /// </summary>
        private void CrossValidation(StairsParameterType type, int value)
        {
            // TODO: duplication
            Dictionary<StairsParameterType, string> parameterDescriptions =
                new Dictionary<StairsParameterType, string>()
                {
                    { StairsParameterType.StepLength, "длина ступени" },
                    { StairsParameterType.StringerWidth, "ширина балки" }
                };

            string parameterName;
            if (!parameterDescriptions.TryGetValue(type, out parameterName))
            {
                parameterName = "Неизвестный параметр";
            }

            if ((value < _stairsParameters[type].MinValue
                || value > _stairsParameters[type].MaxValue)
                && parameterName != "Неизвестный параметр")
            {
                throw new ArgumentException(
                    $"Параметр {parameterName} должен быть в диапазоне"
                    + $" {_stairsParameters[type].MinValue} -"
                    + $" {_stairsParameters[type].MaxValue} мм");
            }
        }
    }
}
