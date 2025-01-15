using ASE_Yegendra;
using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ase_YegendraTest
{
    /// <summary>
    /// Unit tests for the <see cref="AppCommandFactory"/> class.
    /// This test class verifies that the <see cref="AppCommandFactory"/> correctly creates instances of the respective command classes.
    /// </summary>
    [TestClass]
    public class AppCommandFactoryTest
    {
        private AppCommandFactory commandFactory;

        /// <summary>
        /// Initializes the test environment before each test method runs.
        /// This method is executed before each test method to ensure the command factory is available for all tests.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            commandFactory = new AppCommandFactory();
        }

        /// <summary>
        /// Verifies that the "tri" command creates an instance of <see cref="AppTriangle"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Tri_ShouldReturnAppTriangle()
        {
            // Arrange
            string command = "tri";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AppTriangle), "The command 'tri' should return an AppTriangle object.");
        }

        /// <summary>
        /// Tests that the "clear" command creates an instance of AppClear.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Clear_ShouldReturnAppClear()
        {
            // Arrange
            string command = "clear";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AppClear), "The command 'clear' should return an AppClear object.");
        }

        /// <summary>
        /// Verifies that the "write" command creates an instance of <see cref="AppClear"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Write_ShouldReturnAppWrite()
        {
            // Arrange
            string command = "write";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AppWrite), "The command 'write' should return an AppWrite object.");
        }

        /// <summary>
        /// Verifies that the "reset" command creates an instance of <see cref="AppWrite"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Reset_ShouldReturnAppReset()
        {
            // Arrange
            string command = "reset";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AppReset), "The command 'reset' should return an AppReset object.");
        }

        /// <summary>
        /// Verifies that the "int" command creates an instance of <see cref="AppReset"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Int_ShouldReturnIntApp()
        {
            // Arrange
            string command = "int";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IntApp), "The command 'int' should return an IntApp object.");
        }

        /// <summary>
        /// Verifies that the "array" command creates an instance of <see cref="IntApp"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Array_ShouldReturnCustomArray()
        {
            // Arrange
            string command = "array";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CustomArray), "The command 'array' should return a CustomArray object.");
        }

        /// <summary>
        /// Verifies that the "while" command creates an instance of <see cref="CustomArray"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_While_ShouldReturnCustomWhile()
        {
            // Arrange
            string command = "while";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CustomWhile), "The command 'while' should return a CustomWhile object.");
        }

        /// <summary>
        /// Verifies that the "else" command creates an instance of <see cref="CustomWhile"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Else_ShouldReturnCustomElse()
        {
            // Arrange
            string command = "else";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CustomElse), "The command 'else' should return a CustomElse object.");
        }

        /// <summary>
        /// Verifies that the "real" command creates an instance of <see cref="CustomElse"/>.
        /// </summary>
        [TestMethod]
        public void TestMakeCommand_Real_ShouldReturnCustomReal()
        {
            // Arrange
            string command = "real";

            // Act
            ICommand result = commandFactory.MakeCommand(command);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CustomReal), "The command 'real' should return a CustomReal object.");
        }

        /// <summary>
        /// Verifies that a null command throws an <see cref="ArgumentNullException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMakeCommand_NullCommand_ShouldThrowArgumentNullException()
        {
            // Arrange
            string command = null;

            // Act
            commandFactory.MakeCommand(command);

            // Assert handled by ExpectedException
        }

        /// <summary>
        /// Verifies that a null command throws an <see cref="ArgumentNullException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMakeCommand_EmptyCommand_ShouldThrowArgumentNullException()
        {
            // Arrange
            string command = string.Empty;

            // Act
            commandFactory.MakeCommand(command);

            // Assert handled by ExpectedException
        }

        /// <summary>
        /// Verifies that an invalid command throws a generic <see cref="Exception"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMakeCommand_InvalidCommand_ShouldThrowException()
        {
            // Arrange
            string command = "invalidcommand";

            // Act
            commandFactory.MakeCommand(command);

            // Assert handled by ExpectedException
        }
    }
}
