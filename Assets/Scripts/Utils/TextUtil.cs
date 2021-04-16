using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUtil : Singleton<TextUtil>
{
    public void SetFollowText(GameObject obj, string text) {
        TextFollow textFollow = obj.GetComponent<TextFollow>();
        if (textFollow != null) {
            textFollow.SetText(text);
        }
    }
}
