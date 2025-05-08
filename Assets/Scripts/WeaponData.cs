using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Basic Info")]
    public string weaponName;
    [TextArea(3, 5)]
    public string description;
    public int cost;
    public int damage;

    [Header("Visuals")]
    public Sprite weaponSprite;  // <-- Añade esta línea
    //public GameObject weaponPrefab;

    public string WeaponName { get { return weaponName; } }
    public string Description { get { return description; } }
    public int Cost { get { return cost; } }
    public int Damage { get { return damage; } }

    public void PrintWeaponData()
    {

        var sb = new StringBuilder();
        sb.AppendLine($"=== DATOS DEL ARMA ===");
        sb.AppendLine($"Nombre: {WeaponName}");
        sb.AppendLine($"Descripción: {Description}");
        sb.AppendLine($"Costo: {Cost} oro");
        sb.AppendLine($"Daño: {Damage} puntos");
        Debug.Log(sb.ToString());
    }
}


