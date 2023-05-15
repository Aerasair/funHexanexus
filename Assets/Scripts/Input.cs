using UnityEngine;
using UnityEngine.SceneManagement;

public class Input : MonoBehaviour
{
    [SerializeField] private HexCube _hexCube;

    public void RotateLeft()
    {
        _hexCube.rotateSelected(90);
    }

    public void RotateRight()
    {
        _hexCube.rotateSelected(-90);
    }

    public void ResetSc()
    {
        SceneManager.LoadScene(0);
    }
}
