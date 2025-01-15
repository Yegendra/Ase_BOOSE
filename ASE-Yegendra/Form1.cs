using BOOSE;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;


namespace ASE_Yegendra
{
    /// <summary>
    /// Main form class for the ASE_Yegendra application.
    /// Provides functionalities for program execution and canvas rendering.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly ICanvas myCanvas;
        private readonly CommandFactory Factory;
        private readonly StoredProgram Program;
        private readonly Parser Parser;
        private AnimationC animation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Sets up the canvas, command factory, stored program, and parser.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            myCanvas = new canvasApp();
            Factory = new AppCommandFactory();
            Program = new StoredProgram(myCanvas);
            Parser = new Parser(Factory, Program);
            Refresh();
        }

        /// <summary>
        /// Handles the Paint event for the outputBox control.
        /// Draws the canvas bitmap onto the output box.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">Paint event arguments.</param>
        private void outputBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Bitmap b = (Bitmap)myCanvas.getBitmap();
                if (b != null)
                {
                    g.DrawImageUnscaled(b, 0, 0);
                }
                else
                {
                    debuggerWindow.AppendText("Warning: Canvas bitmap is null.");
                }
            }
            catch (Exception ex)
            {
                debuggerWindow.AppendText($"An error occurred while rendering the canvas: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the Click event for the Run button.
        /// Parses and executes the program entered in the ProgramWindow.
        /// </summary>
        /// <param name="sender">The event source.</param>
        /// <param name="e">Event arguments.</param>
        private void runBtn_Click(object sender, EventArgs e)
        {
            string ProgramText = ProgramWindow.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(ProgramText))
                {
                    throw new ArgumentException("The program text cannot be empty.");
                }

                Parser.ParseProgram(ProgramText);
                Program.Run();
            }
            catch (ArgumentNullException ex)
            {
                debuggerWindow.AppendText($"{ex.Message}");
            }
            catch (ArgumentException ex)
            {
                debuggerWindow.AppendText($"{ex.Message}");
            }
            catch (CanvasException ex)
            {
                debuggerWindow.AppendText($"{ex.Message}");
            }
            catch (ParserException ex)
            {
                debuggerWindow.AppendText($" {ex.Message}");
            }
            catch (Exception ex)
            {
                debuggerWindow.AppendText($"{ex.Message}");
            }
            Refresh();
        }

        // <summary>
        /// Handles unexpected application-level exceptions.
        /// </summary>
        /// <param name="sender">The source of the unhandled exception.</param>
        /// <param name="e">Exception arguments.</param>
        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            debuggerWindow.AppendText($"An unhandled exception occurred: {e.Exception.Message}\n");
        }
        /// <summary>
        ///  handles the clikc even for games
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationBtn_Click(object sender, EventArgs e)
        {
            if (animation != null)
            {
                animation.ResetGame();
            }
            else
            {
                animation = new AnimationC(outputBox);
            }

            Timer gameTimer = new Timer();
            gameTimer.Interval = 100;
            gameTimer.Tick += (s, ev) =>
            {
                if (animation != null)
                {
                    animation.Update();
                }
            };
            gameTimer.Start();
        }
    }
}
