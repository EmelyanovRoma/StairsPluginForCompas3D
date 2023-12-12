namespace StairsPlugin.Model
{
    using System;

    /// <summary>
    /// Описывает параметр лестницы.
    /// </summary>
    public class StairsParameter
    {
        /// <summary>
        /// Текущее значение параметра.
        /// </summary>
        private int _value;

        /// <summary>
        /// Создает экземпляр <see cref="StairsParameter"/>.
        /// </summary>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="value">Текущее значение параметра.</param>
        public StairsParameter(int maxValue, int minValue, int value)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            Value = value;
        }

        /// <summary>
        /// Создает пустой экземпляр <see cref="StairsParameter"/>.
        /// </summary>
        public StairsParameter() { }

        /// <summary>
        /// Задает или возвращает максимальное значение параметра.
        /// </summary>
        public int MaxValue { get; private set; }

        /// <summary>
        /// Задает или возвращает минимальное значение параметра.
        /// </summary>
        public int MinValue { get; private set; }

        /// <summary>
        /// Задает или возвращает текущее значение параметра.
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (!Validate())
                {
                    throw new ArgumentException(
                        $"Значение не входит в диапазон "
                        + $"допустимых значений {MinValue} - {MaxValue}");
                }
            }
        }

        /// <summary>
        /// Проверка текущего значения параметра на принадлежность к
        /// диапазону допустимых значений.
        /// </summary>
        /// <returns>True, если текущее значение параметра принадлежит
        /// диапазону допустимых значений.</returns>
        private bool Validate()
        {
            return _value >= MinValue && _value <= MaxValue;
        }
    }
}