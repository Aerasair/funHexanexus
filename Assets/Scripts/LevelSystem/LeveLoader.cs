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
    public UnityEvent LvlLoladed;

    private void Start()
    {
        LoadLevel(PlayerPrefs.GetInt(CurLvlPref, 0));
    }
    
    private void LoadLevel(int lvl)
    {
        if (_loadedLvl != null) { _loadedLvl.transform.parent = null; Destroy(_loadedLvl.gameObject); _loadedLvl = null; }
        _loadedLvl = Instantiate(_levels[lvl]);
        _loadedLvl.transform.parent = _point;

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
