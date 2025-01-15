using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents the Reset command, which resets the canvas to its initial state.
    /// This command does not require any parameters.
    /// </summary>
    public class AppReset : CommandOneParameter
    {
        // <summary>
        /// Initializes a new instance of the <see cref="AppReset"/> class.
        /// </summary>
        public AppReset() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reset"/> class with the specified canvas.
        /// </summary>
        /// <param name="c">The canvas to reset.</param>
        public AppReset(Canvas c)
            : base(c)
        {
        }

        /// <summary>
        /// Executes the Reset command. Resets the canvas to its initial state if the parameters are valid.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the command cannot be executed due to invalid parameters.
        /// </exception>
        public override void Execute()
        {
            base.Canvas.Reset();
        }

        /// <summary>
        /// Validates that no parameters are provided for this command.
        /// </summary>
        public override void CheckParameters(string[] parameters)
        {
          
        }



    }
}
