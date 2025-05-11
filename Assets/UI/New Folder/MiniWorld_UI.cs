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

    public float offsetY = 50f; // Ajusta en el Inspector


    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.Clear();


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
        Vector3 screenPos = Camera.main.WorldToScreenPoint(player1.position);

        // 1. Centrado horizontal perfecto
        float barWidth = healthBar1.resolvedStyle.width; // Usa resolvedStyle en lugar de layout
        healthBar1.style.left = screenPos.x - (barWidth / 2);

        // 2. Ajuste vertical preciso (ajusta el -100 según necesites)
        float barHeight = healthBar1.resolvedStyle.height;
        healthBar1.style.top = Screen.height - screenPos.y - barHeight - offsetY;

        // 3. Opcional: Debug para afinar
        Debug.Log($"Posición: {screenPos} | Ancho barra: {barWidth} | Alto barra: {barHeight}");




        Vector3 screenPos2 = Camera.main.WorldToScreenPoint(player2.position);

        // 1. Centrado horizontal perfecto
        float barWidth2 = healthBar2.resolvedStyle.width; // Usa resolvedStyle en lugar de layout
        healthBar2.style.left = screenPos2.x - (barWidth2 / 2);

        // 2. Ajuste vertical preciso (ajusta el -100 según necesites)
        float barHeight2 = healthBar2.resolvedStyle.height;
        healthBar2.style.top = Screen.height - screenPos2.y - barHeight2 - offsetY;


        Vector3 screenPos3 = Camera.main.WorldToScreenPoint(player3.position);

        // 1. Centrado horizontal perfecto
        float barWidth3 = healthBar2.resolvedStyle.width; // Usa resolvedStyle en lugar de layout
        healthBar3.style.left = screenPos3.x - (barWidth3 / 2);

        // 2. Ajuste vertical preciso (ajusta el -100 según necesites)
        float barHeight3 = healthBar3.resolvedStyle.height;
        healthBar3.style.top = Screen.height - screenPos3.y - barHeight3 - offsetY;

   

    }

}