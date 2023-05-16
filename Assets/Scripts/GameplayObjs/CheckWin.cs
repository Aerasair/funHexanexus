using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    [SerializeField] private Tile[] _tiles;
    [SerializeField] private HexCube _hexCube;
    private bool[] _results = new bool[8];

    private void Start()
    {
        _hexCube.IsRotationFinished.AddListener(Check);
       
    }



    private void Check()
    {
      
        for (int i = 0; i < 8; i++)
        {
            bool res = _tiles[i].CheckWin();
            _results[i] = res;
            Debug.Log($"{_tiles[i].name} {_tiles[i].CheckWin()}");
        }
        
        foreach(var item in _results)
        {
            if (item == false) return;
        }
        
        Debug.Log("Win");
    }
   
  
}

public class Result
{
    public Result(bool resultBool)
    {
        _resultBool = false;
    }

    private bool _resultBool = false; 

    public bool ResultBool => _resultBool;

}