using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorTerminal : Interactable
{
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject terminalUI;
    [SerializeField] private TextMeshProUGUI graphName;
    [SerializeField] private RawImage graphImage;
    [SerializeField] private Graph graph;
    [SerializeField] private TextMeshProUGUI aNum;
    [SerializeField] private TextMeshProUGUI bNum;
    [SerializeField] private TextMeshProUGUI cNum;
    [SerializeField] private string nextScene;
    [SerializeField] private InputManager inputManager;
    private int uA, uB, uC = 0;
    private int a, b, c;
    void Start()
    {
        graphName.text = graph.SurfaceName;
        graphImage.texture = graph.equationFormula;
        a = Random.Range(3, 5);
        b = Random.Range(3, 5);
        c = Random.Range(3, 5);
    }

    void Update()
    {
        if (inputManager.UI.Exit.triggered && terminalUI.activeSelf)
        {
            Close();
        }
    }

    protected override void Interact()
    {
        inputManager.SwitchActionMap();
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
        graph.OriginalDraw(a, b, c);
        graph.UserDraw(uA, uB, uC);
        if (a == uA && b == uB && c == uC)
        {
            Close();
            Invoke("LoadNextLevel", 1);
        }
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

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void Close()
    {
        Time.timeScale = 1f;
        terminalUI.SetActive(false);
        inGameUI.SetActive(true);
        inputManager.SwitchActionMap();
    }
}
