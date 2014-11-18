namespace Common.Services
{
    public interface IServiceLocator
    {
        void Register<TInterface, TImplementation>(TImplementation serviceImplementation) where TImplementation : TInterface;
        void Register<TInterface, TImplemention>() where TImplemention : TInterface;
        TInterface Resolve<TInterface>();
    }
}
