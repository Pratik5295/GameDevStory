using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDialogueOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionText;

    public void SetOption(string _message)
    {
        optionText.text = _message;
    }
}
