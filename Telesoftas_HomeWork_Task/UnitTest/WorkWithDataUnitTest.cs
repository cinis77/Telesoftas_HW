using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telesoftas_HomeWork_Task.Data;

namespace UnitTest
{
    [TestClass]
    public class WorkWithDataUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ParseDataToNewFormat_SendEmptyString_InvalidOperationExceptionExpected()
        {
            WorkWithData.Instance.ParseDataToNewFormat(new System.Collections.Generic.List<string>());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseDataToNewFormat_Send0_FormatExceptionExpected()
        {
            WorkWithData.Instance.ParseDataToNewFormat(new System.Collections.Generic.List<string>() { "tekstas", "0" });
        }

        [TestMethod]
        public void ParseDataToNewFormat_SendTextAnd2_AssertThatReceivedTextAnd2InNewStructure()
        {
            var testResult = WorkWithData.Instance.ParseDataToNewFormat(new System.Collections.Generic.List<string>() { "Text", "2" });
            var variableForAssert = new DataStrucuter("Text", 2);
            Assert.AreEqual(variableForAssert, testResult);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ParseDataToNewFormat_SendOnlyOneItemInList_ExceptionExpected()
        {
            WorkWithData.Instance.ParseDataToNewFormat(new System.Collections.Generic.List<string>() { "T" });
        }

        [TestMethod]
        public void OutputString_SentEmptyStruct_AssertExpetionMessage()
        {
            string testResult = WorkWithData.Instance.OutputString(new DataStrucuter());
            Assert.AreEqual("Issue with letter counter or structure, check input data", testResult);
        }

        [TestMethod]
        public void OutputString_SentLetterCount0_AssertExpetionMessage()
        {
            string testResult = WorkWithData.Instance.OutputString(new DataStrucuter("zodis zodis", 0));
            Assert.AreEqual("Issue with letter counter or structure, check input data", testResult);
        }

        [TestMethod]
        public void OutputString_SentTextAndLetterCounter3_AssertString()
        {
            string testResult = WorkWithData.Instance.OutputString(new DataStrucuter("tex rex", 3));
            Assert.AreEqual("tex\nrex\n", testResult);
        }

        [TestMethod]
        public void OutputString_SentLongTextAndLetterCounter4_AssetString()
        {
            string testResult = WorkWithData.Instance.OutputString(new DataStrucuter("Pasikiskeliapusteliaudamas", 4));
            Assert.AreEqual("Pasi\nkisk\nelia\npust\nelia\nudam\nas ", testResult);
        }
    }
}
