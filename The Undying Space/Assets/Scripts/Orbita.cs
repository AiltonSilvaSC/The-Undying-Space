using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbita : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public float Radius = 0.1f;

    public Transform CentroDaRotacao;
    private float _angle;

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * Radius;
        transform.position = CentroDaRotacao.position + offset;

        DebugDrawPolygon(polygonCenter, polygonRadius, numberOfSides);
    }

    public int numberOfSides;
    public float polygonRadius;
    public Vector2 polygonCenter;

    void DebugDrawPolygon(Vector2 center, float radius, int numSides)
    {
        Vector2 startCorner = new Vector2(radius, 0) + center;
        Vector2 previousCorner = startCorner;
        for (int i = 1; i < numSides; i++)
        {
            float cornerAngle = 2f * Mathf.PI / (float)numSides * i;
            Vector2 currentCorner = new Vector2(Mathf.Cos(cornerAngle) * radius, Mathf.Sin(cornerAngle) * radius) + center;
            Debug.DrawLine(currentCorner, previousCorner);
            previousCorner = currentCorner;
        }
        // Finaliza conectando o ultimo canto com o primeiro.
        Debug.DrawLine(startCorner, previousCorner);
    }
}
