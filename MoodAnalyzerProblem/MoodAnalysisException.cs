using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalysisException : Exception // Inherit parent exception class
    {
        public enum ExceptionType // Creating a enum with variable
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
            NOT_MATCH,
            METHOD_NOT_FOUND,
            FIELD_NOT_FOUND
        }
        public ExceptionType type; // Creating enum name type variable
        public MoodAnalysisException(ExceptionType type, string message):base(message) // Creating a constructor with parent class
        {
            this.type = type;// Assigning value
        }

    }
}
