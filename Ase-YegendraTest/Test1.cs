using ASE_Yegendra;
using BOOSE;
using System.Drawing;

namespace Ase_YegendraTest
{
    /// <summary>
    /// This class contains unit tests for the canvas application functionality.
    /// </summary>
    [TestClass]
    public sealed class Test1
    {
        /// <summary>
        /// Tests that a canvas is initialized with default coordinates (0, 0).
        /// </summary>
        [TestMethod]
        public void TestCanvasInitialization()
        {
            var canvas = new canvasApp();
            Assert.AreEqual(0, canvas.Xpos);
            Assert.AreEqual(0, canvas.Ypos);
        }

        /// <summary>
        /// Tests that the canvas size can be set and positions updated correctly.
        /// </summary>
        [TestMethod]
        public void TestSetCanvasSize()
        {
            var canvas = new canvasApp();
            canvas.Set(800, 600);

            canvas.MoveTo(799, 599);
            Assert.AreEqual(799, canvas.Xpos);
            Assert.AreEqual(599, canvas.Ypos);
        }

        /// <summary>
        /// Tests that moving to an invalid position throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void TestInvalidMoveTo()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(641, 480);
        }

        /// <summary>
        /// Tests drawing a line updates the position correctly.
        /// </summary>
        [TestMethod]
        public void TestDrawLine()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(100, 100);
            canvas.DrawTo(200, 200);

            Assert.AreEqual(200, canvas.Xpos);
            Assert.AreEqual(200, canvas.Ypos);
        }

        /// <summary>
        /// Tests that drawing a line to an invalid position throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void TestDrawToInvalidPosition()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(100, 100);
            canvas.DrawTo(700, 500);
        }

        /// <summary>
        /// Tests setting the pen color on the canvas.
        /// </summary>
        [TestMethod]
        public void TestSetColour()
        {
            var canvas = new canvasApp();
            canvas.SetColour(255, 0, 0);
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), canvas.PenColour);
        }

        /// <summary>
        /// Tests that setting an invalid color throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void TestSetInvalidColour()
        {
            var canvas = new canvasApp();
            canvas.SetColour(256, 0, 0);
        }

        /// <summary>
        /// Tests drawing a rectangle without filling.
        /// </summary>
        [TestMethod]
        public void TestDrawRectangle()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(50, 50);
            canvas.Rect(100, 50, false);

            Assert.AreEqual(50, canvas.Xpos);
            Assert.AreEqual(50, canvas.Ypos);
        }

        /// <summary>
        /// Tests that invalid rectangle dimensions throw an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void TestInvalidRectangleDimensions()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.Rect(-100, 50, false);
        }

        /// <summary>
        /// Tests drawing a circle without filling.
        /// </summary>
        [TestMethod]
        public void TestDrawCircle()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(320, 240);
            canvas.Circle(50, false);

            Assert.AreEqual(320, canvas.Xpos);
            Assert.AreEqual(240, canvas.Ypos);
        }

        /// <summary>
        /// Tests that an invalid circle radius throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void TestInvalidCircleRadius()
        {
            var canvas = new canvasApp();
            canvas.Circle(-10, false);
        }

        /// <summary>
        /// Tests writing text to the canvas.
        /// </summary>
        [TestMethod]
        public void TestWriteText()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(100, 100);
            canvas.WriteText("Hello, Canvas!");

            Assert.AreEqual(100, canvas.Xpos);
            Assert.AreEqual(100, canvas.Ypos);
        }

        /// <summary>
        /// Tests clearing the canvas.
        /// </summary>
        [TestMethod]
        public void TestClearCanvas()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.Clear();
        }

        /// <summary>
        /// Tests resetting the canvas to its initial state.
        /// </summary>
        [TestMethod]
        public void TestResetCanvas()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(100, 100);
            canvas.Reset();

            Assert.AreEqual(0, canvas.Xpos);
            Assert.AreEqual(0, canvas.Ypos);
        }

        /// <summary>
        /// Tests drawing a triangle and verifies the vertices.
        /// </summary>
        [TestMethod]
        public void TestDrawTriangle()
        {
            var canvas = new canvasApp();
            canvas.Set(640, 480);
            canvas.MoveTo(100, 100);
            canvas.Tri(100, 100);

            Bitmap bitmap = (Bitmap)canvas.getBitmap();
            Color expectedColor = Color.FromArgb(255, 255, 0, 0);

            Assert.AreEqual(expectedColor, bitmap.GetPixel(100, 100), "Top vertex is not correct.");
            Assert.AreEqual(expectedColor, bitmap.GetPixel(50, 200), "Bottom-left vertex is not correct.");
            Assert.AreEqual(expectedColor, bitmap.GetPixel(150, 200), "Bottom-right vertex is not correct.");
        }

        /// <summary>
        /// Tests that invalid parameters for a triangle throw an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void TestCheckParametersInvalidDimensions()
        {
            var canvas = new canvasApp();
            canvas.Tri(100, -100);
        }
    }


}
