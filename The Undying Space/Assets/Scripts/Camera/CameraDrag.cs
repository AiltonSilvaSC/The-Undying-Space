using Assets.Scripts;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        ResetCamera = _camera.transform.position;
    }
    void LateUpdate()
    {
        if (Input.GetButton("Fire3"))
        {
            Diference = _camera.ScreenToWorldPoint(Input.mousePosition) - _camera.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = _camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
            Drag = false;
        if (Drag)
        {
            _camera.transform.position = Origin - Diference;
            _camera.transform.position = new Vector3(
    Mathf.Clamp(transform.position.x, -500f, 500f),
    Mathf.Clamp(transform.position.y, -500f, 500f),
    transform.position.z);
        }

        ////RESET CAMERA
        //if (Input.GetMouseButton(1))
        //{
        //    Camera.main.transform.position = ResetCamera;
        //}
    }
}