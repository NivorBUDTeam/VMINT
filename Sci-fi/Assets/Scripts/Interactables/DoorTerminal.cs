using TMPro;
using UnityEngine;

public class DoorTerminal : Interactable
{
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject terminalUI;
    [SerializeField] private GameObject graph;
    [SerializeField] private TextMeshProUGUI aNum;
    [SerializeField] private TextMeshProUGUI bNum;
    [SerializeField] private TextMeshProUGUI cNum;
    private Ellipsoid ellipsoid;
    private int uA, uB, uC = 0;
    private int a = 5;
    private int b = 3;
    private int c = 4;
    void Start()
    {
        ellipsoid = graph.GetComponent<Ellipsoid>();
    }

    void Update()
    {

    }

    protected override void Interact()
    {
        Time.timeScale = 0f;
        inGameUI.SetActive(false);
        terminalUI.SetActive(true);
        DrawGraph();
    }

    private void ClearGraph()
    {
        foreach (Transform child in graph.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void DrawGraph()
    {
        aNum.text = uA.ToString();
        bNum.text = uC.ToString();
        cNum.text = uB.ToString();
        ClearGraph();
        ellipsoid.OriginalDraw(a, b, c);
        ellipsoid.UserDraw(uA, uB, uC);
    }

    private int ChangeValue(int value, int delta) => (value + delta) < 0 || (value + delta) > 5 ? value : value + delta;
    public void AIncrease()
    {
        uA = ChangeValue(uA, 1);
        DrawGraph();
    }

    public void ADecrease()
    {
        uA = ChangeValue(uA, -1);
        DrawGraph();
    }

    public void BIncrease()
    {
        uC = ChangeValue(uC, 1);
        DrawGraph();
    }

    public void BDecrease()
    {
        uC = ChangeValue(uC, -1);
        DrawGraph();
    }

    public void CIncrease()
    {
        uB = ChangeValue(uB, 1);
        DrawGraph();
    }

    public void CDecrease()
    {
        uB = ChangeValue(uB, -1);
        DrawGraph();
    }
}
