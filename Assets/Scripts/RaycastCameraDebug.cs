using UnityEngine;

public class RaycastCameraDebug : MonoBehaviour
{
    private Camera _mainCam; //Referencia a la cámara principal del juego (para lanzar rayos desde ella).

    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red);
    }
}
