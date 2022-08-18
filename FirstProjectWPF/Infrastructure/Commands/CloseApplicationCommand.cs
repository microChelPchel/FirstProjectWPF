using FirstProjectWPF.Infrastructure.Commands.Base;
using System.Windows;

namespace FirstProjectWPF.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
