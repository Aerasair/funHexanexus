using UnityEngine;
using UnityEditor;
using DG.Tweening;

public class HexCube : MonoBehaviour
{
    [SerializeField] private PosCube _pos1, _pos2, _pos3, _pos4, _pos5, _pos6, _pos7, _pos8;
    [SerializeField] private Transform _parent;
    [SerializeField] private Selecter _s1, _s2, _s3, _s4, _s5, _s6, _s7, _s8;
    private AxisList _axis;


    private void Start()
    {
        SelectTop();
    }

    public void rotateSelected(int degrees)
    {
        switch (_axis)
        {
            case (AxisList.X):
                {
                    _parent.transform.DORotate(new Vector2(degrees, 0), 1f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetRelative(true);
                    break;
                }
            case (AxisList.Y):
                {
                    _parent.transform.DORotate(new Vector3(0, degrees, 0), 1f).SetEase(Ease.Linear).SetRelative(true);
                    break;
                }
            case (AxisList.Z):
                {
                    _parent.transform.DORotate(new Vector3(0, 0, degrees), 1f).SetEase(Ease.Linear).SetRelative(true);
                    break;
                }
        }
    }

    public void SelectTop()
    {
        UnParent();

        _pos1 = _s1.GetItem(1);
        _pos2 = _s1.GetItem(2);
        _pos5 = _s2.GetItem(1);
        _pos6 = _s2.GetItem(2);

        SetSelectCubes(_pos1, _pos2, _pos5, _pos6);
        _axis = AxisList.Y;
    }

    public void SelectBot()
    {
        UnParent();
        _pos3 = _s3.GetItem(1);
        _pos4 = _s3.GetItem(2);
        _pos7 = _s4.GetItem(1);
        _pos8 = _s4.GetItem(2);

        SetSelectCubes(_pos3, _pos4, _pos7, _pos8);
        _axis = AxisList.Y;
    }

    public void SelectLeftLeft()
    {
        UnParent();
        _pos1 = _s1.GetItem(1);
        _pos2 = _s1.GetItem(2);
        _pos3 = _s3.GetItem(1);
        _pos4 = _s3.GetItem(2);

        SetSelectCubes(_pos1, _pos2, _pos3, _pos4);
        _axis = AxisList.Z;
    }

    public void SelectLeftRight()
    {
        UnParent();
        _pos5 = _s2.GetItem(1);
        _pos6 = _s2.GetItem(2);
        _pos7 = _s4.GetItem(1);
        _pos8 = _s4.GetItem(2);
        SetSelectCubes(_pos5, _pos6, _pos7, _pos8);
        _axis = AxisList.Z;
    }


    public void SelectRightLeft()
    {
        UnParent();
        _pos1 = _s5.GetItem(1);
        _pos3 = _s5.GetItem(2);
        _pos5 = _s7.GetItem(1);
        _pos7 = _s7.GetItem(2);
        SetSelectCubes(_pos1, _pos3, _pos5, _pos7);
        _axis = AxisList.X;
    }

    public void SelectRightRight()
    {
        UnParent();
        _pos1 = _s6.GetItem(1);
        _pos2 = _s6.GetItem(2);
        _pos3 = _s8.GetItem(1);
        _pos4 = _s8.GetItem(2);
        SetSelectCubes(_pos2, _pos4, _pos6, _pos8);
        _axis = AxisList.X;
    }

    private void SetSelectCubes(PosCube cube1, PosCube cube2, PosCube cube3, PosCube cube4)
    {
        cube1.transform.SetParent(_parent);
        cube2.transform.SetParent(_parent);
        cube3.transform.SetParent(_parent);
        cube4.transform.SetParent(_parent);
    }

    private void UnParent()
    {
        _pos1.transform.SetParent(transform);
        _pos2.transform.SetParent(transform);
        _pos3.transform.SetParent(transform);
        _pos4.transform.SetParent(transform);
        _pos5.transform.SetParent(transform);
        _pos6.transform.SetParent(transform);
        _pos7.transform.SetParent(transform);
        _pos8.transform.SetParent(transform);
    }

}

public enum AxisList
{
    Y,
    Z,
    X
}