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
    /// Unit tests for the <see cref="AppTriangle"/> class, which represents the Triangle command for drawing on the canvas.
    /// These tests ensure that the <see cref="AppTriangle"/> class behaves correctly in various scenarios.
    /// </summary>
    [TestClass]
    public class AppTriangleTests
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
        /// Verifies that the <see cref="AppTriangle"/> constructor correctly initializes when the canvas and dimensions are valid.
        /// </summary>
        [TestMethod]
        public void Constructor_ShouldInitialize_WhenCanvasAndDimensionsAreValid()
        {
            var triangle = new AppTriangle(mockCanvas.Object, 100, 200);
            Assert.IsNotNull(triangle, "Triangle instance should not be null.");
        }


        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method does not throw an exception when parameters are valid.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldPass_WhenParametersAreValid()
        {
            var triangle = new AppTriangle();
            triangle.CheckParameters(new[] { "100", "200" });

            // Assert that no exception is thrown
            Assert.IsTrue(true, "CheckParameters should not throw exception for valid parameters.");
        }

        /// <summary>
        /// Verifies that the <see cref="Execute"/> method throws a <see cref="NullReferenceException"/> when the canvas is null.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldThrowException_WhenCanvasIsNull()
        {
            var triangle = new AppTriangle();

            Assert.ThrowsException<NullReferenceException>(() =>
                triangle.Execute(),
                "Expected NullReferenceException when executing without a canvas.");
        }

        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method throws a <see cref="CommandException"/> when the parameter list has an invalid length.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldThrowException_WhenParameterListHasInvalidLength()
        {
            var triangle = new AppTriangle();

            Assert.ThrowsException<CommandException>(() =>
                triangle.CheckParameters(new[] { "100" }),
                "Expected CommandException when parameter list has invalid length.");
        }

        /// <summary>
        /// Verifies that the <see cref="CheckParameters"/> method throws a <see cref="CommandException"/> when any parameter is not a positive integer.
        /// </summary>
        [TestMethod]
        public void CheckParameters_ShouldThrowException_WhenParametersAreNotPositiveIntegers()
        {
            var triangle = new AppTriangle();

            Assert.ThrowsException<CommandException>(() =>
                triangle.CheckParameters(new[] { "-100", "50" }),
                "Expected CommandException for negative dimensions.");

            Assert.ThrowsException<CommandException>(() =>
                triangle.CheckParameters(new[] { "abc", "50" }),
                "Expected CommandException for non-integer width.");
        }


        /// <summary>
        /// Verifies that the <see cref="Execute"/> method correctly draws the triangle on the canvas when parameters are valid.
        /// </summary>
        [TestMethod]
        public void Execute_ShouldDrawTriangle_WhenParametersAreValid()
        {
            // Arrange
            var triangle = new AppTriangle(mockCanvas.Object, 150, 100);

            // Act
            triangle.Paramsint = new[] { 150, 100 }; // Populate Paramsint before executing
            triangle.Execute();

            // Assert
            mockCanvas.Verify(c => c.Rect(150, 100, false), Times.Once, "Rect method should be called with correct parameters.");
        }

    }

}
