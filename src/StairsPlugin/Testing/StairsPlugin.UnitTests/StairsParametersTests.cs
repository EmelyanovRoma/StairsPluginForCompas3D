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
            stairsParameters.SetValue(StairsParameterType.Height, expected);
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

        // TODO: Check
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
        public void Value_SetDependentValue_ThrowsArgumentException(
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

        [Test(Description = "Positive SetValue method test if step length"
                            + " less than 150")]
        public void Value_SetStairsWidthValue_ReturnsCorrectStepLength()
        {
            // Arrange
            var stairsParameters = new StairsParameters();
            var expectedStepLength = 150;

            // Act
            stairsParameters.SetValue(StairsParameterType.StringerWidth, 35);
            stairsParameters.SetValue(StairsParameterType.Width, 300);
            stairsParameters.SetValue(StairsParameterType.Width, 190);
            var actualStepLength = stairsParameters.GetValue(StairsParameterType.StepLength);

            // Assert
            ClassicAssert.AreEqual(expectedStepLength, actualStepLength);
        }
    }
}
