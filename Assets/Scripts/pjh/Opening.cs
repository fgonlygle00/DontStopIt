using UnityEngine;

public class Opening : MonoBehaviour
{
    [SerializeField] private GameObject _pressAnyKey;
    [SerializeField] private GameObject _skipBtn;
    [SerializeField] private GameObject _sawheel;

    private void GameStart()
    {
        _skipBtn.SetActive(false);
        _pressAnyKey.SetActive(true);
    }

    private void Update()
    {
        if (_pressAnyKey.activeSelf && Input.anyKey)
        {
            _sawheel.SetActive(true);
        }
    }

    public void SkipBtn()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("openingAnimation", 0, 1);
    }
}
