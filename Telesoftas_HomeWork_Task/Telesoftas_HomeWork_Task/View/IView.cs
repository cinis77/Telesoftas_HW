using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.View
{

    interface IView
    {
        #region Method field
        /// <summary>
        /// Provide output data from view
        /// </summary>
        /// <param name="data"></param>
        void SetForDataOutput(string data);

        /// <summary>
        /// Start view work
        /// </summary>
        void StartView();

        /// <summary>
        /// Set adapter for view to know the controller reference
        /// </summary>
        /// <param name="adapter"></param>
        void SetAdapter(IViewAdapter adapter);
        #endregion
    }
}
