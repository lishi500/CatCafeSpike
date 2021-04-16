using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFollow : MonoBehaviour
{
    GameObject textObj;
    TextMeshPro textMesh;

    public void SetText(string text) {
        textMesh.text = text;
    }

    private void Awake() {
        GameObject textPrefab = CommonUtil.Instance.GetPrefabByName("TextMesh");
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        float height = sprite.bounds.extents.y;
        Vector3 textPos = new Vector3(transform.position.x, transform.position.y + height + 0.25f, 0);
        textObj = Instantiate(textPrefab, textPos, Quaternion.identity);
        textObj.transform.SetParent(transform);
        textMesh = textObj.GetComponent<TextMeshPro>();
        SetText(gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
