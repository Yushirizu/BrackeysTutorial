using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f;

    public float zoomSpeed = 20f;

    public float panBorderThickness = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle movement
            doMovement = !doMovement;
        }

        // If movement is disabled, return
        if (!doMovement)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            // Move camera forward
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            // Move camera backward
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            // Move camera right
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            // Move camera left
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // Scroll wheel zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 5000 * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, 10, 80);
        transform.position = pos;
    }
}