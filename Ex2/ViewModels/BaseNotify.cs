using System.ComponentModel;

namespace Ex2.ViewModels {
    public abstract class BaseNotify : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}
