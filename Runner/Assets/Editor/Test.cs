using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Test : EditorWindow
{
    [SerializeField] TreeViewState m_TreeViewState;
    Test m_SimpleTreeView;

    void OnEnable()
    {
        // Check whether there is already a serialized view state (state 
        // that survived assembly reloading)
        if (m_TreeViewState == null)
            m_TreeViewState = new TreeViewState();

   //     m_SimpleTreeView = new SimpleTreeView(m_TreeViewState);
    }
}
