using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Handles the animation logic for the car and obstacle in the game.
    /// </summary>
    internal class AnimationC
    {
        private PictureBox outputBox;
        private Rectangle car;
        private Rectangle obstacle;
        private int obstacleSpeed = 5;
        private bool isGameRunning = true;
        private Image carImage;
        private Image obstacleImage;
        private int score = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationC"/> class.
        /// </summary>
        /// <param name="outputBox">The picture box used for rendering the game.</param>
        public AnimationC(PictureBox outputBox)
        {
            this.outputBox = outputBox;
            car = new Rectangle(100, outputBox.Height - 100, 50, 100);
            obstacle = new Rectangle(outputBox.Width / 2, 0, 50, 50);
            carImage = Image.FromFile(@"C:\Users\immoral\Desktop\Ase\BOOSEexamplePrograms\6addYourProgramsHere\ASE-Yegendra\ASE-Yegendra\car.png");
            obstacleImage = Image.FromFile(@"C:\Users\immoral\Desktop\Ase\BOOSEexamplePrograms\6addYourProgramsHere\ASE-Yegendra\ASE-Yegendra\tree.png");
            outputBox.Paint += OutputBox_Paint;
            outputBox.MouseMove += OnMouseMove;
            outputBox.Focus();
        }

        /// <summary>
        /// Handles the paint event for the picture box to draw the car, obstacle, and score.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The paint event arguments.</param>
        private void OutputBox_Paint(object sender, PaintEventArgs e)
        {
            if (isGameRunning)
            {
                e.Graphics.DrawImage(carImage, car);
                e.Graphics.DrawImage(obstacleImage, obstacle);
                e.Graphics.DrawString("Score: " + score.ToString(), new Font("Arial", 14), Brushes.Black, new PointF(outputBox.Width - 100, 10));
            }
            else
            {
                string gameOverText = "Game Over";
                Font gameOverFont = new Font("Arial", 20);
                SizeF textSize = e.Graphics.MeasureString(gameOverText, gameOverFont);
                float x = (outputBox.Width - textSize.Width) / 2;
                float y = (outputBox.Height - textSize.Height) / 2;
                e.Graphics.DrawString(gameOverText, gameOverFont, Brushes.Black, new PointF(x, y));
            }
        }

        public void ResetGame()
        {
            score = 0;
            isGameRunning = true;
            car = new Rectangle(100, outputBox.Height - 100, 50, 100);
            obstacle = new Rectangle(outputBox.Width / 2, 0, 50, 50);
            outputBox.Invalidate();
        }

        /// <summary>
        /// Handles the mouse move event to move the car based on mouse position.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The mouse event arguments.</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            car.X = e.X - car.Width / 2;
            car.Y = e.Y - car.Height / 2;

            if (car.Left < 0) car.X = 0;
            if (car.Right > outputBox.Width) car.X = outputBox.Width - car.Width;
            if (car.Top < 0) car.Y = 0;
            if (car.Bottom > outputBox.Height) car.Y = outputBox.Height - car.Height;
        }



        /// <summary>
        /// Updates the game logic, including obstacle movement, score increase, and collision check.
        /// </summary>
        public void Update()
        {
            if (isGameRunning)
            {
                obstacle.Y += obstacleSpeed;
                if (obstacle.Y > outputBox.Height)
                {
                    obstacle.Y = 0;
                    obstacle.X = new Random().Next(0, outputBox.Width - obstacle.Width);
                    score++;
                }

                if (CheckCollision())
                {
                    isGameRunning = false;
                }
                outputBox.Invalidate();
            }
        }

        /// <summary>
        /// Checks if the car and obstacle collide.
        /// </summary>
        /// <returns>True if a collision is detected, otherwise false.</returns>
        private bool CheckCollision()
        {
            Bitmap carBitmap = new Bitmap(carImage);
            Bitmap obstacleBitmap = new Bitmap(obstacleImage);

            Rectangle intersection = Rectangle.Intersect(car, obstacle);
            if (intersection.Width > 0 && intersection.Height > 0)
            {
                for (int x = intersection.Left; x < intersection.Right; x++)
                {
                    for (int y = intersection.Top; y < intersection.Bottom; y++)
                    {
                        int carX = x - car.X;
                        int carY = y - car.Y;
                        int obstacleX = x - obstacle.X;
                        int obstacleY = y - obstacle.Y;

                        if (carX >= 0 && carX < carBitmap.Width && carY >= 0 && carY < carBitmap.Height &&
                            obstacleX >= 0 && obstacleX < obstacleBitmap.Width && obstacleY >= 0 && obstacleY < obstacleBitmap.Height)
                        {
                            Color carColor = carBitmap.GetPixel(carX, carY);
                            Color obstacleColor = obstacleBitmap.GetPixel(obstacleX, obstacleY);

                            if (carColor.A != 0 && obstacleColor.A != 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }


            return false;
        }
    }
}
