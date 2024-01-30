using UnityEngine;

public class OpeningChangeUp : MonoBehaviour
{
    [SerializeField] private GameObject _pressAnyKey;
    [SerializeField] private GameObject _jellyPile;
    [SerializeField] private GameObject _sawheel;
    [SerializeField] private GameObject _uiBtn;

    private void ChangeUp()
    {
        _pressAnyKey.SetActive(false);
        _jellyPile.SetActive(false);
    }

    private void MakeUI()
    {
        _uiBtn.SetActive(true);
        _sawheel.SetActive(false);
    }
}
