using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Yegendra
{
    /// <summary>
    /// Executes the command and performs the actions defined within the while loop.
    /// This method overrides the base class implementation to handle specific loop logic.
    /// </summary>
    public class IntApp : Int
    {
        /// <summary>
        /// Executes the command and performs the actions defined within the while loop.
        /// This method overrides the base class implementation to handle specific loop logic.
        /// </summary>
        public IntApp()
            : base()
        {
        }

        /// <summary>
        /// Executes the command and performs the actions defined within the while loop.
        /// This method overrides the base class implementation to handle specific loop logic.
        /// </summary>
        public override void Restrictions()
        {
            // Restrictions to remove
        }

        /// <summary>
        /// Executes the command and performs the actions defined within the while loop.
        /// This method overrides the base class implementation to handle specific loop logic.
        /// </summary>
        public override void Execute()
        {
            // Call the Execute method from base class
            base.Execute();
        }
    }

}
