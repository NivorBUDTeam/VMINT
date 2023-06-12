using UnityEngine;

public class Graph : MonoBehaviour
{
    public string SurfaceName { get; protected set; }
    public Texture equationFormula;
    public GameObject originalGraphNode;
    public GameObject userGraphNode;

    public void OriginalDraw(int a, int b, int c)
    {
        Draw(a, b, c, originalGraphNode);
    }

    public void UserDraw(int a, int b, int c)
    {
        Draw(a, b, c, userGraphNode);
    }

    protected virtual void Draw(int a, int b, int c, GameObject nodeObject) { }
}
