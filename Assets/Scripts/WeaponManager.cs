using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class WeaponManager : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] public TMP_Text weaponNameText;
    [SerializeField] public TMP_Text descriptionText;
    [SerializeField] public TMP_Text costText;
    [SerializeField] public TMP_Text damageText;
    //[SerializeField] public GameObject weaponInfoPanel;

    private void OnEnable()
    {
        // Busca los textos hermanos (hijos directos del mismo Canvas)
        Transform parent = transform.parent;
        if (parent != null)
        {
            // Filtra solo los TMP_Text que siguen el patrón de nombres
            TMP_Text[] siblingTexts = parent.GetComponentsInChildren<TMP_Text>()
                .Where(t => t.transform.parent == parent)
                .OrderBy(t => t.name).ToArray();

            // Asignación basada en convención de nombres
            foreach (var text in siblingTexts)
            {
                if (text.name.Contains("NameTMP")) weaponNameText = text;
                if (text.name.Contains("DescriptionTMP")) descriptionText = text;
                else if (text.name.Contains("CostTMP")) costText = text;
                else if (text.name.Contains("DamageTMP")) damageText = text;
            }
        }

    }

    public static WeaponManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowWeaponInfo(WeaponData weaponData)
    {
        //weaponInfoPanel.SetActive(true);
        weaponNameText.text = weaponData.WeaponName;
        descriptionText.text = weaponData.Description;
        costText.text = $"Costo: {weaponData.Cost} oro";
        damageText.text = $"Daño: {weaponData.Damage}";
        Debug.Log("click");
    }
}