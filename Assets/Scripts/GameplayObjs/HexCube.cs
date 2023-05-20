using UnityEngine;
using UnityEditor;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;

public class HexCube : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private PosCube _pos1, _pos2, _pos3, _pos4;
    [SerializeField] private Selecter _s1, _s2, _s3, _s4, _s5, _s6, _s7, _s8;
    [SerializeField] private float _rTime = 0.5f;
    private AxisList _axis;

    private Tween _tween;

    [HideInInspector] public UnityEvent IsRotationFinished;

    private void Start()
    {
        StartCoroutine(DelayStart());
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(0.5f);
        SelectTop();
    }


    public void rotateSelected(int degrees)
    {
        switch (_axis)
        {
            case (AxisList.X):
                {
                    _tween =  _parent.transform.DORotate(new Vector2(degrees, 0), _rTime, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetRelative(true).OnComplete(() => DropEvent());
                    break;
                }
            case (AxisList.Y):
                {
                    _tween = _parent.transform.DORotate(new Vector3(0, degrees, 0), _rTime).SetEase(Ease.Linear).SetRelative(true).OnComplete(() => DropEvent());
                    break;
                }
            case (AxisList.Z):
                {
                    _tween = _parent.transform.DORotate(new Vector3(0, 0, degrees), _rTime).SetEase(Ease.Linear).SetRelative(true).OnComplete(() => DropEvent());
                    break;
                }
        }
    }

    private void DropEvent()
    {
        _tween?.Kill();
        IsRotationFinished?.Invoke();
    }

    public void SelectTop()
    {
        UnParent();

        _pos1 = _s1.GetItem(1);
        _pos2 = _s1.GetItem(2);
        _pos3 = _s2.GetItem(1);
        _pos4 = _s2.GetItem(2);

        SetSelectCubes();
        _axis = AxisList.Y;
    }

    public void SelectBot()
    {
        UnParent();
        _pos1 = _s3.GetItem(1);
        _pos2 = _s3.GetItem(2);
        _pos3 = _s4.GetItem(1);
        _pos4 = _s4.GetItem(2);

        SetSelectCubes();
        _axis = AxisList.Y;
    }

    public void SelectLeftLeft()
    {
        UnParent();
        _pos1 = _s1.GetItem(1);
        _pos2 = _s1.GetItem(2);
        _pos3 = _s3.GetItem(1);
        _pos4 = _s3.GetItem(2);

        SetSelectCubes();
        _axis = AxisList.Z;
    }

    public void SelectLeftRight()
    {
        UnParent();
        _pos1 = _s2.GetItem(1);
        _pos2 = _s2.GetItem(2);
        _pos3 = _s4.GetItem(1);
        _pos4 = _s4.GetItem(2);
        SetSelectCubes();
        _axis = AxisList.Z;
    }


    public void SelectRightLeft()
    {
        UnParent();
        _pos1 = _s5.GetItem(1);
        _pos2 = _s5.GetItem(2);
        _pos3 = _s7.GetItem(1);
        _pos4 = _s7.GetItem(2);
        SetSelectCubes();
        _axis = AxisList.X;
    }

    public void SelectRightRight()
    {
        UnParent();
        _pos1 = _s6.GetItem(1);
        _pos2 = _s6.GetItem(2);
        _pos3 = _s8.GetItem(1);
        _pos4 = _s8.GetItem(2);
        SetSelectCubes();
        _axis = AxisList.X;
    }

    private void SetSelectCubes()
    {
        ClearPrevState();
        _pos1.transform.SetParent(_parent); 
        _pos2.transform.SetParent(_parent);
        _pos3.transform.SetParent(_parent);
        _pos4.transform.SetParent(_parent);

        _pos1.SetMatSelected();
        _pos2.SetMatSelected();
        _pos3.SetMatSelected();
        _pos4.SetMatSelected();
    }

    private void UnParent()
    {
        if (_pos1 == null) return;
        _pos1.SetMatDef();
        _pos2.SetMatDef();
        _pos3.SetMatDef();
        _pos4.SetMatDef();
        _pos1.transform.SetParent(transform);
        _pos2.transform.SetParent(transform);
        _pos3.transform.SetParent(transform);
        _pos4.transform.SetParent(transform);
    }

    private void ClearPrevState()
    {
        _parent.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void OnDestroy()
    {
    }

}

public enum AxisList
{
    Y,
    Z,
    X
}