using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{

    public float ZoomSize = 20;
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        ZoomSize -= Input.GetAxis("Mouse ScrollWheel") * 8;
        if (ZoomSize <= 5)
            ZoomSize = 5;
        else if (ZoomSize >= 50)
            ZoomSize = 50;
        _camera.orthographicSize = ZoomSize;
    }
}
