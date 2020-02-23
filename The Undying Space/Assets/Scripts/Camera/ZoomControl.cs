using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    private const string MOUSE = "Mouse ScrollWheel";
    private float _zoomVel = 80f;
    private Camera _camera;
    void Start() => _camera = GetComponent<Camera>();

    void Update()
    {

        if (Input.GetAxis(MOUSE) > 0 || Input.GetAxis(MOUSE) < 0)
            ZoomOrthoCamera(_camera.ScreenToWorldPoint(Input.mousePosition), Input.GetAxis(MOUSE));

        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{
        //    ZoomOrthoCamera(_camera.ScreenToWorldPoint(Input.mousePosition), ZoomSize);
        //}

        //// Scoll back
        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{
        //    ZoomOrthoCamera(_camera.ScreenToWorldPoint(Input.mousePosition), ZoomSize);
        //}
    }

    // Ortographic camera zoom towards a point (in world coordinates). Negative amount zooms in, positive zooms out
    void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
    {
        // Calculate how much we will have to move towards the zoomTowards position
        float multiplier = (_zoomVel / _camera.orthographicSize * amount);

        // Move camera
        transform.position += (zoomTowards - transform.position) * multiplier;
        // Zoom camera
        _camera.orthographicSize -= amount * _zoomVel;
        // Limit zoom
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 20, 400);
    }
}
