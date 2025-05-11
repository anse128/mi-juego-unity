using System.Collections;
using UnityEngine.UIElements;
using UnityEngine;


public class MiniWorld_UI : MonoBehaviour
{
    VisualElement root;

    public Transform player1;
    public Transform player2;
    public Transform player3;

    VisualElement healthBar1;
    VisualElement healthBar2;
    VisualElement healthBar3;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        VisualTreeAsset healtBarAsset = Resources.Load<VisualTreeAsset>("Healthbar");
        healthBar1 = healtBarAsset.Instantiate();
        healthBar2 = healtBarAsset.Instantiate();
        healthBar3 = healtBarAsset.Instantiate();

        root.Add(healthBar1);
        root.Add(healthBar2);
        root.Add(healthBar3);
    }
    private void Update()
    {
        Vector3 screen = Camera.main.WorldToScreenPoint(player1.position); // Convierte la posición 3D del jugador (player1.position) en coordenadas de pantalla 2D (screen.x, screen.y).
        healthBar1.style.left = screen.x - (healthBar1.layout.width / 2);
        healthBar1.style.top = (Screen.height - screen.y) - 100;

        Vector3 screen2 = Camera.main.WorldToScreenPoint(player2.position);
        healthBar2.style.left = screen2.x - (healthBar2.layout.width / 2);
        healthBar2.style.top = (Screen.height - screen2.y) - 100;

        Vector3 screen3 = Camera.main.WorldToScreenPoint(player3.position);
        healthBar3.style.left = screen3.x - (healthBar3.layout.width / 2);
        healthBar3.style.top = (Screen.height - screen3.y) - 100;

    }

}