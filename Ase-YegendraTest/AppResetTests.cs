using ASE_Yegendra;
using BOOSE;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ase_YegendraTest
{
    /// <summary>
    /// Verifies that an invalid command throws a generic <see cref="Exception"/>.
    /// </summary>
    [TestClass]
    public class AppResetTests
    {
        private Mock<Canvas> mockCanvas;

        /// <summary>
        /// Initializes the test environment before each test method runs.
        /// This method sets up a mock of the <see cref="Canvas"/> class for use in testing.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the mock Canvas object
            mockCanvas = new Mock<Canvas>();
        }

        /// <summary>
        /// Verifies that the <see cref="AppReset"/> constructor correctly initializes when the canvas is valid.
        /// </summary>
        [TestMethod]
        public void Constructor_ShouldInitialize_WhenCanvasIsValid()
        {
            var command = new AppReset(mockCanvas.Object);
            Assert.IsNotNull(command, "Command instance should not be null.");
        }

        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method does not throw an exception when the parameter list is null.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldNotThrowException_WhenParameterListIsNull()
        {
            var command = new AppReset();
            command.CheckParameters(null);

            // Assert that no exception is thrown
            Assert.IsTrue(true, "CheckParameters should not throw exception for null parameter list.");
        }

        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method does not throw an exception when the parameter list is empty.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldNotThrowException_WhenParameterListIsEmpty()
        {
            var command = new AppReset();
            command.CheckParameters(new string[] { });

            // Assert that no exception is thrown
            Assert.IsTrue(true, "CheckParameters should not throw exception for empty parameter list.");
        }

        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method does not throw an exception when the parameter list is empty.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldIgnoreAdditionalParameters()
        {
            var command = new AppReset();
            command.CheckParameters(new[] { "unexpected_param" });

            // Assert that no exception is thrown
            Assert.IsTrue(true, "CheckParameters should ignore additional parameters without throwing exceptions.");
        }

        /// <summary>
        /// Verifies that the <see cref="Execute"/> method throws a <see cref="NullReferenceException"/> when the canvas is null.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldThrowNullReferenceException_WhenCanvasIsNull()
        {
            var command = new AppReset();
            Assert.ThrowsException<NullReferenceException>(() => command.Execute(), "Expected NullReferenceException when executing without a canvas.");
        }
    }
}
