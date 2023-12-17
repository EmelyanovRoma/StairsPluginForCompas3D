namespace StairsPlugin.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Описывает параметры лестницы.
    /// </summary>
    public class StairsParameters
    {
        /// <summary>
        /// Словарь, содержащий параметры лестницы.
        /// </summary>
        private readonly Dictionary<StairsParameterType, StairsParameter> _stairsParameters =
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
        /// Задает значение параметра лестницы.
        /// </summary>
        /// <param name="type">Тип параметра лестницы.</param>
        /// <param name="value">Новое значение параметра лестницы.</param>
        public void SetValue(StairsParameterType type, int value)
        {
            _stairsParameters[type].Value = value;

            if (type == StairsParameterType.Width)
            {
                RecalculateStepLength();
            }

            if (type == StairsParameterType.StepLength)
            {
                RecalculateStairsWidth();
            }

            if (type == StairsParameterType.StringerWidth)
            {
                RecalculateStairsWidth();
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
        private void CrossValidation(StairsParameterType type) { }
    }
}
