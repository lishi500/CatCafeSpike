using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameFollow : MonoBehaviour
{
    public Vector3 pos;

    public GameObject obj;
    public Camera camera;
    private Vector3 objPos;
    private RectTransform rt;
    private RectTransform canvasRT;
    private Vector3 objScreenPos;

    // Use this for initialization
    void Start() {
        objPos = obj.transform.position;

        rt = GetComponent<RectTransform>();
        canvasRT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        objScreenPos = camera.WorldToViewportPoint(obj.transform.TransformPoint(objPos));
        //rt.anchorMax = objScreenPos;
        //rt.anchorMin = objScreenPos;
        Vector2 WorldObject_ScreenPosition = new Vector2(
         ((objScreenPos.x * canvasRT.sizeDelta.x) - (canvasRT.sizeDelta.x * 0.5f)),
         ((objScreenPos.y * canvasRT.sizeDelta.y) - (canvasRT.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        rt.anchoredPosition = WorldObject_ScreenPosition;
    }

    // Update is called once per frame
    void Update() {
        //objScreenPos = camera.WorldToViewportPoint(obj.transform.TransformPoint(objPos));
        //rt.anchorMax = objScreenPos;
        //rt.anchorMin = objScreenPos;

        Vector2 pos = obj.transform.position;  // get the game object position
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);  //convert game object position to VievportPoint

        // set MIN and MAX Anchor values(positions) to the same position (ViewportPoint)
        rt.anchorMin = viewportPoint;
        rt.anchorMax = viewportPoint;
    }
}