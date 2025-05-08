using UnityEngine;
using UnityEngine.EventSystems;

// Requirements:
// 1a. Attach "Physics Raycaster" to Camera or
// 1b. Attach "Graphic Raycaster" to Canvas
// 2. Add EventSystem Object

// Layers | Event Mask (enemy, pickable)

public class Targeting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private new Renderer renderer;

    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            print("Layer ID " + gameObject.layer + " | Name " + LayerMask.NameToLayer("Enemy"));
        }

        print("OnPointerEnter " + gameObject.name);
        renderer.material.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("OnPointerExit " + gameObject.name);
        renderer.material.color = Color.gray;
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user right-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Right Clicked!");
        }

        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(name + " Game Object Left Clicked!");
        }
    }
}