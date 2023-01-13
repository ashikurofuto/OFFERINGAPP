using UnityEngine.SceneManagement;

public class LevelService : IGameService
{

    private LevelStorage levelStorage;


    public LevelService(LevelStorage levelStorage)
    {
        this.levelStorage = levelStorage;
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(levelStorage.GetFirstLevel());
    }


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(levelStorage.GetNextLevel());
    }


    public void LoadSecretLevel(int secretIndex)
    {
        SceneManager.LoadScene(levelStorage.SecretLevels[secretIndex]);
    }


    public void LoadUniqLevel(int uniqIndex)
    {
        SceneManager.LoadScene(levelStorage.UniqLevels[uniqIndex]);
    }


    public void LoadLastSimpleLevel()
    {
        SceneManager.LoadScene(levelStorage.GetCurrentLevel());
        
    }

    public void LoadDeathScene(int deathIndex)
    {
        if (levelStorage.DeathLevels.Length > 0)
        {
            SceneManager.LoadScene(levelStorage.DeathLevels[deathIndex]);
            
        }
        throw new System.Exception("You dont have any death levels in LevelStorage");
    }


    public bool GetTransitionDeathScene()
    {
        SceneManager.LoadSceneAsync(levelStorage.GetCurrentLevel(), LoadSceneMode.Additive);

        if (SceneManager.GetSceneByName(levelStorage.GetCurrentLevel()).isLoaded)
        {
            return true;
        }
        throw new System.Exception($"{levelStorage.GetCurrentLevel()} is not loaded");
    }

    public void UnloadAsyncLevel(string currentScene)
    {
        SceneManager.UnloadSceneAsync(currentScene);
    }


    public string GetLastLevel()
    {
        return SceneManager.GetActiveScene().name;
    }


}
