using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FirstProjectWPF.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperyChanged([CallerMemberName]string PropertName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertName));
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnProperyChanged(PropertyName);
            return true;
        }


        public void Dispose()
        {
            Dispose(false);
        }

        private bool _Disposed;
        public virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;
            _Disposed= true;
            //освобождения ресурсов
        }


    }
}
