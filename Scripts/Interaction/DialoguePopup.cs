using UnityEngine;

public class DialoguePopup : InteractionBehaviour
{
    [SerializeField] private GameObject[] popups;
    private int index = 0;
    

    public override void Activate()
    {
        if (index == 0)
        {
            base.Activate();
        }
        popups[index].SetActive(true);
        popups[Mathf.Abs(index -1)]?.SetActive(false);
        index++;
    }

    public override bool CanCloseInteraction()
    {
        if (index == popups.Length)
        {
            index = 0;
            return true;
        }
        return false;
    }

    public override void Close()
    {
        for (int i = 0; i < popups.Length; i++)
        {
            popups[i].SetActive(false);
        }
        base.Close();
    }

    public override void Selected()
    {
        base.Selected();
        Debug.Log($"{gameObject.name} is selected");
    }
    public override void Deselected()
    {
        base.Deselected();
    }
}

