using System.ComponentModel;

namespace ListviewProje.ViewModels
{
    public class ViewModelBase:INotifyPropertyChanged
    {  
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public static class String
    {
        public static string GetPropertyName(this System.Reflection.MethodBase methodBase)
        {
            return methodBase.Name.Substring(4);
        }
    }
}
