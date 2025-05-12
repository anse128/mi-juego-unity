using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UI_InputMapper : MonoBehaviour
{
    UIDocument document;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();

        document.panelSettings.SetScreenToPanelSpaceFunction((Vector2 screenPosition) =>
        {

            var invalidPosition = new Vector2(float.NaN, float.NaN);

            //var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);  //antiguo input
            // Reemplaza Input.mousePosition con el nuevo Input System
            Vector2 mousePos = Mouse.current.position.ReadValue();
            var cameraRay = Camera.main.ScreenPointToRay(mousePos); // Línea modificada
            Debug.DrawRay(cameraRay.origin, cameraRay.direction * 100, Color.magenta);

            RaycastHit hit;
            if (!Physics.Raycast(cameraRay, out hit, 100f, LayerMask.GetMask("UI")))
            {
                Debug.Log($"invalid position");
                return invalidPosition;
            }

            Vector2 pixelUV = hit.textureCoord;

            pixelUV.y = 1 - pixelUV.y;
            pixelUV.x *= this.document.panelSettings.targetTexture.width;
            pixelUV.y *= this.document.panelSettings.targetTexture.height;

            var cursor = this.document.rootVisualElement.Q<VisualElement>("Cursor");
            if (cursor != null)
            {
                cursor.style.left = pixelUV.x;
                cursor.style.top = pixelUV.y;
            }

            return pixelUV;
        });
    }
}
