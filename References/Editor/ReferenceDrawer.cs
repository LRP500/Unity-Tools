using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using Tools.Variables;
using UnityEditor;
using UnityEngine;

namespace Tools.References.Editor
{
    //[OdinDontRegister]
    public class ReferenceDrawer<TReference, TVariable, TValue> : OdinValueDrawer<TReference>
        where TReference : Reference<TValue, TVariable>
        where TVariable : Variable<TValue>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var value = ValueEntry.SmartValue;

            GUILayout.BeginVertical();
            var btnRect = GUIHelper.GetCurrentLayoutRect();
            btnRect.width = EditorGUIUtility.labelWidth;
            btnRect = btnRect.AlignRight(18);
            btnRect.y += 4;

            if (GUI.Button(btnRect, GUIContent.none, "PaneOptions"))
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("Use Constant"), value.useConstant, () => value.useConstant = true);
                menu.AddItem(new GUIContent("Use Variable"), !value.useConstant, () => value.useConstant = false);
                menu.ShowAsContext();
            }

            EditorGUIUtility.AddCursorRect(btnRect, MouseCursor.Arrow);

            if (value.useConstant)
            {
                ValueEntry.Property.Children["constant"].Draw(label);
            }
            else
            {
                ValueEntry.Property.Children["variable"].Draw(label);
            }

            GUILayout.EndVertical();
        }
    }
}
