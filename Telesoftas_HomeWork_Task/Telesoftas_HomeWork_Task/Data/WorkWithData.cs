using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.Data
{
    /// <summary>
    /// Data structure to get line data
    /// </summary>
    struct DataStrucuter
    {
        #region Public properties
        public string Text { get; }
        public int CountOfLetters { get; }
        #endregion

        #region Constructor
        public DataStrucuter(string text, int countofletters)
        {
            Text = text;
            CountOfLetters = countofletters;
        }
        #endregion
    }

    /// <summary>
    /// Singleton class to work with data
    /// </summary>
    class WorkWithData
    {
        #region Singleton variables
        private static readonly object _lock = new object();
        private static WorkWithData _dataType = new WorkWithData();
        #endregion

        #region Public property field
        /// <summary>
        /// Singleton property to access methods
        /// </summary>
        public static WorkWithData Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_dataType == null)
                    {
                        _dataType = new WorkWithData();
                    }
                    return _dataType;
                }
            }
        }
        #endregion

        #region Constructor
        protected WorkWithData()
        {

        }
        #endregion

        #region Public methods field

        /// <summary>
        /// Parse to parse data from string to stucture format
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataStrucuter ParseDataToNewFormat(List<string> data)
        {
            int number = 0;
            string text = data.First();

            try
            {
                if (int.TryParse(new string(data[1].Where(char.IsDigit).ToArray()), out number))
                {
                    if (number != 0)
                    {
                        return new DataStrucuter(text, number);
                    }
                    else
                    {
                        throw new FormatException("Number is 0");
                    }
                }
                else
                {
                    throw new FormatException("Parse Failed");
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to create output string out of provided data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string OutputString(DataStrucuter data)
        {
            string answerToReturn = "";
            string LastWord = "";
            foreach (var item in data.Text.Split(' ').ToList())
            {
                string temp = LastWord;
                if (item.ToCharArray().Length < data.CountOfLetters)
                {
                    
                    LastWord += item + " ";
                    if ((LastWord.ToCharArray().Length - 1) > data.CountOfLetters)
                    {
                        LastWord = temp.Remove(temp.Length - 1);
                        answerToReturn += LastWord + "\n";
                        LastWord = item + " ";
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (LastWord == "")
                    {
                        answerToReturn += RecursiveLongWordSolver(item, data.CountOfLetters, out LastWord);
                    }
                    else
                    {
                        answerToReturn += LastWord + "\n";
                        answerToReturn += RecursiveLongWordSolver(item, data.CountOfLetters, out LastWord);
                    }
                }
            }
            return answerToReturn+LastWord;
            
        }
        
        /// <summary>
        /// Recursive method for word longer than line char amount
        /// </summary>
        /// <param name="text"></param>
        /// <param name="count"></param>
        /// <param name="leftWordPart"></param>
        /// <returns></returns>
        private string RecursiveLongWordSolver(string text, int count, out string leftWordPart)
        {
            char[] partOfText = text.ToCharArray();
            List<char> whatisleft = text.ToCharArray().ToList();
            string word = "";
            for (int i = 0; i < count; i++)
            {
                word += partOfText[i];
                whatisleft.RemoveAt(0);
            }
            text = string.Join("",whatisleft);
            if(text.ToCharArray().Length > count)
            {
                return word += "\n" + RecursiveLongWordSolver(text, count, out leftWordPart);
            }
            else
            {
                if (text != "")
                {
                    leftWordPart = text + " ";
                    return word += "\n";
                }
                else
                {
                    leftWordPart = text;
                    return word += "\n";
                }
            }
        }
        #endregion
    }
}
