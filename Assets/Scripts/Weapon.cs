using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Linq;

[RequireComponent(typeof(Image))]  // Asegura que exista Image

public class Weapon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private WeaponData weaponData;

    //public Image weaponImage;
    //public TMP_Text weaponNameText;
    //public TMP_Text weaponCostText;

    //private void OnEnable()
    //{
    //    // Auto-asignación inteligente
    //    weaponImage = GetComponent<Image>();

    //    // Busca los textos hermanos (hijos directos del mismo Canvas)
    //    Transform parent = transform.parent;
    //    if (parent != null)
    //    {
    //        // Filtra solo los TMP_Text que siguen el patrón de nombres
    //        TMP_Text[] siblingTexts = parent.GetComponentsInChildren<TMP_Text>()
    //            .Where(t => t.transform.parent == parent)
    //            .OrderBy(t => t.name).ToArray();

    //        // Asignación basada en convención de nombres
    //        foreach (var text in siblingTexts)
    //        {
    //            if (text.name.Contains("NameTMP")) weaponNameText = text;
    //            else if (text.name.Contains("CostTMP")) weaponCostText = text;
    //        }
    //    }

    //    UpdateUI();
    //}

    //private void UpdateUI()
    //{
    //    if (weaponData == null) return;

    //    if (weaponImage != null)
    //        weaponImage.sprite = weaponData.weaponSprite;

    //    if (weaponNameText != null)
    //        weaponNameText.text = weaponData.weaponName;

    //    if (weaponCostText != null)
    //        weaponCostText.text = $"{weaponData.cost}G";
    //}


    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {

        Debug.Log("Click detectado en: " + gameObject.name); // Paso 1

        if (WeaponManager.Instance == null)
        {
            Debug.LogError("UIManager no encontrado!");
            return;
        }

        Debug.Log("Intentando mostrar info del arma"); // Paso 2
        WeaponManager.Instance.ShowWeaponInfo(weaponData);
    }

//#if UNITY_EDITOR
//    [ContextMenu("Auto-Setup")]
//    private void EditorAutoSetup()
//    {
//        OnEnable();
//        UnityEditor.EditorUtility.SetDirty(this);
//    }
//#endif

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
    //    {
    //        print("Layer ID " + gameObject.layer + " | Name " + LayerMask.NameToLayer("Enemy"));
    //    }

    //    print("OnPointerEnter " + gameObject.name);
    //    renderer.material.color = Color.red;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    print("OnPointerExit " + gameObject.name);
    //    renderer.material.color = Color.gray;
    //}
}