public class DialogueStage : IStageble
{
    private IDialogueItem dialogueItem;

    public DialogueStage( IDialogueItem Item)
    {
        dialogueItem = Item;
    }


    public void EnterState()
    {
        dialogueItem.Open();
    }


    public void ExitState()
    {
        dialogueItem.Close();
    }
}

