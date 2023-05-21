using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private LeveLoader _loader;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Color _completedColor; 
	
    private void OnEnable()
    {
        SetColorBtns();
    }


    private void SetColorBtns()
    {
        int lvls = PlayerPrefs.GetInt("CurrentLevel", 0);
        int i = 0;
        for (; i < lvls; i++)
        {
            _buttons[i].GetComponent<Image>().color = _completedColor;
            _buttons[i].interactable = true;
        }
        _buttons[i].interactable = true;
    }

    public void LoadLvl(int lvl)
    {
        _loader.LoadLevel(lvl-1);
        _uiManager.HideMenu();
    }


}


