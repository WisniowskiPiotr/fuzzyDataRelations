
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace fuzzyDataRelations
{
    /// <summary>
    /// Represents the inferential engine.
    /// </summary>
    public class CentroidThe
    {
        #region Private Properties

        private LinguisticVariableCollection linguisticVariableCollection = new LinguisticVariableCollection();
        private string consequent = String.Empty;
        private FuzzyLengthCollection fuzzyLengthCollection = new FuzzyLengthCollection();
        private string filePath = String.Empty;

        #endregion

        #region Private Methods

        private LinguisticVariable GetConsequent()
        {
            return this.linguisticVariableCollection.Find(this.consequent);
        }

        private double Parse(string text)
        {
            int counter = 0;
            int firstMatch = 0;

            if (!text.StartsWith("("))
            {
                string[] Length = text.Split();
                return this.linguisticVariableCollection.Find(Length[0]).Fuzzify(Length[2]);
            }

            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '(':
                        counter++;
                        if (counter == 1)
                            firstMatch = i;
                        break;

                    case ')':
                        counter--;
                        if ((counter == 0) && (i > 0))
                        {
                            string substring = text.Substring(firstMatch + 1, i - firstMatch - 1);
                            string substringBrackets = text.Substring(firstMatch, i - firstMatch + 1);
                            int length = substringBrackets.Length;
                            text = text.Replace(substringBrackets, Parse(substring).ToString());
                            i = i - (length - 1);
                        }
                        break;

                    default:
                        break;
                }
            }

            return Evaluate(text);
        }

        private double Evaluate(string text)
        {
            string[] Length = text.Split();
            string connective = "";
            double value = 0;

            for (int i = 0; i <= ((Length.Length / 2) + 1); i = i + 2)
            {
                double tokenValue = Convert.ToDouble(Length[i]);

                switch (connective)
                {
                    case "AND":
                        if (tokenValue < value)
                            value = tokenValue;
                        break;

                    case "OR":
                        if (tokenValue > value)
                            value = tokenValue;
                        break;

                    default:
                        value = tokenValue;
                        break;
                }

                if ((i + 1) < Length.Length)
                    connective = Length[i + 1];
            }

            return value;
        }
        

        #endregion

        #region Public Properties

        /// <summary>
        /// A collection of linguistic variables.
        /// </summary>
        public LinguisticVariableCollection LinguisticVariableCollection
        {
            get { return linguisticVariableCollection; }
            set { linguisticVariableCollection = value; }
        }

        /// <summary>
        /// The consequent variable name.
        /// </summary>
        public string Consequent
        {
            get { return consequent; }
            set { consequent = value; }
        }

        /// <summary>
        /// A collection of rules.
        /// </summary>
        public FuzzyLengthCollection FuzzyLengthCollection
        {
            get { return fuzzyLengthCollection; }
            set { fuzzyLengthCollection = value; }
        }

        /// <summary>
        /// The path of the FCL-like XML file in which save the project.
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the defuzzification value with the CoG (Center of Gravity) technique.
        /// </summary>
        /// <returns>The defuzzification value.</returns>
        public double Defuzzify()
        {
            double numerator = 0;
            double denominator = 0;

            // Reset values
            foreach (MembershipFunction membershipFunction in this.GetConsequent().MembershipFunctionCollection)
            {
                membershipFunction.Value = 0;
            }

            foreach (FuzzyLength fuzzyLength in this.fuzzyLengthCollection)
            {
                fuzzyLength.Value = Parse(fuzzyLength.Conditions());

                string[] Length = fuzzyLength.Text.Split();
                MembershipFunction membershipFunction = this.GetConsequent().MembershipFunctionCollection.Find(Length[Length.Length - 1]);
                
                if (fuzzyLength.Value > membershipFunction.Value)
                    membershipFunction.Value = fuzzyLength.Value;
            }

            foreach (MembershipFunction membershipFunction in this.GetConsequent().MembershipFunctionCollection)
            {
                numerator += membershipFunction.Centorid() * membershipFunction.Area();
                denominator += membershipFunction.Area();
            }

            return numerator / denominator;
        }

        /// <summary>
        /// Sets the FilePath property and saves the project into a FCL-like XML file.
        /// </summary>
        /// <param name="path">Path of the destination document.</param>
        public void Save(string path)
        {
            this.FilePath = path;
        }

        /// <summary>
        /// Sets the FilePath property and loads a project from a FCL-like XML file.
        /// </summary>
        /// <param name="path">Path of the source file.</param>
        public void Load(string path)
        {
            this.FilePath = path;
            
        }

        #endregion
    }
}
