using UnityEngine;

public class Saw_Wheel : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverEnding;

    public float speed = 2f;

    void Update()
    {
        MoveUp();
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jelly")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "player")
        {
            Destroy(collision.gameObject);
            _gameOverEnding.SetActive(true);
        }
    }
}