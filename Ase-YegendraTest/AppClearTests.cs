using ASE_Yegendra;
using BOOSE;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ase_YegendraTest
{
    /// <summary>
    /// Contains unit tests for the <see cref="AppClear"/> class.
    /// Tests verify behavior related to canvas clearing functionality, parameter checks, and exception handling.
    /// </summary>
    [TestClass]
    public class AppClearTests
    {
        private Mock<Canvas> mockCanvas;


        /// <summary>
        /// Initializes a new mock <see cref="Canvas"/> object before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the mock Canvas object
            mockCanvas = new Mock<Canvas>();
        }

        /// <summary>
        /// Verifies that the <see cref="AppClear"/> constructor properly initializes when a valid canvas is provided.
        /// </summary>
        [TestMethod]
        public void Constructor_ShouldInitialize_WhenCanvasIsValid()
        {
            var command = new AppClear(mockCanvas.Object);
            Assert.IsNotNull(command, "Command instance should not be null.");
        }


        /// <summary>
        /// Verifies that the <see cref="Execute"/> method calls the <see cref="Canvas.Clear"/> method once when the canvas is valid.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldClearCanvas_WhenCanvasIsValid()
        {
            var command = new AppClear(mockCanvas.Object);
            mockCanvas.Setup(c => c.Clear());
            command.Execute();

            mockCanvas.Verify(c => c.Clear(), Times.Once, "Clear should be called once on the canvas.");
        }

        /// <summary>
        /// Verifies that no exception is thrown when <see cref="Execute"/> is called on a valid, empty canvas.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldNotThrowException_WhenCanvasIsEmpty()
        {
            mockCanvas.Setup(c => c.Clear());
            var command = new AppClear(mockCanvas.Object);
            command.Execute();

            // Assert that no exception is thrown
            mockCanvas.Verify(c => c.Clear(), Times.Once, "Clear should still be called on an empty canvas.");
        }

        /// <summary>
        /// Verifies that no exception is thrown when <see cref="CheckParameters"/> is called with a null parameter list.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldNotThrowException_WhenParameterListIsNull()
        {
            var command = new AppClear();
            command.CheckParameters(null);

            // Assert that no exception is thrown
            Assert.IsTrue(true, "CheckParameters should not throw exception for null parameter list.");
        }

        /// <summary>
        /// Verifies that no exception is thrown when <see cref="CheckParameters"/> is called with an empty parameter list.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldNotThrowException_WhenParameterListIsEmpty()
        {
            var command = new AppClear();
            command.CheckParameters(new string[] { });

            // Assert that no exception is thrown
            Assert.IsTrue(true, "CheckParameters should not throw exception for empty parameter list.");
        }

        /// <summary>
        /// Verifies that additional parameters are ignored when <see cref="CheckParameters"/> is called with unexpected parameters.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldIgnoreAdditionalParameters()
        {
            var command = new AppClear();
            command.CheckParameters(new[] { "unexpected_param" });

            // Assert that no exception is thrown
            Assert.IsTrue(true, "CheckParameters should ignore additional parameters without throwing exceptions.");
        }


        /// <summary>
        /// Verifies that calling <see cref="Execute"/> without a canvas results in a <see cref="NullReferenceException"/>.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldHandleNullCanvas_Gracefully()
        {
            var command = new AppClear();
            Assert.ThrowsException<NullReferenceException>(() => command.Execute(), "Expected NullReferenceException when executing without a canvas.");
        }
    }
}
