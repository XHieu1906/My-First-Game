using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    public GameObject retryMenu;
    void Start(){
        retryMenu.SetActive(false);
    }

    public void ShowRetryMenu(){
        retryMenu.SetActive(true);
    }
     public void RetryGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
