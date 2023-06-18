using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private GameObject craftUI;
    [SerializeField] private GameObject taskField;
    [SerializeField] private TextMeshProUGUI taskInfo;
    [SerializeField] private Image taskImage;
    [SerializeField] private Button buttonA;
    [SerializeField] private TextMeshProUGUI textA;
    [SerializeField] private Button buttonB;
    [SerializeField] private TextMeshProUGUI textB;
    [SerializeField] private Button buttonC;
    [SerializeField] private TextMeshProUGUI textC;
    [SerializeField] private GameObject shotButton;
    [SerializeField] private InputManager inputManager;
    private GameObject[] abilitiesButtons;
    private CraftModel model;

    private void Start()
    {
        abilitiesButtons = new[] { shotButton };
        shotButton.GetComponent<Button>().onClick.AddListener(() => SetActiveAbility(Ability.Shot));
        buttonA.onClick.AddListener(() => GiveAnswer(0));
        buttonB.onClick.AddListener(() => GiveAnswer(1));
        buttonC.onClick.AddListener(() => GiveAnswer(2));
        model = FindObjectOfType<CraftModel>();
    }
    void Update()
    {
        if (inputManager.UI.Exit.triggered && craftUI.activeSelf)
        {
            Close();
        }
    }

    public void Show()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        craftUI.SetActive(true);
        SetAbilitiesButtonsInactive();
        inputManager.SwitchActionMap();
    }

    private void Close()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        craftUI.SetActive(false);
        taskField.SetActive(false);
        inputManager.SwitchActionMap();
    }

    public void ShowTask(CraftTask task, Answer[] answers)
    {
        taskInfo.text = task.Info;
        taskImage.sprite = task.Image;
        textA.text = answers[0].Info;
        textB.text = answers[1].Info;
        textC.text = answers[2].Info;
    }

    private void SetAbilitiesButtonsInactive()
    {
        foreach (var btn in abilitiesButtons)
        {
            SetAbilityButtonAlpha(btn, .7f);
        }
    }

    private void SetAbilityButtonAlpha(GameObject btn, float newAlpha)
    {
        Color col = btn.GetComponent<Image>().color;
        col.a = newAlpha;
        btn.GetComponent<Image>().color = col;
    }

    private void SetActiveAbility(Ability ability)
    {
        float newAlpha;
        if (model.CurrentAbility == ability)
        {
            model.CurrentAbility = Ability.Null;
            newAlpha = .7f;
            taskField.SetActive(false);
        }
        else
        {
            model.CurrentAbility = ability;
            taskField.SetActive(true);
            newAlpha = 1f;
        }
        SetAbilityButtonAlpha(abilitiesButtons[(int)ability - 1], newAlpha);
    }

    private void GiveAnswer(int index)
    {
        model.CheckAnswer(index);
    }
}

public enum Ability
{
    Null,
    Shot
}