using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telesoftas_HomeWork_Task.Controller
{
    using View;
    using Model;

    class Controller : IViewAdapter, IModeladapter
    {

        public delegate IView ViewFactory();
        public delegate IModel ModelFactory();

        private IView _viewer;
        private IModel _model;


        #region Constructor
        public Controller(ViewFactory viewer, ModelFactory model)
        {
            _viewer = viewer();
            _model = model();
            _viewer.SetAdapter(this);
            _model.SetAdapter(this);
        }
        #endregion


        public void SetInputData(List<string> data)
        {
            _viewer.SetForDataOutput(_model.FormatOutputData(data));
        }

        public void Start()
        {
            _viewer.DataFromView();
        }
    }
}
