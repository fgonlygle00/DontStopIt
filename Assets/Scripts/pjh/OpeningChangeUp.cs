using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _pressAnyKey;
    [SerializeField] private GameObject _jellyPile;

    [SerializeField] private void ChangeUp()
    {
        _pressAnyKey.SetActive(false);
        _jellyPile.SetActive(false);
    }
}
