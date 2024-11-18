using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

public class ShowIfAttribute : PropertyAttribute
{
    public string ConditionalField;
    public DialogMessageType RequiredState;

    public ShowIfAttribute(string _conditionalField,DialogMessageType _requiredType)
    {
        ConditionalField = _conditionalField;
        RequiredState = _requiredType;
    }
}
