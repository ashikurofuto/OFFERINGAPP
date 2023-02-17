using System.Collections;
using UnityEngine;

public class TimerPopup : InteractionBehaviour
{
    [SerializeField] private GameObject popupView;
    [SerializeField] private float timerCount;

    public override void Activate()
    {
        base.Activate();
        StartCoroutine(CloseByTimeEndedRoutine());
    }

    public override bool CanCloseInteraction()
    {
        return false;
    }

    public override void Close()
    {
        base.Close();
        Debug.Log("Wait end of time");
    }

    public override void Selected()
    {
        base.Selected();
        Debug.Log($"{gameObject.name} is selected time btw closed {timerCount}");
    }

    public override void Deselected()
    {
        base.Deselected();
    }

    private IEnumerator CloseByTimeEndedRoutine()
    {
        popupView.SetActive(true);
        yield return new WaitForSeconds(timerCount);
        popupView.SetActive(false);
        Close();
    }

}

