using UnityEngine;

[System.Serializable]
public struct CharData
{
    public string CharacterName;

    public string CharacterDesignation;

    public Sprite CharacterSprite;
}

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Characters/Create a New Character")]
public class CharacterDataSO : ScriptableObject
{
    public CharData Data;
}
