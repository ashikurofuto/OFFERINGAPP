using System.Collections.Generic;

public class ServiceLocatorGame
{
    public static ServiceLocatorGame serviceLocatorGame { get; private set; }
    private readonly Dictionary<string, IGameService> gameServices;

    public ServiceLocatorGame()
    {
        gameServices = new Dictionary<string, IGameService>();
    }

    public void Initialize()
    {
        serviceLocatorGame = new ServiceLocatorGame();
    }

    public T GetGameService<T>() where T : IGameService
    {
        var type = typeof(T).Name;
        if (!gameServices.ContainsKey(type))
        {
            throw new System.Exception($"This service {type} not founded");
        }
        return (T)gameServices[type];
    }
    public void RegisterGameService<T>(T service) where T : IGameService
    {
        var type = service.GetType().Name;
        if (gameServices.ContainsKey(type))
        {
            throw new System.Exception($"this service {type} is already registred");
        }
        gameServices.Add(type, service);
    }

    public void UnregistredGameService<T>(T service) where T : IGameService
    {
        var type = service.GetType().Name;
        if (!gameServices.ContainsKey(type))
        {
            throw new System.Exception($"This service {type} not founded");
        }
        gameServices.Remove(type);
    }
}
