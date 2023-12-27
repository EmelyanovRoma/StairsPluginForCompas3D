namespace StairsPlugin.UnitTests
{
    using System;
    using StairsPlugin.Model;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class StairsParameterTests
    {
        [Test(Description = "Negative max value setter test.")]
        public void MaxValue_SetIncorrectValue_ThrowsArgumentException()
        {
            // Arrange
            var stairsParameter =
                new StairsParameter(5, 1,2);
            var wrongMaxValue = 0;
            var message = "An exception should be thrown"
                          + " if max value less than min value";

            // Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    // Act
                    stairsParameter.MaxValue = wrongMaxValue;
                },
                message);
        }

        [Test(Description = "Positive max value setter test.")]
        public void MaxValue_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var stairsParameter =
                new StairsParameter(5, 1, 2);
            var correctMaxValue = 10;
            var expectedMaxValue = correctMaxValue;

            // Act
            stairsParameter.MaxValue = correctMaxValue;
            var actualMaxValue = stairsParameter.MaxValue;

            // Assert
            ClassicAssert.AreEqual(expectedMaxValue, actualMaxValue);
        }

        [Test(Description = "Positive min value getter test")]
        public void MinValue_GetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            StairsParameter stairsParameter;
            var minValue = 1;
            var expectedMinValue = minValue;

            // Act
            stairsParameter =
                new StairsParameter(5, minValue, 2);
            var actualMinValue = stairsParameter.MinValue;

            // Assert
            ClassicAssert.AreEqual(expectedMinValue, actualMinValue);
        }

        [Test(Description = "Negative value setter test.")]
        public void Value_SetIncorrectValue_ThrowsArgumentException()
        {
            // Arrange
            var stairsParameter =
                new StairsParameter(5, 1, 2);
            var wrongValue = 0;
            var message = "An exception should be thrown if value is"
                          + " not within the range of valid values";

            // Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    // Act
                    stairsParameter.Value = wrongValue;
                },
                message);
        }

        [Test(Description = "Positive value setter test.")]
        public void Value_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var stairsParameter =
                new StairsParameter(5, 1, 2);
            var correctValue = 3;
            var expectedValue = correctValue;

            // Act
            stairsParameter.Value = correctValue;
            var actualValue = stairsParameter.Value;

            // Assert
            ClassicAssert.AreEqual(expectedValue, actualValue);
        }

        [Test(Description = "Positive stairs parameter constructor test.")]
        public void Constructor_CreationWithCorrectParameters_ReturnsSameValue()
        {
            // Arrange
            StairsParameter stairsParameter;
            var maxValue = 5;
            var minValue = 1;
            var value = 2;

            var expectedMaxValue = maxValue;
            var expectedMinValue = minValue;
            var expectedValue = value;

            // Act
            stairsParameter = new StairsParameter(maxValue, minValue, value);

            var actualMaxValue = stairsParameter.MaxValue;
            var actualMinValue = stairsParameter.MinValue;
            var actualValue = stairsParameter.Value;

            // Assert
            Assert.Multiple(
                () =>
                {
                    ClassicAssert.AreEqual(expectedMaxValue, actualMaxValue);
                    ClassicAssert.AreEqual(expectedMinValue, actualMinValue);
                    ClassicAssert.AreEqual(expectedValue, actualValue);
                }
                );
        }
    }
}
