using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private HexCube _hexCube;

    public HexCube HexCube => _hexCube;

    public void DestroySelf()
    {
        gameObject.SetActive(false); 
    }
}
