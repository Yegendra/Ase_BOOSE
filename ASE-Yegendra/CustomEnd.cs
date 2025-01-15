using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents a custom implementation of the <see cref="End"/> command, which controls the flow of program execution.
    /// The <see cref="CustomEnd"/> class extends the base <see cref="End"/> command and provides additional flexibility for execution and conditions.
    /// </summary>
    internal class CustomEnd:End
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomEnd"/> class.
        /// </summary>
        public CustomEnd() { }

        /// <summary>
        /// Prepares the command by evaluating any necessary expressions and setting up conditions.
        /// This method invokes the base <see cref="End"/> command's <see cref="Compile"/> method for further processing.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
        }

        /// <summary>
        /// Executes the command by directing the program flow to conclude the current process.
        /// This method calls the base <see cref="End"/> command's <see cref="Execute"/> method for core functionality.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
        }

        /// <summary>
        /// A method for defining custom restrictions, if necessary, for the <see cref="CustomEnd"/> command.
        /// This method calls the base class's <see cref="ReduceRestrictions"/> method to manage restriction logic.
        /// Currently, no additional restrictions are applied, but this method can be extended for future use.
        /// </summary>
        public override void Restrictions()
        {
            base.ReduceRestrictions();
        }
    }
}
