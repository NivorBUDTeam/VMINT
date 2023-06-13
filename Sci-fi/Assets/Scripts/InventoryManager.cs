using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public TextMeshProUGUI shotsCounter;
    void Start()
    {

    }

    void Update()
    {
        shotsCounter.text = Inventory.Instance.ShotsCounter.ToString();
    }
}
