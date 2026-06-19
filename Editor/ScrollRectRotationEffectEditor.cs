using UnityEditor;

namespace LLib.Editor
{
    [CustomEditor(typeof(ScrollRectRotationEffect))]
    public class ScrollRectRotationEffectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            EditorGUI.EndDisabledGroup();
            
            SerializedProperty iterator = serializedObject.GetIterator();
            bool enterChildren = true;
            while (iterator.NextVisible(enterChildren))
            {
                enterChildren = false;
                
                if (iterator.name == "m_Script") 
                    continue;
                
                if (iterator.name == "_axis")
                {
                    var useMirror = serializedObject.FindProperty("_useMirror");
                    if (useMirror.boolValue)
                    {
                        EditorGUILayout.PropertyField(iterator);
                        EditorGUILayout.HelpBox("Mirror effects may behave unpredictably in radial or grid layouts.", MessageType.Info);
                    }
                }
                else
                {
                    EditorGUILayout.PropertyField(iterator);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

