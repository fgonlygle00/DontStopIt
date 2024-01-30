using UnityEngine;

public class Opening : MonoBehaviour
{
    [SerializeField] private GameObject _pressAnyKey;
    [SerializeField] private GameObject _sawheel;

    [SerializeField] private void GameStart()
    {
        _pressAnyKey.SetActive(true);
    }

    private void Update()
    {
        if (_pressAnyKey.activeSelf && Input.anyKey)
        {
            _sawheel.SetActive(true);
        }
    }
}
