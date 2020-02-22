using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{

    public float ZoomSize = 60;
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        ZoomSize -= Input.GetAxis("Mouse ScrollWheel") * 10;
        //if (ZoomSize <= 5)
        //    ZoomSize = 5;
        //else if (ZoomSize >= 100)
        //    ZoomSize = 100;
        //_camera.orthographicSize = ZoomSize;
        // Scroll forward
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        }

        // Scoll back
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), -1);
        }
    }

    // Ortographic camera zoom towards a point (in world coordinates). Negative amount zooms in, positive zooms out
    // TODO: when reaching zoom limits, stop camera movement as well
    void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
    {
        // Calculate how much we will have to move towards the zoomTowards position
        float multiplier = (1.0f / _camera.orthographicSize * amount);

        // Move camera
        transform.position += (zoomTowards - transform.position) * multiplier;

        // Zoom camera
        _camera.orthographicSize -= amount;

        // Limit zoom
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 20, 400);
    }
}
