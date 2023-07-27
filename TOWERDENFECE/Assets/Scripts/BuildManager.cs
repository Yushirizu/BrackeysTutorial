using System;
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

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}