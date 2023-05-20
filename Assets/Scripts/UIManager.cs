using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private TextMeshProUGUI _lvlNum;
    [SerializeField] private LeveLoader _loader;

    private CheckWin _checker;

    private void OnEnable()
    {
        _loader.LvlLoladed.AddListener(FindChecker);
        _loader.LvlLoladed.AddListener(CloseWinCanvas);
    }

    private void Start()
    {
        UpdateLvlNum();
    }

    private void FindChecker()
    {
      //  _loader.LvlLoladed.RemoveListener(FindChecker);
        _checker = FindObjectOfType<CheckWin>();
        _checker.IsWin.AddListener(ShowWinCanvas);
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

    private void UpdateLvlNum()
    {
        _lvlNum.text = "Level: " + (PlayerPrefs.GetInt("CurrentLevel", 0) + 1).ToString();
    }

}