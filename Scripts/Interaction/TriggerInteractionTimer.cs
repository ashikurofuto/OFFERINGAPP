using System.Collections;
using UnityEngine;

public class TriggerInteractionTimer : InteractionBehaviour
{
    [SerializeField] private GameObject popupView;
    [SerializeField] private float timer;
    [SerializeField] private bool isPaused;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<PlayerInteraction>(out var player))
        {
            Activate();
            StartCoroutine(CloseTriggerPopup());
        }
    }


    public override void Activate()
    {
        if (isPaused = true)
        {
            base.Activate();
        }
        popupView.SetActive(true);
    }
    public override void Close()
    {
        popupView.SetActive(false);
        base.Close();
    }

    private IEnumerator CloseTriggerPopup()
    {
        yield return new WaitForSeconds(timer);
        Close();
    }


    public override bool CanCloseInteraction()
    {
        throw new System.NotImplementedException();
    }
    public override void Selected()
    {
    }
    public override void Deselected()
    {
    }
}


