namespace Restaurant.Base.ViewModel
{
    public interface IContainerViewModel : IViewModel
    {
        IViewModel CurrentViewModel { get; }
    }
}