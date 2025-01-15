using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Provides a customized implementation of the <see cref="Real"/> class for application-specific use cases.
    /// This class overrides base methods to introduce custom exception handling and restriction management.
    /// </summary>
    public class CustomReal : Real
    {
        /// <summary>
        /// Specifies any restrictions associated with this implementation. 
        /// Currently, no additional restrictions are applied, but this method can be extended in the future.
        /// </summary>
        public override void Restrictions()
        {
            // No restrictions to define for this implementation.
        }

        /// <summary>
        /// Executes the command by invoking the base functionality and provides custom exception handling.
        /// This method ensures any exceptions during execution are captured and rethrown with additional context.
        /// </summary>
        public override void Execute()
        {
            try
            {
                PerformExecution();
            }
            catch (Exception error)
            {
                HandleExecutionException(error);
            }
        }

        /// <summary>
        /// Handles the actual execution by invoking the base class's <see cref="Real.Execute"/> method.
        /// This method encapsulates the core logic for executing the command as defined by the base class.
        /// </summary>
        private void PerformExecution()
        {
            base.Execute();
        }

        /// <summary>
        /// Processes any exceptions that occur during execution by rethrowing them with additional context.
        /// This helps provide better insights into errors during execution.
        /// </summary>
        /// <param name="exception">The exception that occurred during execution.</param>
        private void HandleExecutionException(Exception exception)
        {
            throw new Exception($"Error during execution: {exception.Message}");
        }
    }
}
