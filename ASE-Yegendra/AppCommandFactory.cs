using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    // <summary>
    /// Factory class responsible for creating application-specific commands based on the provided command type.
    /// </summary>
    public class AppCommandFactory : CommandFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppCommandFactory"/> class.
        /// This constructor does not take any parameters and simply invokes the base class constructor.
        /// </summary>
        public AppCommandFactory() { }

        /// <summary>
        /// Creates a command object based on the provided <paramref name="commandType"/>.
        /// This method checks the input command type, validates it, and returns an instance of the corresponding command.
        /// If the command type is invalid or unrecognized, an exception is thrown.
        /// </summary>
        /// <param name="commandType">The type of the command to create (e.g., "tri", "clear", "write").</param>
        /// <returns>An instance of a command that implements the <see cref="ICommand"/> interface.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="commandType"/> is null or empty.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="commandType"/> is invalid or unrecognized.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown if there is any other error while creating the command.
        /// </exception>
        public override ICommand MakeCommand(string commandType)
        {
            try
            {
                // Ensure the command type is neither null nor empty
                if (string.IsNullOrEmpty(commandType))
                {
                    throw new ArgumentNullException(nameof(commandType), $"'{nameof(commandType)}' cannot be null or empty.");
                }

                // Normalize the commandType to lowercase and remove leading/trailing whitespaces
                commandType = commandType.ToLower().Trim();

                // Determine the corresponding command based on the provided commandType
                switch (commandType)
                {
                    case "tri":
                        return new AppTriangle();
                    case "clear":
                        return new AppClear();
                    case "write":
                        return new AppWrite();
                    case "reset":
                        return new AppReset();
                    case "int":
                        return new IntApp();
                    case "array":
                        return new CustomArray();
                    case "while":
                        return new CustomWhile();
                    case "else":
                        return new CustomElse();
                    case "real":
                        return new CustomReal();
                    case "if":
                        return new CustomIf();
                    case "end":
                        return new CustomEnd();
                    default:
                        // If the command is unrecognized, invoke the base class method to handle it
                        return base.MakeCommand(commandType);
                }
            }
            catch (ArgumentNullException)
            {
                // Re-throw ArgumentNullException as is, since it's already meaningful
                throw;
            }
            catch (Exception ex) when (ex is FactoryException || ex is InvalidOperationException)
            {
                // Catch other exceptions and throw a new exception with a detailed message
                throw new Exception($"Error while creating command: {ex.Message}", ex);
            }
        }
    }
}