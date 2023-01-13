public class GameOverStage : IStageble
{
    private IPlayerDeathWrapper deathWrapper;

    public GameOverStage(IPlayerDeathWrapper wrapper)
    {
        deathWrapper = wrapper;
    }

    public void EnterState()
    {
        deathWrapper.SetAndStartDeath();
    }

    public void ExitState()
    {

    }
}
