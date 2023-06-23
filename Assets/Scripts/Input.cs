using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Input : MonoBehaviour
{
    private LeveLoader _loader;
    private HexCube _hexCube;
    
    [Inject]
    private void Construct(LeveLoader loader)
    {
        _loader = loader;
    }

    private void OnEnable()
    {
        _loader.LvlLoladed.AddListener(FindHexCube);
    }

    #region System
    private void FindHexCube()
    {
        _hexCube = _loader.Level.HexCube;
    }

    public void ResetSc()
    {
        _loader.ResetLvl();
    }

    public void LoadNextLvl()
    {
        _loader.LoadNextLvl();
    }
   
    public void RotateCam()
    {
   
    }
    
    
    
    #endregion

    #region Control of cube
    public void RotateLeft()
    {
        _hexCube.rotateSelected(90);
    }
    public void RotateRight()
    {
        _hexCube.rotateSelected(-90);
    }
    public void SelectTop()
    {
        _hexCube.SelectTop();
    }
    public void SelectBot()
    {
        _hexCube.SelectBot();
    }
    public void SelectLeftLeft()
    {
        _hexCube.SelectLeftLeft();
    }
    public void SelectLeftRight()
    {
        _hexCube.SelectLeftRight();
    }
    public void SelectRightLeft()
    {
        _hexCube.SelectRightLeft();
    }
    public void SelectRightRight()
    {
        _hexCube.SelectRightRight();
    }
    #endregion
}
