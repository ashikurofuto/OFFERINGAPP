using UnityEngine;

public class SimpleInteractionEntity : MonoBehaviour, IDialogueInput
{
    private void OnEnable()
    {
        StageHandler.StartDialogueStage();
    }

    private void OnDisable()
    {
        StageHandler.StartGameStage();
    }

    public void CloseDialogue()
    {
        this.gameObject.SetActive(false);
    }

    public void GetNextWord()
    {
        CloseDialogue();
    }
}

