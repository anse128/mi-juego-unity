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
        // Obtén la dirección desde el Canvas hacia la cámara
        Vector3 directionToCamera = _mainCam.transform.position - transform.position;

        // Mantén la dirección en el eje Y (evitar rotación en X y Z)
        directionToCamera.y = 0;

        // Asegura que el Canvas mire hacia la cámara solo en el eje Y
        // Invierte la dirección para que el frente mire hacia la cámara
        transform.rotation = Quaternion.LookRotation(-directionToCamera);
    }
}
