using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Telesoftas_HomeWork_Task.View
{
    class ViewStream : IView
    {

        private IViewAdapter _adapter;
        private string[] _path = null;
        [STAThread]
        public void DataFromView()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _path = ofd.FileNames;
            }
            ofd.Dispose();
            foreach (var item in _path)
            {
                List<string> DataItems = new List<string>();
                using (StreamReader reader = new StreamReader(item))
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        DataItems.Add(line);
                    }
                }
                _adapter.SetInputData(DataItems);
            }
            
        }

        public void SetAdapter(IViewAdapter adapter)
        {
            _adapter = adapter;
        }

        public void SetForDataOutput(string data)
        {
            MessageBox.Show("Select where to store output file");
            string pathing = null;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    pathing = fbd.SelectedPath;
                }
            }
            using (StreamWriter writer = new StreamWriter(pathing+"\\output.csv"))
            {
                writer.WriteLine(data);
            }

        }
    }
}
