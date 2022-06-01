using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerFactory
    {
        public object CreateMoodAnalyzerObject(string className,string constructor)
        {
            try
            {
                if (className == null || constructor == null) // If any field null then throw exception
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NULL_MESSAGE, "Class name or constructor name should not be null");
                }
                string pattern = "."+constructor+"$"; // regex for class
                Match result = Regex.Match(className, pattern); // Checking that Class name and constructor name is equal or not             

                if (result.Success) // If class name matched with constructor name then 
                {
                    try
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        Type moodAnalyzerType = assembly.GetType(className); // Get the class name type from assembly
                        return Activator.CreateInstance(moodAnalyzerType);
                    }
                    catch (ArgumentNullException) //If class not found in assembly then throw exception
                    {
                        throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                    }
                }
                else // Constructor name not matched with class name then throw exception like constructor not found
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                }
            }
            catch (MoodAnalysisException e)
            {
                return e.Message;
            }
        }
        public object CreateMoodAnalyzerParameterizedObject(string className, string constructor,string message)
        {
            try
            {
                if (className == null || constructor == null || message == null) // If any field is null then throw exception
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NULL_MESSAGE, "Class name,constructor name or message should not be null");
                }
                Type type = typeof(MoodAnalyzer); // Getting a type of MoodAnalyzer class
                if (type.Name.Equals(className) || type.FullName.Equals(className)) // If actual type name of Mood Analyzer class is matching with given class name throw create object
                {
                    if (type.Name.Equals(constructor)) // If class name is match with constructor then create parameterized object of class
                    {
                        ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) }); //Getting constructor which hase one parameter of type string
                        return constructorInfo.Invoke(new object[] { message }); //Invoking a object
                    }
                    else // else throw exception constructor not found
                    {
                        throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                    }
                }
                else  //else throw exception class not found
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            catch (MoodAnalysisException e)
            {
                return e.Message;
            }
        }
        
    }
}
