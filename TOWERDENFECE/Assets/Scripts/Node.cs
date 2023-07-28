using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Color startColor;

    private Renderer rend;

    BuildManager buildManager;


    void Start()
    {
        //Get the renderer component
        rend = GetComponent<Renderer>();
        //Make it back to the original color
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        //If the mouse is over a UI element, return
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        //If there is a turret, don't build
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        //Build a turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        //If the mouse is over a UI element, return
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        //On mouse enter, change the color to hover color
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        //On mouse exit, make it back to the original color
        rend.material.color = startColor;
    }
}