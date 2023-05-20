using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tile))]
public class TileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UpdateMat();
    }


    private void UpdateMat()
    {
        Tile tile = (Tile)target;
        EditorUtility.SetDirty(tile);
        if (tile.IsWinTile)
        {
            tile.SetWinMat();
        }
        else
        {
            tile.SetNormalMat();
        }
    }
}
