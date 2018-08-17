using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.View
{
    interface IViewAdapter
    {
        void SetInputData(List<string> data);
        void Start();
    }
}
