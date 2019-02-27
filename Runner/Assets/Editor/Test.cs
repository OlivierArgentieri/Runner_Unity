using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Jump))][SerializeField]
public class NewBehaviourScript : Editor
{
    private int defautl_index;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var m_tags = UnityEditorInternal.InternalEditorUtility.tags;
        ((Jump)target).m_tags = m_tags;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Tags");
        
        ((Jump)target).m_tag_index = EditorGUILayout.IntField(EditorGUILayout.Popup(((Jump)target).m_tag_index, m_tags));


        GUILayout.EndHorizontal();
    }
}
