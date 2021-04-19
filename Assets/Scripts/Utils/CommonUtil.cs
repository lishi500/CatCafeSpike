using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonUtil : Singleton<CommonUtil>
{

    public float Flip(float x) {
        return 1 - x;
    }

    private float Square(float x) {
        return x * x;
    }
    public float EaseOut(float t) {
        return Flip(Square(Flip(t)));
    }

    // ease in and out
    public float Smoothstep(float t) {
        return t * t * (3 - 2 * t);
    }

    public GameObject GetPrefabByName(string name) {
        return (GameObject) Resources.Load("Prefabs/" + name);
        
    }
}
