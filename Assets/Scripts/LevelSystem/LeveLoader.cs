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
        LoadLevel(PlayerPrefs.GetInt(CurLvlPref, 0));
    }

    public void LoadLevel(int lvl = 0)
    {
        if (_loadedLvl != null) { _loadedLvl.DestroySelf(); _loadedLvl = null; }
        _loadedLvl = Instantiate(_levels[lvl]);
        _loadedLvl.transform.parent = _point;
        _loadedLvl.transform.localPosition = Vector3.zero;
        LvlLoladed?.Invoke();
    }

    public void LoadNextLvl()
    {
        if (_currentLvl == _levels.Length - 1)
            _currentLvl = 0;
        else 
            _currentLvl++;
        // PlayerPrefs.SetInt(CurLvlPref, _currentLvl);
        LoadLevel(_currentLvl);
    }


}
