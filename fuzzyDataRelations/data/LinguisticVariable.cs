
using ParamSummary;
using ParamSummary.ParamSummarys.Generic;
using ParamSummary.Text;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a linguistic variable.
    /// </summary>
    public class LinguisticVariable
    {
        #region Private Properties

        private string name = String.Empty;
        private MembershipFunctionParamSummary membershipFunctionParamSummary = new MembershipFunctionParamSummary();
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
        /// <param name="membershipFunctionParamSummary">A membership functions collection for the lingusitic variable.</param>
        public LinguisticVariable(string name, MembershipFunctionParamSummary membershipFunctionParamSummary)
        {
            this.Name = name;
            this.MembershipFunctionParamSummary = membershipFunctionParamSummary;
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
        public MembershipFunctionParamSummary MembershipFunctionParamSummary
        {
            get { return membershipFunctionParamSummary; }
            set { membershipFunctionParamSummary = value; }
        }

        /// <summary>
        /// The input value for the linguistic variable.
        /// </summary>
        public double ParamSummary
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
        public double System(string membershipFunctionName)
        {
            MembershipFunction membershipFunction = this.membershipFunctionParamSummary.Find(membershipFunctionName);

            if ((membershipFunction.X0 <= this.ParamSummary) && (this.ParamSummary < membershipFunction.X1))
                return (this.ParamSummary - membershipFunction.X0) / (membershipFunction.X1 - membershipFunction.X0);
            else if ((membershipFunction.X1 <= this.ParamSummary) && (this.ParamSummary <= membershipFunction.X2))
                return 1;
            else if ((membershipFunction.X2 < this.ParamSummary) && (this.ParamSummary <= membershipFunction.X3))
                return (membershipFunction.X3 - this.ParamSummary) / (membershipFunction.X3 - membershipFunction.X2);
            else
                return 0;
        }

        /// <summary>
        /// Returns the minimum value of the linguistic variable.
        /// </summary>
        /// <returns>The minimum value of the linguistic variable.</returns>
        public double MinValue()
        {
            double minValue = this.membershipFunctionParamSummary[0].X0;

            for (int i = 1; i < this.membershipFunctionParamSummary.Count; i++)
            {
                if (this.membershipFunctionParamSummary[i].X0 < minValue)
                    minValue = this.membershipFunctionParamSummary[i].X0;
            }

            return minValue;
        }

        /// <summary>
        /// Returns the maximum value of the linguistic variable.
        /// </summary>
        /// <returns>The maximum value of the linguistic variable.</returns>
        public double MaxValue()
        {
            double maxValue = this.membershipFunctionParamSummary[0].X3;

            for (int i = 1; i < this.membershipFunctionParamSummary.Count; i++)
            {
                if (this.membershipFunctionParamSummary[i].X3 > maxValue)
                    maxValue = this.membershipFunctionParamSummary[i].X3;
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
