using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject pauseUI;

    void Update()
    {
        if (inputManager.OnFoot.Pause.triggered && pauseUI.activeSelf)
            Close();
        else if (inputManager.OnFoot.Pause.triggered)
            Show();
    }

    private void Show()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        pauseUI.SetActive(true);
    }

    private void Close()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        pauseUI.SetActive(false);
    }

    public void ContinueGame()
    {
        Close();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
