using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.Model
{
    interface IModel
    {
        #region Method field
        /// <summary>
        /// Set adapter for object to know controller object reference
        /// </summary>
        /// <param name="adapter"></param>
        void SetAdapter(IModeladapter adapter);

        /// <summary>
        /// Format the data for output
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        string FormatOutputData(List<string> rawData);
        #endregion
    }
}
