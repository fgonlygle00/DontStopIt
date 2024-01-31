using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private GameObject _entranceImage;
    [SerializeField] private GameObject _gameClearEnding;

    private void Update()
    {
        if (!_entranceImage.activeSelf)
        {
            return;
        }
        GameClear();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            _entranceImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        _entranceImage.SetActive(false);
    }

    private void GameClear()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _gameClearEnding.SetActive(true);
        }
    }
}
