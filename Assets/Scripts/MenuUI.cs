using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Color _completedColor; 
    
    private LeveLoader _loader;
    private UIManager _uiManager;

    [Inject]
    private void Construct(LeveLoader loader, UIManager uIManager)
    {
        _loader = loader;
        _uiManager = uIManager;
    }
    private void OnEnable()
    {
        SetColorBtns();
    }


    private void SetColorBtns()
    {
        int lvls = PlayerPrefs.GetInt("CurrentLevel", 0);
        int i = 0;
        for (; i <= lvls; i++)
        {
            _buttons[i].GetComponent<Image>().color = _completedColor;
            _buttons[i].interactable = true;
        }
        //_buttons[i-1].interactable = true;
    }

    public void LoadLvl(int lvl)
    {
        _loader.LoadLevel(lvl);
        _uiManager.HideMenu();
    }


}