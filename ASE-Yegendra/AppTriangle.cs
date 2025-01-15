using BOOSE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents the Triangle command, which draws a triangle on the canvas.
    /// This command requires two parameters: width and height.
    /// </summary>
    public class AppTriangle : CommandTwoParameters
    {
        private int height;
        private int width;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppTriangle"/> class.
        /// </summary>
        public AppTriangle() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppTriangle"/> class with the specified canvas, width, and height.
        /// </summary>
        /// <param name="canvas">The canvas on which to draw the triangle.</param>
        /// <param name="width">The width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public AppTriangle(Canvas canvas, int width, int height) : base(canvas)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Executes the Triangle command to draw a triangle on the canvas.
        /// </summary>
        /// <exception cref="CanvasException">
        /// Thrown when the dimensions of the triangle are invalid.
        /// </exception>
        public override void Execute()
        {
            if (base.Canvas == null)
            {
                throw new NullReferenceException("Canvas is not initialized.");
            }

            try
            {
                // Validate and fetch parameters
                width = base.Paramsint.Length > 0 ? base.Paramsint[0] : throw new IndexOutOfRangeException("Width is missing.");
                height = base.Paramsint.Length > 1 ? base.Paramsint[1] : throw new IndexOutOfRangeException("Height is missing.");

                // Restriction: Ensure width and height do not exceed limits
                if (width > 2000 || height > 2000)
                {
                    throw new RestrictionException("Width and height cannot exceed 2000.");
                }

                // Draw triangle on canvas
                base.Canvas.Rect(width, height, filled: false);
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.WriteLine($"Parameter index out of range: {ex.Message}");
                throw;
            }
            catch (RestrictionException ex)
            {
                Debug.WriteLine($"Parameter exceeds restriction: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error during execution: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Validates the parameters for the Triangle command.
        /// </summary>
        /// <param name="parameterList">The list of parameters provided to the command.</param>
        /// <exception cref="CommandException">
        /// Thrown when the parameters are invalid or improperly formatted.
        /// </exception>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList == null || parameterList.Length != 2)
            {
                throw new CommandException($"Invalid number of parameters for {nameof(AppTriangle)}. Expected exactly two parameters.");
            }

            if (!int.TryParse(parameterList[0], out int parsedWidth) || parsedWidth <= 0)
            {
                throw new CommandException($"Invalid width for {nameof(AppTriangle)}. Ensure it is a positive integer.");
            }

            if (!int.TryParse(parameterList[1], out int parsedHeight) || parsedHeight <= 0)
            {
                throw new CommandException($"Invalid height for {nameof(AppTriangle)}. Ensure it is a positive integer.");
            }

            base.Paramsint = new[] { parsedWidth, parsedHeight };
        }

    }
}
