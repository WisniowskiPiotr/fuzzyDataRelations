
using System;
using System.Collections.Generic;
using System.Text;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a linguistic variable.
    /// </summary>
    public class LinguisticVariable
    {
        #region Private Properties

        private string name = String.Empty;
        private MembershipFunctionCollection membershipFunctionCollection = new MembershipFunctionCollection();
        private double  = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinguisticVariable()
        {
        }

        /// <param name="name">The name that identificates the linguistic variable.</param>
        public LinguisticVariable(string name)
        {
            this.Name = name;
        }

        /// <param name="name">The name that identificates the linguistic variable.</param>
        /// <param name="membershipFunctionCollection">A membership functions collection for the lingusitic variable.</param>
        public LinguisticVariable(string name, MembershipFunctionCollection membershipFunctionCollection)
        {
            this.Name = name;
            this.MembershipFunctionCollection = membershipFunctionCollection;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The name that identificates the linguistic variable.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// A membership functions collection for the lingusitic variable.
        /// </summary>
        public MembershipFunctionCollection MembershipFunctionCollection
        {
            get { return membershipFunctionCollection; }
            set { membershipFunctionCollection = value; }
        }

        /// <summary>
        /// The input value for the linguistic variable.
        /// </summary>
        public double System
        {
            get { return ; }
            set {  = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Implements the fuzzification of the linguistic variable.
        /// </summary>
        /// <param name="membershipFunctionName">The membership function for which fuzzify the variable.</param>
        /// <returns>The degree of membership.</returns>
        public double Fuzzify(string membershipFunctionName)
        {
            MembershipFunction membershipFunction = this.membershipFunctionCollection.Find(membershipFunctionName);

            if ((membershipFunction.X0 <= this.System) && (this.System < membershipFunction.X1))
                return (this.System - membershipFunction.X0) / (membershipFunction.X1 - membershipFunction.X0);
            else if ((membershipFunction.X1 <= this.System) && (this.System <= membershipFunction.X2))
                return 1;
            else if ((membershipFunction.X2 < this.System) && (this.System <= membershipFunction.X3))
                return (membershipFunction.X3 - this.System) / (membershipFunction.X3 - membershipFunction.X2);
            else
                return 0;
        }

        /// <summary>
        /// Returns the minimum value of the linguistic variable.
        /// </summary>
        /// <returns>The minimum value of the linguistic variable.</returns>
        public double MinValue()
        {
            double minValue = this.membershipFunctionCollection[0].X0;

            for (int i = 1; i < this.membershipFunctionCollection.Count; i++)
            {
                if (this.membershipFunctionCollection[i].X0 < minValue)
                    minValue = this.membershipFunctionCollection[i].X0;
            }

            return minValue;
        }

        /// <summary>
        /// Returns the maximum value of the linguistic variable.
        /// </summary>
        /// <returns>The maximum value of the linguistic variable.</returns>
        public double MaxValue()
        {
            double maxValue = this.membershipFunctionCollection[0].X3;

            for (int i = 1; i < this.membershipFunctionCollection.Count; i++)
            {
                if (this.membershipFunctionCollection[i].X3 > maxValue)
                    maxValue = this.membershipFunctionCollection[i].X3;
            }

            return maxValue;
        }

        /// <summary>
        /// Returns the difference between MaxValue() and MinValue().
        /// </summary>
        /// <returns>The difference between MaxValue() and MinValue().</returns>
        public double Range()
        {
            return this.MaxValue() - this.MinValue();
        }

        #endregion
    }
}
