using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningUIController : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("CharacterChoiceScene");
    }
}
