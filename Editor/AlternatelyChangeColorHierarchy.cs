using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class AlternatelyChangeColorHierarchy
{
    private const int ROW_HEIGHT = 16;  //  一行分の大きさ
    private const int OFFSET_Y = -4;

    //  色
    private static readonly Color COLOR = new Color(50, 50, 50, 0.05f);

    static AlternatelyChangeColorHierarchy()
    {
        //  ヒエラルキーの各アイテムのデリゲートに関数を登録
        EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
    }

    private static void OnGUI(int instanceID, Rect rect)
    {
        //  全体の大きさを一行分で割って、それぞれのインデックスを計算
        var index = (int)(rect.y + OFFSET_Y) / ROW_HEIGHT;

        //  偶数行は処理をしない
        if (index % 2 == 0) return;

        //  横幅の取得
        var xMax = rect.xMax;

        //  座標の計算
        rect.x = 32;
        rect.xMax = xMax + 16;

        //  色の適応
        EditorGUI.DrawRect(rect, COLOR);
    }
}