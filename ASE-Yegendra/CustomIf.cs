using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{

    /// <summary>
    /// Provides a custom implementation of the <see cref="If"/> command to allow enhanced functionality.
    /// The <see cref="CustomIf"/> class customizes the base <see cref="If"/> command, offering additional control over the execution logic and restrictions.
    /// </summary>
    public class CustomIf : If
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomIf"/> class and adjusts any execution restrictions as needed.
        /// This constructor removes certain restrictions to allow more flexible control flow.
        /// </summary>
        public CustomIf()
        {
            RemoveExecutionRestrictions();
        }

        /// <summary>
        /// Compiles the command, preparing it for execution.
        /// This method invokes the base class's <see cref="If.Compile"/> method for further compilation steps.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
        }

        /// <summary>
        /// Executes the command, evaluating the condition and controlling program flow.
        /// This method invokes the base class's <see cref="If.Execute"/> method for the core execution logic.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
        }

        /// <summary>
        /// Removes any execution restrictions by calling the base class's <see cref="ReduceRestrictions"/> method.
        /// This method allows for the command to be executed without certain predefined limitations.
        /// </summary>
        private void RemoveExecutionRestrictions()
        {
            base.ReduceRestrictions();
        }
    }
}
