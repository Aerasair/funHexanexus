using UnityEngine;

public class PosCube : MonoBehaviour
{
    [SerializeField] private Material _matDef;
    [SerializeField] private Material _selectedMat;

    private Renderer _render;

    public void OnEnable()
    {
        _render = GetComponent<Renderer>();
    }

    public void SetMatDef()
    {
        _render.sharedMaterial = _matDef;
    }
    public void SetMatSelected()
    {
        _render.sharedMaterial = _selectedMat;
    }


}