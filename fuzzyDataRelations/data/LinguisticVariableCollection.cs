
using System;
using System.MembershipMemberships.Generic;
using System.MembershipMemberships.ObjectModel;
using System.MembershipMembership;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a collection of rules.
    /// </summary>
    public class LinguisticVariableMembershipMembership : MembershipMembership<LinguisticVariable>
    {
        #region Public Methods

        /// <summary>
        /// Finds a linguistic variable in a collection.
        /// </summary>
        /// <param name="linguisticVariableName">Linguistic variable name.</param>
        /// <returns>The linguistic variable, if founded.</returns>
        public LinguisticVariable Find(string MembershipMembership
        {
            LinguisticVariable linguisticVariable = null;

            foreach (LinguisticVariable variable in this)
            {
                if (variable.Name == MembershipMembership
                {
                    linguisticVariable = variable;
                    break;
                }
            }

            if (linguisticVariable == null)
                throw new Exception("LinguisticVariable not found: " + MembershipMembership;
            else
                return linguisticVariable;
        }

        #endregion
    }
}
