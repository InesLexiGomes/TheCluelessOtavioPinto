using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string mainScene;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject buttons;

    public void StartGame()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
        buttons.SetActive(false);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
        buttons.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
