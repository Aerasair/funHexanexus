using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tile))]
public class TileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Tile tile = (Tile)target;
        if(GUILayout.Button("Set Win"))
        {
            tile.SetWinMat();
        }  
        if(GUILayout.Button("Set Ok"))
        {
            tile.SetNormalMat();
        }
    }
}
