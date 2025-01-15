using ASE_Yegendra;
using BOOSE;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ase_YegendraTest
{
    /// <summary>
    /// Unit tests for the <see cref="AppWrite"/> class, which represents the "write" command for outputting text on the canvas.
    /// </summary>
    [TestClass]
    public class AppWriteTests
    {
        private Mock<Canvas> mockCanvas;

        /// <summary>
        /// Initializes resources before each test method is executed.
        /// This method sets up a mock of the <see cref="Canvas"/> class for use in testing.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the mock Canvas object
            mockCanvas = new Mock<Canvas>();
        }

        /// <summary>
        /// Initializes resources before each test method is executed.
        /// This method sets up a mock of the <see cref="Canvas"/> class for use in testing.
        /// </summary>
        [TestMethod]
        public void Constructor_ShouldInitialize_WhenCanvasAndContentAreValid()
        {
            var writeCommand = new AppWrite(mockCanvas.Object, "Sample Text");
            Assert.IsNotNull(writeCommand, "AppWrite instance should not be null.");
        }

        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method does not throw exceptions when valid parameters are provided.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldNotThrow_WhenValidParameterProvided()
        {
            var writeCommand = new AppWrite();
            writeCommand.CheckParameters(new[] { "\"Hello, World!\"" });

            Assert.IsTrue(true, "CheckParameters should not throw for valid input.");
        }

        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method throws an exception for invalid parameter inputs such as empty, null, or empty string arrays.
        /// </summary>>
        [TestMethod]
        public void CheckParameters_ShouldThrowException_WhenInvalidParameterProvided()
        {
            var writeCommand = new AppWrite();

            Assert.ThrowsException<Exception>(() =>
                writeCommand.CheckParameters(new string[] { }),
                "Expected an exception for empty parameters.");

            Assert.ThrowsException<Exception>(() =>
                writeCommand.CheckParameters(null),
                "Expected an exception for null parameters.");

            Assert.ThrowsException<Exception>(() =>
                writeCommand.CheckParameters(new[] { "" }),
                "Expected an exception for empty string parameter.");
        }


        /// <summary>
        /// Verifies that the <see cref="Execute"/> method throws an exception when an invalid expression is provided.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldThrowException_WhenExpressionIsInvalid()
        {
            var writeCommand = new AppWrite(mockCanvas.Object, "invalid_expr");

            Assert.ThrowsException<Exception>(() => writeCommand.Execute(), "Expected exception for invalid expression.");
        }

        /// <summary>
        /// Validates that the <see cref="Execute"/> method correctly handles division by zero in arithmetic expressions.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldHandleDivisionByZero_WhenArithmeticExpressionProvided()
        {
            var writeCommand = new AppWrite(mockCanvas.Object, "10 / 0");

            Assert.ThrowsException<Exception>(() => writeCommand.Execute(), "Expected exception for division by zero.");
        }
    }
}

