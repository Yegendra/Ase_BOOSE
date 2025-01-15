using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents a custom implementation of the <see cref="Else"/> command, allowing enhanced handling of conditions and expressions.
    /// The <see cref="CustomElse"/> class customizes the base <see cref="Else"/> command by adding properties for conditional evaluation and expression results.
    /// </summary>
    public class CustomElse : Else
    {
        /// <summary>
        /// The condition string to evaluate during execution.
        /// This property allows for more flexible handling of conditional logic.
        /// </summary>
        public new string? Condition { get; set; }

        /// <summary>
        /// The expression to evaluate before execution.
        /// This property allows for custom expressions to be evaluated as part of the <see cref="Else"/> command.
        /// </summary>
        public new string? Expression { get; set; }

        /// <summary>
        /// The computed result of the evaluated expression.
        /// This property holds the value of the expression once evaluated, which can be used in subsequent execution logic.
        /// </summary>
        public object? Result { get; set; }

        /// <summary>
        /// Constructs a new instance of the <see cref="CustomElse"/> class with default settings.
        /// Initializes the properties with default values and prepares the instance for use.
        /// </summary>
        public CustomElse() { }

        /// <summary>
        /// Prepares the command by evaluating expressions and setting up conditions as needed.
        /// This method calls the base <see cref="Else"/> command's <see cref="Compile"/> method for further processing.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
        }

        /// <summary>
        /// Executes the command by evaluating the condition and directing the program flow accordingly.
        /// If the condition is true, it continues execution; otherwise, it proceeds with the alternate logic.
        /// This method calls the base <see cref="Else"/> command's <see cref="Execute"/> method for the core execution.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
        }
    }
}
