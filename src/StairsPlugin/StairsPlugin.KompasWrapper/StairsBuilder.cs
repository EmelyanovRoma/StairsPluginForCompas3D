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
            double xStart = 0;
            double yStart = 0;
            double angle = 0;

            double stringersHeight = stairsParameters.GetValue(
                StairsParameterType.Thickness);
            double stringerWidth = stairsParameters.GetValue(
                StairsParameterType.StringerWidth);
            double stairsHeight = stairsParameters.GetValue(
                StairsParameterType.Height);
            double stepLength = stairsParameters.GetValue(
                StairsParameterType.StepLength);

            _ksConnector.BeginEdit();
            _ksConnector.CreateRectangle(xStart, yStart,
                stringerWidth, stringersHeight, angle);
            _ksConnector.CreateRectangle(
                -xStart - stepLength - stringerWidth, yStart,
                stringerWidth, stringersHeight, angle);
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
            double stepsGap = 300;
            double yStart = 0;
            double angle = 0;
            double stepHeight = 20;

            double stepWidth = stairsParameters.GetValue(
                StairsParameterType.Thickness);
            double stepLength = stairsParameters.GetValue(
                StairsParameterType.StepLength);
            double stairsHeight = stairsParameters.GetValue(
                StairsParameterType.Height);
            int stepsCount = (int)(stairsHeight / stepsGap);
            double stepsDistance = (stepsGap * (stepsCount - 1)) +
                                   (stepHeight * stepsCount);
            
            if (stepsDistance > stairsHeight)
            {
                stepsCount--;
                stepsDistance = (stepsGap * (stepsCount - 1)) +
                                (stepHeight * stepsCount);
            }

            double initialDistanceStep = (stairsHeight - stepsDistance) / 2;
            double xStart = initialDistanceStep;

            _ksConnector.BeginEdit();
            for (int i = 0; i < stepsCount; i++)
            {
                if (i == stepsCount - 1)
                {
                    _ksConnector.CreateRectangle(
                        -stairsHeight + initialDistanceStep, yStart,
                        stepHeight, -stepWidth, angle);
                }
                else
                {
                    _ksConnector.CreateRectangle(-xStart, yStart,
                        -stepHeight, -stepWidth, angle);
                }

                xStart += stepsGap + stepHeight;
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