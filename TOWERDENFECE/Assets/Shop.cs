using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager _buildManager;

    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected!");
        // Set turret to build
        _buildManager.SetTurretToBuild(_buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Selected!");
        // Set turret to build
        _buildManager.SetTurretToBuild(_buildManager.anotherTurretPrefab);
    }
}