using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.View
{
    interface IViewAdapter
    {
        #region Method field

        /// <summary>
        /// Get input data from view
        /// </summary>
        /// <param name="data"></param>
        void SetInputData(List<string> data);

        /// <summary>
        /// Start the work of MVC modules
        /// </summary>
        void Start();
        #endregion
    }
}
