using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//Basicamente esses tipode scripts servem para editar em tempo real sem a necessidade de abrir  o jogo
[CustomEditor(typeof(MapGeneration))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapGeneration map = target as MapGeneration;

        map.GenerateMap();

        if (GUILayout.Button("Generate Map"))
        {
            map.GenerateMap();
        }
    }
}
