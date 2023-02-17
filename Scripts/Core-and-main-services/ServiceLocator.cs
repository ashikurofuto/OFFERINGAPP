using System.Collections.Generic;

public class ServiceLocator
{
    public static ServiceLocator locator { get; private set; }
    private readonly Dictionary<string, IGameService> gameServices;

    public ServiceLocator()
    {
        gameServices = new Dictionary<string, IGameService>();
    }

    public T GetService<T>() where T : IGameService
    {
        var type = typeof(T).Name;
        if (!gameServices.ContainsKey(type))
        {
            throw new System.Exception($"This service {type} not founded");
        }
        return (T)gameServices[type];
    }
    public void Register<T>(T service) where T : IGameService
    {
        var type = service.GetType().Name;
        if (gameServices.ContainsKey(type))
        {
            throw new System.Exception($"this service {type} is already registred");
        }
        gameServices.Add(type, service);
    }

    public void Unregister<T>(T service) where T : IGameService
    {
        var type = service.GetType().Name;
        if (!gameServices.ContainsKey(type))
        {
            throw new System.Exception($"This service {type} not founded");
        }
        gameServices.Remove(type);
    }
}

