using UnityEngine;
using UnityEditor;

[System.Serializable]
public class LevelLoadingAction
{
    public string actionName;
    public GameObject targetObject;
    public string methodName;
}

public class LevelLoadingActions : MonoBehaviour
{
    public LevelLoadingAction[] loadingActions;

    // Use this method to execute loading actions
    public void ExecuteLoadingActions()
    {
        foreach (var action in loadingActions)
        {
            if (action.targetObject != null)
            {
                action.targetObject.SendMessage(action.methodName, SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                Debug.LogWarning($"LevelLoadingAction {action.actionName} has no target object specified.");
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(LevelLoadingActions))]
public class LevelLoadingActionsEditor : Editor
{
    SerializedProperty loadingActions;

    void OnEnable()
    {
        loadingActions = serializedObject.FindProperty("loadingActions");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(loadingActions, true);

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
