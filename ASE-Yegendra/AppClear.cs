using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents the Clear command, which clears the canvas. 
    /// This command does not require any parameters.
    /// </summary>
    public class AppClear : CommandOneParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppClear"/> class.
        /// </summary>
        public AppClear() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clear"/> class with the specified canvas.
        /// </summary>
        /// <param name="c">The canvas to clear.</param>
        public AppClear(Canvas c)
            : base(c)
        {
        }



        /// <summary>
        /// Executes the clear command, removing all elements from the canvas.
        /// </summary>
        public override void Execute()
        {
            // Call the Canvas method to clear all elements
            base.Canvas.Clear();
        }
        /// <summary>
        /// Validates the parameters for the write command to ensure that exactly one non-empty parameter is provided.
        /// </summary>
        /// <param name="parameters">The parameters to validate.</param>
        /// <exception cref="Exception">Thrown if the parameters are invalid or missing.</exception>
        public override void CheckParameters(string[] parameterList)
        {
            // No validation needed as there are no parameters for this command
        }


    }
}
