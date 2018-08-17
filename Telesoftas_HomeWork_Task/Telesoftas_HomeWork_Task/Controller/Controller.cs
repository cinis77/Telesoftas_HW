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
        #region Factory delegates
        public delegate IView ViewFactory();
        public delegate IModel ModelFactory();
        #endregion

        #region Private Variable field
        private IView _viewer;
        private IModel _model;
        #endregion

        #region Constructor
        public Controller(ViewFactory viewer, ModelFactory model)
        {
            _viewer = viewer();
            _model = model();
            _viewer.SetAdapter(this);
            _model.SetAdapter(this);
        }
        #endregion

        #region Public methods field
        /// <summary>
        /// Provide input for model to do the work
        /// </summary>
        /// <param name="data"></param>
        public void SetInputData(List<string> data)
        {
            _viewer.SetForDataOutput(_model.FormatOutputData(data));
        }

        /// <summary>
        /// Start MVC work
        /// </summary>
        public void Start()
        {
            _viewer.StartView();
        }
        #endregion
    }
}
