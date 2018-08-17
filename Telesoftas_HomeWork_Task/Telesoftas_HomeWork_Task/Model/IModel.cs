using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.Model
{
    using Data;
    interface IModel
    {
        void SetAdapter(IModeladapter adapter);
        string FormatOutputData(List<string> rawData);
    }
}
