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
        if (ZoomSize <= 5)
            ZoomSize = 5;
        else if (ZoomSize >= 100)
            ZoomSize = 100;
        _camera.orthographicSize = ZoomSize;
    }
}
