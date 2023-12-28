namespace StairsPlugin.KompasWrapper
{
    using Kompas6API5;
    using StairsPlugin.Model;

    /// <summary>
    /// Описывает создание лестницы.
    /// </summary>
    public class StairsBuilder
    {
        /// <summary>
        /// Расстояние между ступенями.
        /// </summary>
        private const int StepsGap = 300;

        /// <summary>
        /// Высота ступени.
        /// </summary>
        private const int StepHeight = 20;

        /// <summary>
        /// Коннектор компаса.
        /// </summary>
        private readonly KompasConnector _ksConnector = new KompasConnector();

        /// <summary>
        /// Построить балки.
        /// </summary>
        /// <param name="stairsParameters">Параметры лестницы.</param>
        private void BuildStingers(StairsParameters stairsParameters)
        {
            ksEntity sketch = _ksConnector.CreatePlaneXOY();
            var xStart = 0;
            var yStart = 0;

            var stringersHeight = stairsParameters.GetValue(
                StairsParameterType.Thickness);
            var stringerWidth = stairsParameters.GetValue(
                StairsParameterType.StringerWidth);
            var stairsHeight = stairsParameters.GetValue(
                StairsParameterType.Height);
            var stepLength = stairsParameters.GetValue(
                StairsParameterType.StepLength);

            _ksConnector.BeginEdit();
            _ksConnector.CreateRectangle(xStart, yStart,
                stringerWidth, stringersHeight);
            _ksConnector.CreateRectangle(
                -xStart - stepLength - stringerWidth, yStart,
                stringerWidth, stringersHeight);
            _ksConnector.EndEdit();

            _ksConnector.MakeExtrude(sketch, stairsHeight);
        }

        /// <summary>
        /// Построить ступени.
        /// </summary>
        /// <param name="stairsParameters">Параметры лестницы.</param>
        private void BuildSteps(StairsParameters stairsParameters)
        {
            ksEntity sketch = _ksConnector.CreatePlaneYOZ();
            var yStart = 0;
            var stepWidth = stairsParameters.GetValue(
                StairsParameterType.Thickness);
            var stepLength = stairsParameters.GetValue(
                StairsParameterType.StepLength);
            var stairsHeight = stairsParameters.GetValue(
                StairsParameterType.Height);
            var stepHeight = stairsParameters.GetValue(
                StairsParameterType.StepHeight);
            var stepGap = stairsParameters.GetValue(
                StairsParameterType.StepGap);

            int stepsCount = stairsHeight / stepGap;
            var stepsDistance = (stepGap * (stepsCount - 1)) +
                                   (stepHeight * stepsCount);
            
            while (stepsDistance > stairsHeight)
            {
                stepsCount--;
                stepsDistance = (stepGap * (stepsCount - 1)) +
                                (stepHeight * stepsCount);
            }

            var initialDistanceStep = (stairsHeight - stepsDistance) / 2;
            var xStart = initialDistanceStep;

            _ksConnector.BeginEdit();
            for (int i = 0; i < stepsCount; i++)
            {
                if (i == stepsCount - 1)
                {
                    _ksConnector.CreateRectangle(
                        -stairsHeight + initialDistanceStep, yStart,
                        stepHeight, -stepWidth);
                }
                else
                {
                    _ksConnector.CreateRectangle(-xStart, yStart,
                        -stepHeight, -stepWidth);
                }

                xStart += stepGap + stepHeight;
            }

            _ksConnector.EndEdit();
            _ksConnector.MakeExtrude(sketch, stepLength);
        }

        /// <summary>
        /// Построить лестницу.
        /// </summary>
        /// <param name="stairsParameters">Параметры лестницы.</param>
        public void BuildStairs(StairsParameters stairsParameters)
        {
            _ksConnector.Start();
            _ksConnector.CreateDocument3D();

            BuildStingers(stairsParameters);
            BuildSteps(stairsParameters);
        }
    }
}