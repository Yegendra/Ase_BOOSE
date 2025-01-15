using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents a tailored implementation of the <see cref="While"/> command for application-specific requirements.
    /// This custom class overrides base methods to introduce specific behaviors related to loop execution and restriction management.
    /// </summary>
    public class CustomWhile:BOOSE.While
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomWhile"/> class with default settings.
        /// This constructor ensures that any necessary loop initializations or restrictions are applied.
        /// </summary>
        public CustomWhile()
        {
            InitializeLoop();
        }

        /// <summary>
        /// Compiles the command by preparing all necessary expressions or variables required for execution.
        /// This method ensures that the loop is correctly set up before execution.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
        }

        /// <summary>
        /// Executes the command and performs the actions defined within the while loop.
        /// This method overrides the base class implementation to handle specific loop logic.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
        }

        /// <summary>
        /// Executes the command and performs the actions defined within the while loop.
        /// This method overrides the base class implementation to handle specific loop logic.
        /// </summary>
        private void InitializeLoop()
        {
            base.ReduceRestrictions();
        }
    }
}
