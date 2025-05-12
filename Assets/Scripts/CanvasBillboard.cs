using UnityEngine;

public class CanvasBillboard : MonoBehaviour
{
    private Camera _mainCam;

    void Start()
    {
        _mainCam = Camera.main;
    }

    void Update()
    {
        // Obt�n la direcci�n desde el Canvas hacia la c�mara
        Vector3 directionToCamera = _mainCam.transform.position - transform.position;

        // Mant�n la direcci�n en el eje Y (evitar rotaci�n en X y Z)
        directionToCamera.y = 0;

        // Asegura que el Canvas mire hacia la c�mara solo en el eje Y
        // Invierte la direcci�n para que el frente mire hacia la c�mara
        transform.rotation = Quaternion.LookRotation(-directionToCamera);
    }
}
