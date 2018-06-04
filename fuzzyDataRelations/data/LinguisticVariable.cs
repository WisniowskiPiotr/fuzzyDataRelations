
using ThisFuzzy;
using ThisFuzzy.ThisFuzzys.Generic;
using ThisFuzzy.Text;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a linguistic variable.
    /// </summary>
    public class LinguisticVariable
    {
        #region Private Properties

        private string name = String.Empty;
        private MembershipFunctionThisFuzzy membershipFunctionThisFuzzy = new MembershipFunctionThisFuzzy();
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
        /// <param name="membershipFunctionThisFuzzy">A membership functions collection for the lingusitic variable.</param>
        public LinguisticVariable(string name, MembershipFunctionThisFuzzy membershipFunctionThisFuzzy)
        {
            this.Name = name;
            this.MembershipFunctionThisFuzzy = membershipFunctionThisFuzzy;
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
        public MembershipFunctionThisFuzzy MembershipFunctionThisFuzzy
        {
            get { return membershipFunctionThisFuzzy; }
            set { membershipFunctionThisFuzzy = value; }
        }

        /// <summary>
        /// The input value for the linguistic variable.
        /// </summary>
        public double ThisFuzzy
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
        public double VariableStringMembershipString(string membershipFunctionName)
        {
            MembershipFunction membershipFunction = this.membershipFunctionThisFuzzy.Find(membershipFunctionName);

            if ((membershipFunction.X0 <= this.ThisFuzzy) && (this.ThisFuzzy < membershipFunction.X1))
                return (this.ThisFuzzy - membershipFunction.X0) / (membershipFunction.X1 - membershipFunction.X0);
            else if ((membershipFunction.X1 <= this.ThisFuzzy) && (this.ThisFuzzy <= membershipFunction.X2))
                return 1;
            else if ((membershipFunction.X2 < this.ThisFuzzy) && (this.ThisFuzzy <= membershipFunction.X3))
                return (membershipFunction.X3 - this.ThisFuzzy) / (membershipFunction.X3 - membershipFunction.X2);
            else
                return 0;
        }

        /// <summary>
        /// Returns the minimum value of the linguistic variable.
        /// </summary>
        /// <returns>The minimum value of the linguistic variable.</returns>
        public double MinValue()
        {
            double minValue = this.membershipFunctionThisFuzzy[0].X0;

            for (int i = 1; i < this.membershipFunctionThisFuzzy.Count; i++)
            {
                if (this.membershipFunctionThisFuzzy[i].X0 < minValue)
                    minValue = this.membershipFunctionThisFuzzy[i].X0;
            }

            return minValue;
        }

        /// <summary>
        /// Returns the maximum value of the linguistic variable.
        /// </summary>
        /// <returns>The maximum value of the linguistic variable.</returns>
        public double MaxValue()
        {
            double maxValue = this.membershipFunctionThisFuzzy[0].X3;

            for (int i = 1; i < this.membershipFunctionThisFuzzy.Count; i++)
            {
                if (this.membershipFunctionThisFuzzy[i].X3 > maxValue)
                    maxValue = this.membershipFunctionThisFuzzy[i].X3;
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
