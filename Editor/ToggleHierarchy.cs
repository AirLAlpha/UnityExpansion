using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class ToggleHierarchy
{
    //  Toggle�̉���
    private const int WIDTH = 16;

    static ToggleHierarchy()
    {
        //  �q�G�����L�[�̊e�A�C�e���̃f���Q�[�g�Ɋ֐���o�^
        EditorApplication.hierarchyWindowItemOnGUI += ToggleObject;
    }

    private static void ToggleObject(int instanceID, Rect objRect)
    {
        //  instanceID �̃I�u�W�F�N�g���擾���Ă��āAGameObject�^�ɃL���X�g
        GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (obj == null) return;

        //  ���W�̎擾
        Rect rectPos = objRect;

        //  Toggle��\������ʒu���w��
        rectPos.x = rectPos.xMax;
        rectPos.width = WIDTH;

        //  Toggle��\�����āA��Ԃ��擾
        var newActive = GUI.Toggle(rectPos, obj.activeSelf, string.Empty);

        //  Toggle���I�u�W�F�N�g�̃A�N�e�B�u�Ɠ����Ȃ珈������߂�
        if (newActive == obj.activeSelf) return;

        //  �I�u�W�F�N�g�̃A�N�e�B�u��Toggle��K��
        obj.SetActive(newActive);

        //  �V�[���̕ۑ��t���O�𗧂Ă�
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
