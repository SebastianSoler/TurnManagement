using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace TurnManagement.App_Turn.ViewModel.Base
{
    public class BaseViewModel : ViewModelBase
    {

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
