using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GroupProject.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object,bool> canExecute;
        private Action<object> _execute;
        private object _canExecute;

        public event EventHandler? CanExecuteChanged;

        public event EventHandler CaneExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

     
    }
}
