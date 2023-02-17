using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Panel : MenuWindow
{
    [SerializeField] private Image back;
    [SerializeField] private Color color;

    public override bool OpenFirstTime()
    {
        base.OpenFirstTime();
        back.color = Color.blue;
        StartCoroutine(ColorChanger());
        return true;
    }
    public override void OpenWindow()
    {
        base.OpenWindow();
        back.color = color;
    }
    public override void CloseWindow()
    {
        base.CloseWindow();
    }

    private IEnumerator ColorChanger()
    {
        yield return new WaitForSeconds(3f);
        back.color = Color.green;
        
    }
}



