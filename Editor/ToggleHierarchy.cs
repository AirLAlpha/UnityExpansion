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
        //  instanceID �̃I�u�W�F�N�g���擾���Ă��āAGameObject�^�ɃL���X�g
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (gameObject == null) return;

        //  ���W�̎擾
        Rect position = selectionRect;

        //  
        position.x = position.xMax;
        position.width = WIDTH;

        //  
        var newActive = GUI.Toggle(position, gameObject.activeSelf, string.Empty);

        if (newActive == gameObject.activeSelf) return;

        gameObject.SetActive(newActive);

        //  �V�[���̕ۑ��t���O�𗧂Ă�
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
