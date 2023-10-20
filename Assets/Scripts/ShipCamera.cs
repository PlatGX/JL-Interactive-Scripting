using UnityEngine;

public class ShipCamera : MonoBehaviour
{
    private float startingFOV = 60;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.transform.GetChild(0).GetComponent<Camera>();
        startingFOV = cam.fieldOfView;
    }

    public void ZoomOut()
    {
        cam.fieldOfView = startingFOV + 15;
    }

    public void DefaultZoom()
    {
        cam.fieldOfView = startingFOV;
    }
}
