using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class ToggleHierarchy
{
    //  Toggleの横幅
    private const int WIDTH = 16;

    static ToggleHierarchy()
    {
        //  ヒエラルキーの各アイテムのデリゲートに関数を登録
        EditorApplication.hierarchyWindowItemOnGUI += ToggleObject;
    }

    private static void ToggleObject(int instanceID, Rect objRect)
    {
        //  instanceID のオブジェクトを取得してきて、GameObject型にキャスト
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj == null) return;

        //  座標の取得
        Rect rectPos = objRect;

        //  Toggleを表示する位置を指定
        rectPos.x = rectPos.xMax;
        rectPos.width = WIDTH;

        //  Toggleを表示して、状態を取得
        var newActive = GUI.Toggle(rectPos, obj.activeSelf, string.Empty);

        //  Toggleがオブジェクトのアクティブと同じなら処理をやめる
        if (newActive == obj.activeSelf) return;

        //  オブジェクトのアクティブにToggleを適応
        obj.SetActive(newActive);

        //  シーンの保存フラグを立てる
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
