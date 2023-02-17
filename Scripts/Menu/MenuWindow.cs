using UnityEngine;

public abstract class MenuWindow : MonoBehaviour
{
    public virtual void OpenWindow()
    {
        gameObject.SetActive(true);
    }
    public virtual void CloseWindow()
    {
        gameObject.SetActive(false);
    }
    public virtual bool OpenFirstTime()
    {
        gameObject.SetActive(true);
        return true;
    }

}

