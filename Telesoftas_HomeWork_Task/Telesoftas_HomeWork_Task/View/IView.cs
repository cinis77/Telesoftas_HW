using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.View
{

    interface IView
    {
        void SetForDataOutput(string data);
        void DataFromView();
        void SetAdapter(IViewAdapter adapter);
    }
}
