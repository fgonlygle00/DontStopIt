using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public static Death instance;

    public void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Invoke("ReloadScene", 2f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
