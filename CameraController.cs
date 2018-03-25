using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
   
  //  private bool doMovement = true;
    public float panSpeed = 30f;
    
    public float panBorderThickness = 50f;
    public float scrollSpeed = 5f;
    public float minY = 25f;
    public float maxY = 80f;
    public float minX = -40f;
    public float maxX = 40f;
    public float minZ = -40f;
    public float maxZ = 40f;

    [Header("Camera rotation")]
    public float rotationSpeed = 5f;

    //public float minRotY, maxRotY;

    // Update is called once per frame
    //camera controls
    void Update()
    {       
        if (GameManager.gameEnded)
        {
            this.enabled = false;
            return;
        }
/*
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;
            */

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 2000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;

        // Rotation controls
        if (Input.GetButton("Fire2"))
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, 0f, Space.World);
        }
    }
}