using UnityEngine;

public class GunShop : Interactable
{
    [SerializeField] private WeaponData weaponInside;

    public override void Interact()
    {
        Debug.Log($"Obteniendo arma: {weaponInside.weaponName}");
        // Lógica para dar el arma al jugador
        ShowCanvas();
    }
}
