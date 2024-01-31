using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearEnding : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void RePlayBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StageChoiceBtn()
    {
        //¹Ì±¸Çö
    }
}
