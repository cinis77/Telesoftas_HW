using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telesoftas_HomeWork_Task.Data;

namespace Telesoftas_HomeWork_Task.Model
{
    class Model : IModel
    {
        #region Private variable field
        private IModeladapter _adapter;
        #endregion

        #region Public method field
        public string FormatOutputData(List<string> rawData)
        {
            List<DataStrucuter> data = new List<DataStrucuter>();
            while (rawData.Count > 1)
            {
                List<string> tempList = new List<string>();
                tempList.Add(rawData.First());
                rawData.RemoveAt(0);
                tempList.Add(rawData.First());
                rawData.RemoveAt(0);
                data.Add(WorkWithData.Instance.ParseDataToNewFormat(tempList));
            }
            string answer = "";
            foreach (var item in data)
            {
                answer += "----------------------------------------\n";
                answer += WorkWithData.Instance.OutputString(item)+"\n";
            }
            return answer;
        }

        public void SetAdapter(IModeladapter adapter)
        {
            _adapter = adapter;
        }
        #endregion

    }
}
