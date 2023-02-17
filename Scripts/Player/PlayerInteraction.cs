using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IGameInteractionPress, IPausedUsingPress, IPausedBackPress
{
    private InteractionBehaviour currentInteraction;

    private void OnEnable()
    {
        InputInterfacesStorage.gameInteractionPress = this;
        InputInterfacesStorage.pausedBackPress = this;
        InputInterfacesStorage.pausedUsingPress = this;
    }

    private void OnDisable()
    {
        InputInterfacesStorage.gameInteractionPress = this;
        InputInterfacesStorage.pausedBackPress = this;
        InputInterfacesStorage.pausedUsingPress = this;
    }

    public void Back()
    {
        currentInteraction.Close();
        currentInteraction.Selected();
    }

    public void Use()
    {
        if (currentInteraction.CanCloseInteraction() == false)
        {
            currentInteraction?.Activate();
            currentInteraction?.Deselected();
        }
    }

    public void Using()
    {

        Debug.Log("current interaction used in pause");
        currentInteraction?.Activate();
        currentInteraction?.Deselected();

        if (currentInteraction.CanCloseInteraction() == true)
        {
            currentInteraction?.Close();
            currentInteraction?.Selected();
        }
    }

    public void SetInteraction(InteractionBehaviour interaction)
    {
        currentInteraction = interaction;
        currentInteraction?.Selected();
        Debug.Log($"{currentInteraction} is now");
    }


}

