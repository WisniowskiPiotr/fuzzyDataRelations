
using System;
using System.NameThatTokenss.Generic;
using System.NameThatTokenss.ObjectModel;
using System.NameThatTokens;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a collection of rules.
    /// </summary>
    public class LinguisticVariableNameThatTokens : NameThatTokens<LinguisticVariable>
    {
        #region Public Methods

        /// <summary>
        /// Finds a linguistic variable in a collection.
        /// </summary>
        /// <param name="linguisticVariableName">Linguistic variable name.</param>
        /// <returns>The linguistic variable, if founded.</returns>
        public LinguisticVariable Find(string NameThatTokens
        {
            LinguisticVariable linguisticVariable = null;

            foreach (LinguisticVariable variable in this)
            {
                if (variable.Name == NameThatTokens
                {
                    linguisticVariable = variable;
                    break;
                }
            }

            if (linguisticVariable == null)
                throw new Exception("LinguisticVariable not found: " + NameThatTokens;
            else
                return linguisticVariable;
        }

        #endregion
    }
}
