namespace StairsPlugin.UnitTests
{
    using System;
    using StairsPlugin.Model;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class StairsParametersTests
    {
        [Test(Description = "Positive GetValue method test.")]
        public void Value_GetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var type = StairsParameterType.Height;
            var expected = 1000;

            // Act
            var actual = stairsParameters.GetValue(type);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        [Test(Description = "Positive GetMaxValue method test.")]
        public void MaxValue_GetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var type = StairsParameterType.Height;
            var expected = 10000;

            // Act
            var actual = stairsParameters.GetMaxValue(type);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        [Test(Description = "Positive GetMinValue method test.")]
        public void MinValue_GetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var type = StairsParameterType.Height;
            var expected = 1000;

            // Act
            var actual = stairsParameters.GetMinValue(type);

            // Assert
            ClassicAssert.AreEqual(expected, actual);
        }

        [Test(Description = "Positive set value test.")]
        [TestCase(StairsParameterType.Height, 2000,
            TestName = "Assigning set value of stairs height")]
        [TestCase(StairsParameterType.Width, 500,
            TestName = "Assigning set value of stairs width")]
        [TestCase(StairsParameterType.StringerWidth, 30,
            TestName = "Assigning set value of stringer width")]
        [TestCase(StairsParameterType.StepLength, 500,
            TestName = "Assigning set value of step length")]
        public void Value_SetCorrectValue_ReturnsSameValue(
            StairsParameterType type, int newValue)
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var expectedValue = newValue;

            // Act
            stairsParameters.SetValue(type, newValue);
            var actualValue = stairsParameters.GetValue(type);

            // Assert
            ClassicAssert.AreEqual(expectedValue, actualValue);
        }

        [Test(Description = "Positive RecalculateStairsWidth and recalculate"
                            + " step length max value method test.")]
        public void Value_SetStringerWidthValue_ReturnsCorrectRecalculatedStairsWidth()
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var type = StairsParameterType.StringerWidth;
            var stringersWidthValue = 30;
            var expectedStairsWidthValue = 210;
            var expectedStepLengthMaxValue = 940;

            // Act
            stairsParameters.SetValue(type, stringersWidthValue);
            var actualStairsWidthValue =
                stairsParameters.GetValue(StairsParameterType.Width);
            var actualStepLengthMaxValue =
                stairsParameters.GetMaxValue(StairsParameterType.StepLength);

            // Assert
            Assert.Multiple(
                () =>
                {
                    ClassicAssert.AreEqual(
                        expectedStairsWidthValue, actualStairsWidthValue);
                    ClassicAssert.AreEqual(
                        expectedStepLengthMaxValue, actualStepLengthMaxValue);
                });
        }

        [Test(Description = "Positive RecalculateStairsWidth method test.")]
        public void Value_SetStepLengthValue_ReturnsCorrectRecalculatedStairsWidth()
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var type = StairsParameterType.StepLength;
            var stepLengthValue = 200;
            var expectedStairsWidthValue = 240;

            // Act
            stairsParameters.SetValue(type, stepLengthValue);
            var actualStairsWidthValue =
                stairsParameters.GetValue(StairsParameterType.Width);

            // Assert
            ClassicAssert.AreEqual(
                expectedStairsWidthValue, actualStairsWidthValue);
        }

        [Test(Description = "Positive RecalculateStepLength method test.")]
        public void Value_SetStairsWidthValue_ReturnsCorrectRecalculatedStepLength()
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var type = StairsParameterType.Width;
            var stairsWidthValue = 240;
            var expectedStepLengthValue = 200;

            // Act
            stairsParameters.SetValue(type, stairsWidthValue);
            var actualStepLengthValue =
                stairsParameters.GetValue(StairsParameterType.StepLength);

            // Assert
            ClassicAssert.AreEqual(
                expectedStepLengthValue, actualStepLengthValue);
        }

        [TestCase(950, 45,
            TestName = "Positive test of SetValue method for check stringer"
                       + " width max value (expected = 45)")]
        [TestCase(800, 50,
            TestName = "Positive test of SetValue method for check stringer"
                       + " width max value (expected = 50)")]
        public void Value_SetStairsWidthValue_ReturnsCorrectRecalculatedStringerWidthMaxValue(
            int value, int expectedStringerWidthMaxValue)
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var type = StairsParameterType.Width;

            // Act
            stairsParameters.SetValue(type, value);
            var actualStringerWidthMaxValue =
                stairsParameters.GetMaxValue(StairsParameterType.StringerWidth);

            // Assert
            ClassicAssert.AreEqual(
                expectedStringerWidthMaxValue, actualStringerWidthMaxValue);
        }

        [Test(Description = "Positive test of SetValue method"
                            + " for check stringer width max value"
                            + " if new max value over 50")]
        [TestCase(50, 1000, 890,
            TestName = "Positive test of SetValue method for check stringer"
                       + " width max value if new max value over than 50")]
        [TestCase(50, 950, 850,
            TestName = "Positive test of SetValue method for check stringer"
                       + " width max value if new max value less than 50")]
        public void Value_SetStepLengthValue_ReturnsCorrectStringerWidthMaxValue(
            int stringerWidthValue, int stairsWidthValue, int stepLengthValue)
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var expectedStringerWidthMaxValue = 50;

            // Act
            stairsParameters.SetValue(
                StairsParameterType.StringerWidth, stringerWidthValue);
            stairsParameters.SetValue(
                StairsParameterType.Width, stairsWidthValue);
            stairsParameters.SetValue(
                StairsParameterType.StepLength, stepLengthValue);

            var actualStringerWidthMaxValue =
                stairsParameters.GetMaxValue(StairsParameterType.StringerWidth);

            // Assert
            ClassicAssert.AreEqual(
                expectedStringerWidthMaxValue, actualStringerWidthMaxValue);
        }

        [Test(Description = "Negative set value method test.")]
        [TestCase(StairsParameterType.StepLength, 1000,
            TestName = "Check on cross validation if step length value "
                       + "over than max value")]
        [TestCase(StairsParameterType.StepLength, 100,
            TestName = "Check on cross validation if step length value "
                       + "less than min value")]
        [TestCase(StairsParameterType.StringerWidth, 0,
            TestName = "Check on cross validation if stringer width value "
                       + "over than max value")]
        [TestCase(StairsParameterType.StringerWidth, 55,
            TestName = "Check on cross validation if stringer width value "
                       + "less than min value")]
        public void Value_SetStairsWidthValue_ReturnsCorrectRecalculated(
            StairsParameterType type, int wrongValue)
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var message = "An exception should be thrown if value"
                          + " value is out the range of valid values";

            // Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    // Act
                    stairsParameters.SetValue(type, wrongValue);
                },
                message);
        }
    }
}
