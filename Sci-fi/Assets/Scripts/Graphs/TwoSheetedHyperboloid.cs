using System.Collections.Generic;
using UnityEngine;

public class TwoSheetedHyperboloid : Graph
{
    private void Start()
    {
        SurfaceName = "Двуполостный гиперболоид";
    }
    protected override void Draw(int a, int b, int c, GameObject nodeObject)
    {
        var nodesToDraw = new List<Vector3>();
        if (a == 0 || c == 0 || b == 0) return;
        for (var x = -20; x <= 20; x++)
        {
            for (var y = -10; y <= 10; y++)
            {
                for (var z = -20; z <= 20; z++)
                {
                    if (x * x / (a * a) - y * y / (b * b) + z * z / (c * c) == -1)
                        nodesToDraw.Add(new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z));
                }
            }
        }
        foreach (var node in nodesToDraw)
        {
            Instantiate(nodeObject, node, Quaternion.identity, transform);
        }
    }
}
