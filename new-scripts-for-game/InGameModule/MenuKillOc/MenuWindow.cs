using UnityEngine;

public class MenuWindow : MonoBehaviour
{
    public MenuWindowParameters parameters;


    private void Awake()
    {
        parameters = new MenuWindowParameters();
    }

    public void OpenWindow()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }
}
