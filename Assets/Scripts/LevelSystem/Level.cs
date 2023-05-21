using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private HexCube _hexCube;
    [SerializeField] private string _lvlNum;

    public HexCube HexCube => _hexCube;
    public string LvlNuum => _lvlNum;

    public void DestroySelf()
    {
        gameObject.SetActive(false); 
    }
}
