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
                    RecalculateStepLength();

                    if (_stairsParameters[type].Value > 940)
                    {
                        var newStringerWidthMaxValue =
                            (_stairsParameters[type].MaxValue -
                             _stairsParameters[StairsParameterType.StepLength].Value) / 2;

                        _stairsParameters[StairsParameterType.StringerWidth].MaxValue =
                            newStringerWidthMaxValue > 50 ? 50 : newStringerWidthMaxValue;
                    }
                    else
                    {
                        _stairsParameters[
                            StairsParameterType.StringerWidth].MaxValue = 50;
                    }

                    _stairsParameters[StairsParameterType.StringerWidth].Value =
                        (_stairsParameters[StairsParameterType.Width].Value
                         - _stairsParameters[StairsParameterType.StepLength].Value) / 2;

                    break;

                case StairsParameterType.StepLength:
                    RecalculateStairsWidth();
                    break;

                case StairsParameterType.StringerWidth:
                    RecalculateStairsWidth();

                    _stairsParameters[StairsParameterType.StepLength].MaxValue =
                        _stairsParameters[StairsParameterType.Width].MaxValue
                        - (2 * _stairsParameters[type].Value);
                    break;
            }
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
            if (type == StairsParameterType.StepLength)
            {
                if (value < _stairsParameters[type].MinValue
                    || value > _stairsParameters[type].MaxValue)
                {
                    throw new ArgumentException(
                        $"Длина ступени должна быть в диапазоне"
                        + $" {_stairsParameters[type].MinValue} -"
                        + $" {_stairsParameters[type].MaxValue} мм");
                }
            }

            if (type == StairsParameterType.StringerWidth)
            {
                if (value < _stairsParameters[type].MinValue
                    || value > _stairsParameters[type].MaxValue)
                {
                    throw new ArgumentException(
                        $"Ширина балки должна быть в диапазоне"
                        + $" {_stairsParameters[type].MinValue} -"
                        + $" {_stairsParameters[type].MaxValue} мм");
                }
            }
        }
    }
}
