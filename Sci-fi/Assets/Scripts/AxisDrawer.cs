using UnityEngine;

public class AxisDrawer : MonoBehaviour
{
    [SerializeField] private Material materialX;
    [SerializeField] private Material materialY;
    [SerializeField] private Material materialZ;
    private LineRenderer lineRenderer;
    private GameObject line;
    void Start()
    {
        CreateLine("XAxis", transform.position, Vector3.right, materialX);
        CreateLine("YAxis", transform.position, Vector3.up, materialY);
        CreateLine("ZAxis", transform.position, new Vector3(0, 0, 1), materialZ);
    }

    void Update()
    {

    }

    private void CreateLine(string name, Vector3 startPosition, Vector3 direcion, Material material)
    {
        line = new GameObject(name);
        line.transform.SetParent(transform);
        line.layer = LayerMask.NameToLayer("GraphCamera");
        lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = material;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, transform.position + direcion * 20);
    }
}
