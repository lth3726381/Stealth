using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stealth.WPF.Util
{
    public class UpdaterModel: NotificationObject
    {
        private string _info = "";
        public string info
        {
            get { return _info; }
            set
            {
                if (_info != value)
                {
                    _info = value;
                    OnPropertyChanged("info");
                }
            }
        }

        /// <summary>
        /// Close a window
        /// CommandParameter="{Binding ElementName = YourWindowName}"
        /// </summary>
        /// <param name="obj">Window</param>
        public void Close(object obj)
        {
            (obj as Window)?.Close();
        }


        public void Cancel(object obj)
        {
            //todo: cancel the update process
        }
    }
}
