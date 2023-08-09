using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton pattern
    public static BuildManager instance;

    void Awake()
    {
        // If there is already a BuildManager, return
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    public GameObject standardTurretPrefab;

    public GameObject anotherTurretPrefab;


    private GameObject _turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
}