using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Color startColor;

    private Renderer rend;

    void Start()
    {
        //Get the renderer component
        rend = GetComponent<Renderer>();
        //Make it back to the original color
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        //If there is a turret, don't build
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        //On mouse enter, change the color to hover color
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        //On mouse exit, make it back to the original color
        rend.material.color = startColor;
    }
}