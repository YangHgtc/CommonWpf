using CommunityToolkit.Mvvm.ComponentModel;

namespace CommonWpf.Mvvm.Mvvm
{
    public abstract class ViewModelBase : ObservableObject, IDestructible
    {
        protected ViewModelBase()
        {
        }

        public virtual void Destroy()
        {
        }
    }
}
