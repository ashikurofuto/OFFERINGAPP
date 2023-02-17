using UnityEngine;

public class TriggerCloseButton : InteractionBehaviour
{
    [SerializeField] private GameObject popupView;
    private bool canClose = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<PlayerInteraction>(out var player))
        {
            Activate();
            player.SetInteraction(this);
        }
    }

    public override void Activate()
    {
        base.Activate();
        popupView.SetActive(true);
        canClose = true;
    }
    public override void Close()
    {
        base.Close();
        popupView.SetActive(false);
        canClose = false;
    }

    public override void Selected()
    {
    }
    public override void Deselected()
    {
    }

    public override bool CanCloseInteraction()
    {
        return canClose;
    }
}