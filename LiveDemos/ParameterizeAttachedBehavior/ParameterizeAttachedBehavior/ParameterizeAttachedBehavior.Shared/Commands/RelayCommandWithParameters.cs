using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ParameterizeAttachedBehavior.Commands
{
   public class RelayCommandWithParameters: ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommandWithParameters(Action<object> execute,
                            Func<object,bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
