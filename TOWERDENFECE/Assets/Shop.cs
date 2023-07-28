using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected!");
        // Set turret to build
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Selected!");
        // Set turret to build
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}