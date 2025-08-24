public enum LifeTime { Transient, Singleton }

public class IocContainer
{
    private readonly Dictionary<Type, (Func<IocContainer, object> factory, LifeTime lifeTime)> _registrations
        = new Dictionary<Type, (Func<IocContainer, object>, LifeTime)>();
    private readonly Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

    public void Register<TService, TImplementation>(LifeTime lifeTime = LifeTime.Transient) where TImplementation : TService
    {
        _registrations[typeof(TService)] = (c => Activator.CreateInstance(typeof(TImplementation))!, lifeTime);
    }

    public void Register<TService>(Func<IocContainer, object> factory, LifeTime lifeTime = LifeTime.Transient)
    {
        _registrations[typeof(TService)] = (factory, lifeTime);
    }

    public TService Resolve<TService>()
    {
        var type = typeof(TService);

        if (!_registrations.ContainsKey(type))
        {
            throw new InvalidOperationException($"Service {type.Name} not registered!");
        }
        var (factory, lifeTime) = _registrations[type];
        if (lifeTime == LifeTime.Singleton)
        {
            if (!_singletons.ContainsKey(type))
            {
                _singletons[type] = factory(this);
            }
            return (TService)_singletons[type];
        }
        return (TService)factory(this);
    }
}