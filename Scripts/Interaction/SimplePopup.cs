using UnityEngine;

public class SimplePopup : InteractionBehaviour
{
    [SerializeField] private GameObject PopupView;
    private bool canClose = false;

    public override void Activate()
    {
        base.Activate();
        PopupView.SetActive(true);
        canClose = true;
    }

    public override bool CanCloseInteraction()
    {
        return canClose;
    }

    public override void Close()
    {
        base.Close();
        PopupView.SetActive(false);
        canClose = false;
    }

    public override void Selected()
    {
        base.Selected();
    }

    public override void Deselected()
    {
        base.Deselected();
    }
}
