using BOOSE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Represents a command to write text on the canvas, supporting string concatenation, arithmetic operations, and variable references.
    /// The content of the text can be a literal string, an arithmetic expression, or a reference to a variable.
    /// </summary>
    public class AppWrite : CommandOneParameter
    {
        private string _content;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppWrite"/> class.
        /// This constructor does not take any parameters and is typically used for default initialization.
        /// </summary>
        public AppWrite() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppWrite"/> class with the specified canvas and content.
        /// </summary>
        /// <param name="canvas">The canvas on which the text will be written.</param>
        /// <param name="content">The content to be written on the canvas.</param>
        public AppWrite(Canvas canvas, string content) : base(canvas)
        {
            _content = content;
            parameters = new[] { content };
        }

        /// <summary>
        /// Executes the write command to render the text on the canvas, processing expressions as necessary.
        /// The method evaluates string concatenation, arithmetic operations, and variable references.
        /// </summary>
        /// <exception cref="Exception">
        /// Thrown when an error occurs during execution, such as an invalid expression or missing parameters.
        /// </exception>
        public override void Execute()
        {
            try
            {
                if (parameters == null || parameters.Length == 0)
                    throw new Exception("No parameters provided.");

                string text = parameters[0];
                text = FormatExpression(text);

                // Process the expression based on its format
                if (text.StartsWith("\"") && text.EndsWith("\""))
                    _content = HandleStringLiteral(text);
                else if (text.Contains("\"") && text.Contains("+"))
                    _content = ConcatenateStrings(text);
                else if (text.Contains(" + ") || text.Contains(" - ") || text.Contains(" * ") || text.Contains(" / "))
                    _content = EvaluateArithmeticOperations(text);
                else if (IsVariableReference(text))
                    _content = GetVariableValue(text).ToString();
                else
                    _content = "Invalid expression";

                // Write the processed content to the canvas
                canvas.WriteText(_content);
            }
            catch (Exception ex)
            {
                throw new Exception($"Execution error: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Formats an expression by adding spaces around operators and trimming extra spaces.
        /// This ensures consistency in the format for evaluation.
        /// </summary>
        /// <param name="expression">The expression to format.</param>
        /// <returns>A formatted version of the expression with spaces around operators.</returns>
        private string FormatExpression(string expression) =>
            Regex.Replace(Regex.Replace(expression, @"(?<=[=+\-*/])|(?=[=+\-*/])", " ").Trim(), @"\s{2,}", " ");

        /// <summary>
        /// Concatenates strings in an expression, handling literals and variables.
        /// This method processes string concatenations using the '+' operator.
        /// </summary>
        /// <param name="expression">The expression containing string concatenations.</param>
        /// <returns>The concatenated string result.</returns>
        private string ConcatenateStrings(string expression)
        {
            var parts = expression.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("", parts.Select(p => p.Trim().Trim('"')));
        }

        /// <summary>
        /// Evaluates arithmetic operations in the expression.
        /// This method supports addition, subtraction, multiplication, and division operations.
        /// </summary>
        /// <param name="expression">The expression containing arithmetic operations.</param>
        /// <returns>The result of the arithmetic operations as a string.</returns>
        /// <exception cref="Exception">
        /// Thrown when an invalid operator is encountered or if division by zero occurs.
        /// </exception>
        private string EvaluateArithmeticOperations(string expression)
        {
            var components = expression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double result = GetVariableValue(components[0]);

            for (int i = 1; i < components.Length; i += 2)
            {
                double operand = GetVariableValue(components[i + 1]);
                result = components[i] switch
                {
                    "+" => result + operand,
                    "-" => result - operand,
                    "*" => result * operand,
                    "/" => operand == 0 ? throw new Exception("Division by zero") : result / operand,
                    _ => throw new Exception($"Invalid operator '{components[i]}'")
                };
            }

            return result.ToString();
        }

        /// <summary>
        /// Checks if the text represents a variable reference (i.e., no operators or spaces are present).
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns>True if the text is a variable reference, otherwise false.</returns>
        private bool IsVariableReference(string text) =>
            !string.IsNullOrWhiteSpace(text) && !text.Contains(" ") && !text.Any(c => "+-*/".Contains(c));

        /// <summary>
        /// Retrieves the value of a variable or literal operand.
        /// If the operand is a number, it is returned directly; otherwise, the variable's value is fetched.
        /// </summary>
        /// <param name="operand">The operand to evaluate (either a number or a variable).</param>
        /// <returns>The value of the operand (either a number or a variable's value).</returns>
        /// <exception cref="Exception">
        /// Thrown if the operand is not a valid number or variable.
        /// </exception>
        private double GetVariableValue(string operand)
        {
            if (double.TryParse(operand, out double value)) return value;

            var variable = Program.GetVariable(operand);
            return variable switch
            {
                Real r => r.Value,
                Int i => i.Value,
                _ => throw new Exception($"Variable '{operand}' not found or invalid type.")
            };
        }

        /// <summary>
        /// Validates the parameters for the write command.
        /// Ensures that exactly one non-empty parameter is provided.
        /// </summary>
        /// <param name="parameters">The list of parameters provided to the write command.</param>
        /// <exception cref="Exception">
        /// Thrown if the number of parameters is not exactly one or if the parameter is empty.
        /// </exception>
        public override void CheckParameters(string[] parameters)
        {
            if (parameters == null || parameters.Length != 1 || string.IsNullOrWhiteSpace(parameters[0]))
            {
                throw new Exception("The 'write' command requires exactly one non-empty parameter.");
            }
        }

        /// <summary>
        /// Handles a string literal by trimming quotes from the edges.
        /// </summary>
        /// <param name="text">The text containing the string literal (with quotes).</param>
        /// <returns>The content of the string literal without the surrounding quotes.</returns>
        private string HandleStringLiteral(string text) => text.Trim('"');
    }
}
