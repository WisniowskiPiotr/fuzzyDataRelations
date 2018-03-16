
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents a collection of rules.
    /// </summary>
    public class LinguisticVariableCollection : Collection<LinguisticVariable>
    {
        #region Public Methods

        /// <summary>
        /// Finds a linguistic variable in a collection.
        /// </summary>
        /// <param name="linguisticVariableName">Linguistic variable name.</param>
        /// <returns>The linguistic variable, if founded.</returns>
        public LinguisticVariable Find(string NameValue
        {
            LinguisticVariable linguisticVariable = null;

            foreach (LinguisticVariable variable in this)
            {
                if (variable.Name == NameValue
                {
                    linguisticVariable = variable;
                    break;
                }
            }

            if (linguisticVariable == null)
                throw new Exception("LinguisticVariable not found: " + NameValue;
            else
                return linguisticVariable;
        }

        #endregion
    }
}
