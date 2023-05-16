using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool _isWinTile;
    [SerializeField] private Material _matDef;
    [SerializeField] private Material _matWin;
    [SerializeField] private Selecter _tileSelecter;

    private Renderer _render;

    public void Start()
    {
        _render = GetComponent<Renderer>();
        SetActualColor();
    }


    public void SetActualColor()
    {
        if(_isWinTile) _render.sharedMaterial = _matWin;
        else _render.sharedMaterial = _matDef;
    }

    public bool CheckWin()
    {
        return _tileSelecter.CheckWin(_isWinTile);
    }


    #region editor scripts

    public void SetWinMat()
    {
        _isWinTile = true;
        GetComponent<Renderer>().sharedMaterial = _matWin;
    }

    public void SetNormalMat()
    {
        _isWinTile = false;
        GetComponent<Renderer>().sharedMaterial = _matDef;
    }

    #endregion

}
