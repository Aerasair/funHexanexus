using System;
using UnityEngine;
using UnityEngine.Events;

public class LeveLoader : MonoBehaviour
{
    [SerializeField] private Level[] _levels;
    [SerializeField] private Transform _point;

    private int _currentLvl = 0;
    private string CurLvlPref = "CurrentLevel";
    private Level _loadedLvl;

    public Level Level => _loadedLvl;
    [HideInInspector] public UnityEvent LvlLoladed;

    private void Start()
    {
        if (TryLoadLevelFromScene()) return;
        LoadLevel(PlayerPrefs.GetInt(CurLvlPref, 0));
    }

    private bool TryLoadLevelFromScene()
    {
        if (_point.transform.childCount == 0) return false;
        Level sceneLvl = _point.GetChild(0).gameObject.GetComponent<Level>();
        if (sceneLvl != null && sceneLvl.gameObject.activeSelf) 
        {
            _loadedLvl = sceneLvl;
            LvlLoladed?.Invoke();
            return true; 
        }
        return false;
    }

    public void LoadLevel(int lvl = 0)
    {
        if (_loadedLvl != null) { _loadedLvl.DestroySelf(); _loadedLvl = null; }
        _loadedLvl = Instantiate(_levels[lvl]);
        _loadedLvl.transform.parent = _point;
        _loadedLvl.transform.localPosition = Vector3.zero;
        _currentLvl = lvl;
        LvlLoladed?.Invoke();
    }

    public void LoadNextLvl()
    {
        if (_currentLvl == _levels.Length - 1)
            _currentLvl = 0;
        else 
            _currentLvl++;
        PlayerPrefs.SetInt(CurLvlPref, _currentLvl);
        LoadLevel(_currentLvl);
    }


}
