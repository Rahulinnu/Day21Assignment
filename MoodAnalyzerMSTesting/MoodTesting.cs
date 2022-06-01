using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using System;

namespace MoodAnalyzerMSTesting
{
    [TestClass]
    public class MoodTesting
    {
        MoodAnalyzerFactory moodAnalyzerFactory;
        /// <summary>
        /// Common Arrange for all test cases
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            moodAnalyzerFactory = new MoodAnalyzerFactory();
        }
        /// <summary>
        /// Refactor TC 1.1 - Given “I am in Sad Mood” message Should Return SAD
        /// </summary>
        [TestCategory("Exception")]
        [TestMethod] //Refactor TC 1.1 SAD mood testing
        public void GivenSadMoodShouldReturnSAD()
        {
            //Arrange
            string exepected = "SAD";
            string message = "I am in sad mood";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            //Act
            string actual = moodAnalyzer.AnalyzeMood();
            //Assert
            Assert.AreEqual(exepected, actual);
        }
        /// <summary>
        /// Refactor TC 1.2 Given “I am in Any Mood” message Should Return HAPPY
        /// </summary>
        [TestCategory("Exception")]
        [TestMethod] //Refactor TC 1.2 Happy mood testing - If there is no sad word in message then returns happy mood
        public void GivenAnyMoodShouldReturnHappy()
        {
            //Arrange
            string exepected = "HAPPY";
            string message = "I am in happy mood";
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            //Act
            string actual = moodAnalyzer.AnalyzeMood();
            //Assert
            Assert.AreEqual(exepected, actual);
        }
        /// <summary>
        /// TC 2.1 Given Null Mood Should Return Happy
        /// </summary>
        //TestMethod] // TC 2.1 If message is null then returns happy mood
        //public void GivenNULLMoodShouldReturnHappy()
        //{
        //    //Arrange
        //    string exepected = "HAPPY";
        //    string message = null;
        //    MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
        //    //Act
        //    string actual = moodAnalyzer.AnalyzeMood();
        //    //Assert
        //    Assert.AreEqual(exepected, actual);
        //}
        /// <summary>
        /// TC 3.1 - Given NULL Mood Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Exception")]
        [TestMethod] // TC 3.1 If message is null then throws the MoodAnalysisexception
        public void GivenNullMoodThrowMoodAnalysisException()
        {
            try
            {
                //Arrange
                string message = null;
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                //Act
                string actual = moodAnalyzer.AnalyzeMood();
                
            }
            catch(MoodAnalysisException ex)
            {
                //Assert
                Assert.AreEqual("Message should not be null", ex.Message);
            }
        }
        /// <summary>
        /// TC 3.2 - Given Empty Mood Should Throw MoodAnalysisException indicating Empty Mood
        /// </summary>
        [TestCategory("Exception")]
        [TestMethod] // TC 3.2 If message is empty then throws the MoodAnalysisexception
        public void GivenEmptyMoodThrowMoodAnalysisException()
        {
            try
            {
                //Arrange
                string message = "";
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                //Act
                string actual = moodAnalyzer.AnalyzeMood();
            }
            catch (MoodAnalysisException ex)
            {
                //Assert
                Assert.AreEqual("Message should not be empty", ex.Message);
            }
        }
        /// <summary>
        /// TC 4.1 Given MoodAnalyser Class Name Should Return MoodAnalyser object
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenClassNameShoulReturnObject()
        {           
            object expected = new MoodAnalyzer();
            object actual = moodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(actual);           
        }
        /// <summary>
        /// TC 4.2 Given Class Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidClassThrowException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.Mood", "Mood");
            }
            catch(MoodAnalysisException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 4.3 Given Constructor Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidConstructorThrowException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer","Mood");
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        /// <summary>
        /// Extra - Given Class Name not match with constructor then Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenNullConstructorNameThrowException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer",null);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Class name or constructor name should not be null", ex.Message);
            }
        }
        /// <summary>
        /// TC 5.1 Given MoodAnalyser Class Name Should Return MoodAnalyser object with parameter
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenClassNameShoulReturnParameterizedObject()
        {
            string message = "I am in happy mood";
            object expected = new MoodAnalyzer(message);
            object actual = moodAnalyzerFactory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer",message);
            expected.Equals(actual);
        }

        /// <summary>
        /// TC 5.2 Given Class Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidClassNameWithMessageThrowException()
        {
            try
            {
                string message = "I am in happy mood";
                object expected = new MoodAnalyzer(message);
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzerProblem.Mood", "Mood",message);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 5.3 Given Constructor Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidConstructorWithMessageThrowException()
        {
            try
            {
                string message = "I am in happy mood";
                object expected = new MoodAnalyzer(message);
                object actual = moodAnalyzerFactory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzerProblem.MoodAnalyzer", "Mood",message);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        /// <summary>
        /// TC 6.1 Given Happy Message Using Reflection When Proper Should Return HAPPY Mood by invoking a method
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenMethodNameWithMessageReturnMood()
        {
            string message = "I am in happy mood";
            string expected = "HAPPY";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.InvokeMethod(message, "AnalyzeMood");
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Method not found", ex.Message);
            }
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC 6.2 Given Happy Message When Improper Method Should Throw MoodAnalysisException
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidMethodNameWithMessageThrowException()
        {
            string message = "I am in happy mood";
            string expected = "HAPPY";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.InvokeMethod(message, "Mood");
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Method not found", ex.Message);
            }            
        }
        /// <summary>
        /// TC 7.1 Set Happy Message with Reflector Should Return HAPPY
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenFieldNameAndMessageReturnsMood()
        {
            string userMessage = "I am in happy mood";
            string fieldName = "message";
            string expected = "HAPPY";
            string actual = "";
            
            MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
            actual = moodAnalyzerReflector.SetField(userMessage,fieldName);
            Assert.AreEqual(expected, actual);            
        }
        /// <summary>
        /// TC 7.2 Set Field When Improper Should Throw Exception with No Such Field
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenInvalidFieldNameThrowException()
        {
            string userMessage = "I am in happy mood";
            string fieldName = "mood";
            string expected = "HAPPY";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.SetField(userMessage, fieldName);                
            }
            catch(MoodAnalysisException ex)
            {
                Assert.AreEqual("Field name not found",ex.Message);
            }
        }
        /// <summary>
        /// TC 7.3 Setting Null Message with Reflector Should Throw Exception
        /// </summary>
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenNullMessageThrowException()
        {
            string userMessage = null;
            string fieldName = "message";
            string actual = "";
            try
            {
                MoodAnalyzerReflector moodAnalyzerReflector = new MoodAnalyzerReflector();
                actual = moodAnalyzerReflector.SetField(userMessage, fieldName);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Message should not be null", ex.Message);
            }
        }
    }
}
