using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class AlternatelyChangeColorHierarchy
{
    private const int ROW_HEIGHT = 16;  //  ��s���̑傫��
    private const int OFFSET_Y = -4;

    //  �F
    private static readonly Color COLOR = new Color(50, 50, 50, 0.05f);

    static AlternatelyChangeColorHierarchy()
    {
        //  �q�G�����L�[�̊e�A�C�e���̃f���Q�[�g�Ɋ֐���o�^
        EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
    }

    private static void OnGUI(int instanceID, Rect rect)
    {
        //  �S�̂̑傫������s���Ŋ����āA���ꂼ��̃C���f�b�N�X���v�Z
        var index = (int)(rect.y + OFFSET_Y) / ROW_HEIGHT;

        //  �����s�͏��������Ȃ�
        if (index % 2 == 0) return;

        //  �����̎擾
        var xMax = rect.xMax;

        //  ���W�̌v�Z
        rect.x = 32;
        rect.xMax = xMax + 16;

        //  �F�̓K��
        EditorGUI.DrawRect(rect, COLOR);
    }
}