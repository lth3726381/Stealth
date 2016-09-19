using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stealth.WPF
{
    public class MainWindowViewModel
    {
        public MainWindowModel model { get; set; }

        // menu
        public DelegateCommand exit { get; set; }
        public DelegateCommand about { get; set; }
        public DelegateCommand checkForUpdates { get; set; }

        // button
        public DelegateCommand setWindow { get; set; }
        public DelegateCommand refreshWindowList { get; set; }

        public MainWindowViewModel()
        {
            model = new MainWindowModel();

            exit = new DelegateCommand();
            about = new DelegateCommand();
            checkForUpdates = new DelegateCommand();
            setWindow = new DelegateCommand();
            refreshWindowList = new DelegateCommand();

            exit.ExecuteCommand = new Action<object>(model.Exit);
            about.ExecuteCommand = new Action<object>(model.About);
            checkForUpdates.ExecuteCommand = new Action<object>(model.CheckForUpdates);
            setWindow.ExecuteCommand = new Action<object>(model.SetWindow);
            refreshWindowList.ExecuteCommand = new Action<object>(model.RefreshList);
        }
    }
}
