using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Character
{
    MaskDude = 1,
    NinjaFrog,
    PinkMan,
    VirtualGuy,
}

public class CharacterChoiceController : MonoBehaviour
{
    [SerializeField] private GameObject _characterChoice;
    [SerializeField] private GameObject[] _character;
    [SerializeField] private GameObject _final;

    private Sprite _choice;
    private int _order;

    // Start is called before the first frame update
    private void Awake()
    {
        _characterChoice.transform.Find("SelectedCharacter").GetComponent<Image>().sprite = Resources.Load<Sprite>("MaskDude");
        _character[0].SetActive(true);
        _order = 1;
    }

    private void Update()
    {
        switch ((Character)_order)
        {
            case Character.MaskDude: _characterChoice.transform.Find("SelectedCharacter").GetComponent<Image>().sprite = Resources.Load<Sprite>("MaskDude"); break;
            case Character.NinjaFrog: _characterChoice.transform.Find("SelectedCharacter").GetComponent<Image>().sprite = Resources.Load<Sprite>("NinjaFrog"); break;
            case Character.PinkMan: _characterChoice.transform.Find("SelectedCharacter").GetComponent<Image>().sprite = Resources.Load<Sprite>("PinkMan"); break;
            case Character.VirtualGuy: _characterChoice.transform.Find("SelectedCharacter").GetComponent<Image>().sprite = Resources.Load<Sprite>("VirtualGuy"); break;
        }
    }

    public void RightChoiceBtn()
    {
        if (0 < _order && _order < 5) _order++;
        if (0 >= _order || _order >= 5) _order = 1;
    }

    public void LeftChoiceBtn()
    {
        if (0 < _order &&_order < 5) _order--;
        if (0 >= _order || _order >= 5) _order = 4;
    }

    public void CharacterBtn()
    {
        for (int i = 0; i < _character.Length; i++)
        {
            _character[i].SetActive(false);
        }
        switch ((Character)_order)
        {
            case Character.MaskDude: _character[0].SetActive(true); break;
            case Character.NinjaFrog: _character[1].SetActive(true); break;
            case Character.PinkMan: _character[2].SetActive(true); break;
            case Character.VirtualGuy: _character[3].SetActive(true); break;
        }
    }

    public void FinalChoice()
    {
        _final.SetActive(true);
    }

    public void RealGameStart()
    {
        GameObject finalCharacter = _character.Where(obj => obj.activeSelf).FirstOrDefault();
        if (finalCharacter != null) PlayerPrefs.SetString("FinalCharacter", finalCharacter.name);
        else return;
        SceneManager.LoadScene("MainScene");
    }

    public void SelectAgin()
    {
        _final.SetActive(false);
    }
}
