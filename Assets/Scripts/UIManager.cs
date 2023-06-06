using Lean.Localization;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private TextMeshProUGUI _lvlNum;
    [SerializeField] private LeveLoader _loader;

    private CheckWin _checker;

    private void OnEnable()
    {
        _loader.LvlLoladed.AddListener(FindChecker);
        _loader.LvlLoladed.AddListener(CloseWinCanvas);
        //LeanLocalization.OnLocalizationChanged += UpdateLvlNum;
    }

    //private void OnDisable()
    //{
    //    LeanLocalization.OnLocalizationChanged -= UpdateLvlNum;
    //}

    private void Start()
    {
       
    }

    private void FindChecker()
    {
        _checker = FindObjectOfType<CheckWin>();
        _checker.IsWin.AddListener(ShowWinCanvas);
        UpdateLvlNum();
    }


    private void ShowWinCanvas()
    {
        _winCanvas.SetActive(true);
    }


    private void CloseWinCanvas()
    {
        _winCanvas.SetActive(false);
        UpdateLvlNum();
    }

    public void HideMenu()
    {
        _menuCanvas.gameObject.SetActive(false);
        _gameUI.gameObject.SetActive(true);
    }

    public void ShowMenu()
    {
        _menuCanvas.gameObject.SetActive(true);
        _loader.RemoveLvl();
    }

    private void UpdateLvlNum()
    {
        _lvlNum.text = $"{LeanLocalization.GetTranslationText("level_word")} {_loader.Level.LvlNuum}";
    }

}