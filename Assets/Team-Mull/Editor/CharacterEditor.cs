using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterAltasSO))]
public class CharacterEditor : Editor
{
    private SerializedProperty characterProperty;

    private void OnEnable()
    {
        characterProperty = serializedObject.FindProperty("Characters");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(characterProperty,
            new GUIContent("Characters"), true);

        if(GUILayout.Button("Add Character"))
        {
            GenericMenu menu = new GenericMenu();
            foreach(CharacterDataSO character in Resources.LoadAll<CharacterDataSO>(""))
            {
                menu.AddItem(new GUIContent(character.Data.CharacterName)
                    , false, () => AddCharacter(character));
            }

            menu.ShowAsContext();
        }
    }

    private void AddCharacter(CharacterDataSO character)
    {
        int newIndex = characterProperty.arraySize;
        characterProperty.InsertArrayElementAtIndex(newIndex);
        characterProperty.GetFixedBufferElementAtIndex(newIndex).objectReferenceValue = character;
    }
}
