using BOOSE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents a canvas application for drawing and managing graphics.
    /// </summary>
    public class canvasApp : ICanvas
    {
        private int xPos, yPos;
        private int XCanvasSize, YCanvasSize;
        private Color penColour;
        private const int XSIZE = 640;
        private const int YSIZE = 480;
        private Bitmap bm = new Bitmap(XSIZE, YSIZE);
        private Graphics g;
        private int penSize = 5;
        private Pen Pen;
        private bool filled = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="canvasApp"/> class.
        /// </summary>
        public canvasApp()
        {
            try
            {
                Debug.WriteLine(AboutBOOSE.about());
                Set(XSIZE, YSIZE);
                penColour = Color.Red;
                Pen = new Pen(penColour, penSize);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error initializing canvasApp: {ex.Message}");
                throw new InvalidOperationException("Failed to initialize canvasApp.", ex);
            }
        }

        /// <summary>
        /// Gets or sets the X-coordinate of the current position on the canvas.
        /// </summary>
        public int Xpos
        {
            get => xPos;
            set => xPos = value;
        }

        /// <summary>
        /// Gets or sets the Y-coordinate of the current position on the canvas.
        /// </summary>
        public int Ypos
        {
            get => yPos;
            set => yPos = value;
        }

        /// <summary>
        /// Gets or sets the color of the pen used for drawing on the canvas.
        /// </summary>
        public object PenColour
        {
            get
            {
                return penColour;
            }
            set
            {
                try
                {
                    // Attempt to cast the value to a Color object
                    penColour = (Color)value;
                }
                catch (InvalidCastException)
                {
                    // Log or handle the error, but do not stop the program
                    Debug.WriteLine("\nInvalid pen color value provided. Please provide a valid Color object.");
                    // Optionally, you can set a default color in case of an error
                    penColour = Color.Red;
                }
            }
        }

        /// <summary>
        /// Draws a circle with the specified radius and filled or outlined based on the given flag.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="filled">Indicates whether the circle should be filled.</param>
        public void Circle(int radius, bool filled)
        {
            try
            {
                // Check if the radius is valid
                if (radius <= 0)
                {
                    throw new CanvasException("Radius must be greater than zero.");
                }


                // Draw the circle if g is initialized
                if (g != null)
                {

                    if (this.filled)
                    {
                        // Draw a filled circle
                        g.FillEllipse(new SolidBrush(penColour), xPos - radius, yPos - radius, radius * 2, radius * 2);
                    }
                    else
                    {
                        // Draw an outlined circle
                        g.DrawEllipse(Pen, xPos - radius, Ypos - radius, radius * 2, radius * 2);
                    }


                }
                else
                {
                    throw new CanvasException("Graphics context (g) is not initialized.");
                }
            }
            catch (CanvasException ex)
            {
                // Log the error or handle it without stopping execution
                Debug.WriteLine($"\nWarning: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clears the canvas by filling it with a default background color.
        /// </summary>
        public void Clear()
        {
            g.Clear(Color.LightGray);
        }

        /// <summary>
        /// Draws a line from the current position to the specified coordinates.
        /// </summary>
        /// <param name="toX">The X-coordinate of the destination.</param>
        /// <param name="toY">The Y-coordinate of the destination.</param>
        public void DrawTo(int toX, int toY)
        {
            try
            {
                if (toX < 0 || toX > XCanvasSize || toY < 0 || toY > YCanvasSize)
                    throw new CanvasException("Invalid screen position DrawTo: " + toX + ", " + toY);

                if (g != null)
                    g.DrawLine(Pen, xPos, yPos, toX, toY);

                xPos = toX;
                yPos = toY;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error drawing line: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Moves the current position to the specified coordinates without drawing.
        /// </summary>
        /// <param name="x">The X-coordinate to move to.</param>
        /// <param name="y">The Y-coordinate to move to.</param>
        public void MoveTo(int x, int y)
        {
            try
            {
                if (x < 0 || x > XCanvasSize || y < 0 || y > YCanvasSize)
                    throw new CanvasException("Invalid screen position MoveTo: " + x + ", " + y);

                xPos = x;
                yPos = y;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error moving position: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Draws a rectangle with the specified dimensions and filled or outlined based on the given flag.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="filled">Indicates whether the rectangle should be filled.</param>
        public void Rect(int width, int height, bool filled)
        {
            try
            {
                if (width < 0 || height < 0)
                    throw new CanvasException("Invalid rectangle dimensions: " + width + ", " + height);

                if (filled)
                    g.FillRectangle(new SolidBrush(penColour), xPos, yPos, width, height);
                else
                    g.DrawRectangle(Pen, xPos, yPos, width, height);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error drawing rectangle: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Resets the current position to the origin (0, 0).
        /// </summary>
        public void Reset()
        {
            try
            {
                xPos = 0;
                yPos = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error resetting canvas: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Sets the size of the canvas and initializes the drawing surface.
        /// </summary>
        /// <param name="xsize">The width of the canvas.</param>
        /// <param name="ysize">The height of the canvas.</param>
        public void Set(int xsize, int ysize)
        {
            try
            {
                XCanvasSize = xsize;
                YCanvasSize = ysize;
                xPos = 0;
                yPos = 0;
                g = Graphics.FromImage(bm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error setting canvas size: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Sets the color of the pen using the specified RGB values.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        public void SetColour(int red, int green, int blue)
        {
            try
            {
                if (red > 255 || green > 255 || blue > 255)
                    throw new CanvasException("Invalid colour: " + red + ", " + green + ", " + blue);

                penColour = Color.FromArgb(255, red, green, blue);
                Pen = new Pen(penColour, penSize);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error setting pen color: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Draws a triangle with the specified width and height.
        /// </summary>
        /// <param name="width">The base width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public void Tri(int width, int height)
        {
            try
            {
                if (width < 0 || height < 0)
                    throw new CanvasException("Invalid triangle dimensions: width=" + width + ", height=" + height);

                Point[] points = new Point[]
                {
                    new Point(xPos, yPos),
                    new Point(xPos - width / 2, yPos + height),
                    new Point(xPos + width / 2, yPos + height)
                };

                if (g != null)
                    g.DrawPolygon(Pen, points);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error drawing triangle: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Writes the specified text at the current position on the canvas.
        /// </summary>
        /// <param name="text">The text to write on the canvas.</param>
        public void WriteText(string text)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    g.DrawString(text, new Font("Arial", 12), new SolidBrush(penColour), xPos, yPos);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error writing text: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves the current drawing as a bitmap image.
        /// </summary>
        /// <returns>The bitmap image representing the current drawing.</returns>
        public object getBitmap()
        {
            try
            {
                // Ensure the Bitmap object is initialized before returning it
                if (bm == null)
                {
                    throw new CanvasException("Bitmap has not been initialized. Cannot retrieve the current drawing.");
                }

                return bm;
            }
            catch (CanvasException ex)
            {
                // Catch any potential exceptions and throw a CanvasException
                throw new CanvasException($"\nAn error occurred while retrieving the Bitmap: {ex.Message}");
            }
        }
    }
} 