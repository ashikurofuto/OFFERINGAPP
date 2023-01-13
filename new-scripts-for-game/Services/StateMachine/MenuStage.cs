public class MenuStage : IStageble
{
    private IMenuUsable menuUsable;

    public MenuStage(IMenuUsable menu)
    {
        menuUsable = menu;
    }

    public void EnterState()
    {
        menuUsable.OpenMenu();
    }

    public void ExitState()
    {
        menuUsable.CloseMenu();
    }
}
