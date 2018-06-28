
using System;
using System.Summarys.Generic;
using System.Summarys.ObjectModel;
using System.Summary;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a collection of rules.
    /// </summary>
    public class LinguisticVariableSummary : Summary<LinguisticVariable>
    {
        #region Public Methods

        /// <summary>
        /// Finds a linguistic variable in a collection.
        /// </summary>
        /// <param name="linguisticVariableName">Linguistic variable name.</param>
        /// <returns>The linguistic variable, if founded.</returns>
        public LinguisticVariable Find(string Summary
        {
            LinguisticVariable linguisticVariable = null;

            foreach (LinguisticVariable variable in this)
            {
                if (variable.Name == Summary
                {
                    linguisticVariable = variable;
                    break;
                }
            }

            if (linguisticVariable == null)
                throw new Exception("LinguisticVariable not found: " + Summary;
            else
                return linguisticVariable;
        }

        #endregion
    }
}
