using UnityEngine;

public class Orbita : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public float Radius = 0.1f;
    public Transform CentroDaRotacao;

    private float _angle;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.sortingLayerName = "Fundo";
        _lineRenderer.sortingOrder = 2;
        _lineRenderer.startColor = Color.white;
        _lineRenderer.widthMultiplier = 0.300f;
        _lineRenderer.material = Resources.Load("Materials/MaterialWhite", typeof(Material)) as Material;
        _lineRenderer.loop = true;

    }

    private void Update()
    {
        DesenharOrbita();
        Orbitar();
    }

    private void Orbitar()
    {
        _angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * Radius;
        transform.position = CentroDaRotacao.position + offset;
    }

    void DesenharOrbita()
    {
        int pontos = 50;
        float angle = 2 * Mathf.PI / pontos;
        _lineRenderer.positionCount = pontos;

        for (int i = 0; i < pontos; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                                                     new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                                       new Vector4(0, 0, 1, 0),
                                       new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, Radius, 0);
            _lineRenderer.SetPosition(i, CentroDaRotacao.position + rotationMatrix.MultiplyPoint(initialRelativePosition));
        }
    }

    // O debug é mais facil com linha inicial e linha final rsrs.
    //void DesenharOrbita(Vector2 center, float radius, int numSides)
    //{
    //    Vector2 startCorner = new Vector2(radius, 0) + center;
    //    Vector2 previousCorner = startCorner;
    //    for (int i = 1; i < numSides; i++)
    //    {
    //        float cornerAngle = 2f * Mathf.PI / numSides * i;
    //        Vector2 currentCorner = new Vector2(Mathf.Cos(cornerAngle) * radius, Mathf.Sin(cornerAngle) * radius) + center;
    //        Debug.DrawLine(currentCorner, previousCorner);
    //        _lineRenderer.SetPosition(i, currentCorner);
    //        previousCorner = currentCorner;
    //    }
    //    // Finaliza conectando o ultimo canto com o primeiro.
    //    Debug.DrawLine(startCorner, previousCorner);
    //    //_lineRender.SetPosition(51, previousCorner);
    //
}
