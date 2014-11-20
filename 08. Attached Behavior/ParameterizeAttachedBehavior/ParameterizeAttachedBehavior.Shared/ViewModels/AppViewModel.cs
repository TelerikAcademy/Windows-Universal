using ParameterizeAttachedBehavior.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ParameterizeAttachedBehavior.ViewModels
{
    public class AppViewModel: ViewModelBase
    {
        private ICommand commandRun;
        public string DisplayName { get; set; }

        public ICommand Run 
        {
            get
            {
                if (this.commandRun == null)
                {
                    this.commandRun = 
                        new RelayCommandWithParameters(this.PerformRun);
                }
                return this.commandRun;
            }
            
        }

        private void PerformRun(object obj)
        {
            var displayName = obj as string;
        }

    }
}
