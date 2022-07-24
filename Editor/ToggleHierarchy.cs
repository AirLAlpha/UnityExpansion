using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class ToggleHierarchy
{
    private const int WIDTH = 16;

    static ToggleHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += Toggle;
    }

    private static void Toggle(int instanceID, Rect selectionRect)
    {
        //  instanceID のオブジェクトを取得してきて、GameObject型にキャスト
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (gameObject == null) return;

        //  座標の取得
        Rect position = selectionRect;

        //  
        position.x = position.xMax;
        position.width = WIDTH;

        //  
        var newActive = GUI.Toggle(position, gameObject.activeSelf, string.Empty);

        if (newActive == gameObject.activeSelf) return;

        gameObject.SetActive(newActive);

        //  シーンの保存フラグを立てる
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
