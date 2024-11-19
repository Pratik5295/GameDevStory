using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
     
        ShowIfAttribute attribute = (ShowIfAttribute)this.attribute;

        SerializedProperty conditionProperty = 
            property.serializedObject.FindProperty(attribute.ConditionalField);

        // Conditional check

        if (conditionProperty != null && conditionProperty.enumValueIndex == (int)attribute.RequiredState)
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
