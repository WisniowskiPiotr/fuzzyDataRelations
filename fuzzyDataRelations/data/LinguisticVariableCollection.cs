
using System;
using System.NameBracketss.Generic;
using System.NameBracketss.ObjectModel;
using System.NameBrackets;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a collection of rules.
    /// </summary>
    public class LinguisticVariableNameBrackets : NameBrackets<LinguisticVariable>
    {
        #region Public Methods

        /// <summary>
        /// Finds a linguistic variable in a collection.
        /// </summary>
        /// <param name="linguisticVariableName">Linguistic variable name.</param>
        /// <returns>The linguistic variable, if founded.</returns>
        public LinguisticVariable Find(string NameBrackets
        {
            LinguisticVariable linguisticVariable = null;

            foreach (LinguisticVariable variable in this)
            {
                if (variable.Name == NameBrackets
                {
                    linguisticVariable = variable;
                    break;
                }
            }

            if (linguisticVariable == null)
                throw new Exception("LinguisticVariable not found: " + NameBrackets;
            else
                return linguisticVariable;
        }

        #endregion
    }
}
