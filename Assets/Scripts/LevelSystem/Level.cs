using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private HexCube _hexCube;

    public HexCube HexCube => _hexCube;
}
