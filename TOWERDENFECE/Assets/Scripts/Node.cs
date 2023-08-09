using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject _turret;

    private Color _startColor;

    private Renderer _rend;

    BuildManager _buildManager;


    void Start()
    {
        //Get the renderer component
        _rend = GetComponent<Renderer>();
        //Make it back to the original color
        _startColor = _rend.material.color;

        _buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        //If the mouse is over a UI element, return
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        //If there is a turret, don't build
        if (_turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        //Build a turret
        GameObject turretToBuild = _buildManager.GetTurretToBuild();
        _turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        //If the mouse is over a UI element, return
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        //On mouse enter, change the color to hover color
        _rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        //On mouse exit, make it back to the original color
        _rend.material.color = _startColor;
    }
}