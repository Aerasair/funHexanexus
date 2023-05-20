using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tile))]
public class TileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Tile tile = (Tile)target;

        if (GUILayout.Button("Win"))
        {
            EditorUtility.SetDirty(tile);
            tile.SetWinMat();
        }
        if (GUILayout.Button("Ok"))
        {
            EditorUtility.SetDirty(tile);
            tile.SetNormalMat();
        }
    }


   
}
