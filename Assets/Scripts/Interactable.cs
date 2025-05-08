using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("UI Config")]
    [SerializeField] private Canvas interactionCanvas;
    [SerializeField] private Canvas Canvas;
    [SerializeField] private GameObject visualPrompt;

    protected virtual void Start()
    {
        interactionCanvas.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        if (visualPrompt != null) visualPrompt.SetActive(false);
    }

    public void ShowPrompt()
    {
        interactionCanvas.gameObject.SetActive(true);
        if (visualPrompt != null) visualPrompt.SetActive(true);
    }
    public void ShowCanvas()
    {
        Canvas.gameObject.SetActive(true);
        if (visualPrompt != null) visualPrompt.SetActive(true);
    }

    public void HidePrompt()
    {
        interactionCanvas.gameObject.SetActive(false);
        if (visualPrompt != null) visualPrompt.SetActive(false);
    }

    public abstract void Interact();
}