using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Collider))] //Obliga a que cualquier GameObject que tenga este script también tenga un collider
public class PlayerInteractions : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float interactionRange = 200f; //Rango de distancia en el que se puede interactuar (2 unidades).
    [SerializeField] private LayerMask interactableLayer; //Máscara de capa que indica qué objetos pueden ser interactuados.

    private Interactable _currentInteractable; //Referencia al objeto interactuable actualmente detectado.
    private Camera _mainCam; //Referencia a la cámara principal del juego (para lanzar rayos desde ella).

    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FindInteractables();

        if (Keyboard.current.eKey.wasPressedThisFrame && _currentInteractable != null)
        {
            _currentInteractable.Interact();
        }
    }

    private void FindInteractables()
    {
        Ray ray = _mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactionRange, Color.red);

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            Interactable newInteractable = hit.collider.GetComponent<Interactable>();

            if (newInteractable != _currentInteractable)
            {
                _currentInteractable?.HidePrompt();
                _currentInteractable = newInteractable;
                _currentInteractable.ShowPrompt();
            }
        }
        else
        {
            _currentInteractable?.HidePrompt();
            _currentInteractable = null;
        }
    }
}
