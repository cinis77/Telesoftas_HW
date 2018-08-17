using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.View
{
    class ViewConsole : IView
    {
        #region Private variable field
        private IViewAdapter _adapter;
        #endregion

        #region Public method field
        public void StartView()
        {
            List<string> tempList = new List<string>();
            tempList.Add(Console.ReadLine());
            tempList.Add(Console.ReadLine());

            _adapter.SetInputData(tempList);
        }

        public void SetAdapter(IViewAdapter adapter)
        {
            _adapter = adapter;
        }

        public void SetForDataOutput(string data)
        {
            Console.WriteLine(data);
        }
        #endregion

    }
}
