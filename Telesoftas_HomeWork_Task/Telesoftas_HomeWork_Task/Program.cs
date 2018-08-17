using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task
{
    using Model;
    using View;
    using Controller;
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Controller.Controller c = new Controller.Controller(MyView, MyDataModel);
            DoWork(c);
        }

        public static IModel MyDataModel() => new Model.Model();

        public static IView MyView() => new ViewStream();

        static void DoWork(Controller.Controller c)
        {
            try
            {
                c.Start();
            }
            catch (Exception ex)
            {

                DoWork(c);
            }
        }
    }
}
