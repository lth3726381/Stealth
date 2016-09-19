using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stealth.WPF.Util
{
    public class UpdaterViewModel
    {
        public UpdaterModel updaterModel { get; set; }
        public DelegateCommand close { get; set; }
        public DelegateCommand cancel { get; set; }

        public UpdaterViewModel()
        {
            updaterModel = new UpdaterModel();
            close = new DelegateCommand();
            cancel = new DelegateCommand();

            close.ExecuteCommand = new Action<object>(updaterModel.Close);
            
        }
    }
}
