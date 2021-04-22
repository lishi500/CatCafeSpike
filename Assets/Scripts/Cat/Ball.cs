using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : CatToy {
    public float moveTime = 3f;
    private float rotatedirection = 1;
    private float pushDistance = 3f;


    public override void PlayBy(Cat cat) {
        KnockBy(cat.transform.position);
    }

    private void KnockBy(Vector3 fromPos) {
        Vector3 heading = transform.position - fromPos;
        Vector3 direction = heading / heading.magnitude;

        Vector3 nextVector = direction * pushDistance;
        Vector3 targetPosition = transform.position + nextVector;
        KnockBall(targetPosition);
    }

    private void KnockBall(Vector3 targetPosition) {
        if (targetPosition.x > transform.position.x) {
            // go right
            rotatedirection = -1;
        } else {
            // go left
            rotatedirection = 1;
        }

        StartCoroutine(Spin());
        StartCoroutine(Move(targetPosition));
    }

    IEnumerator Spin() {
        Vector3 startRotate = transform.rotation.eulerAngles;
        float targetRotateAngle = 1200f; 
        float elapsedTime = 0f;
        bool isReached = false;

        while (!isReached) {
            if (elapsedTime >= moveTime) {
                isReached = true;
            }
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp(elapsedTime / moveTime, 0f, 1f);
            t = CommonUtil.Instance.EaseOut(t);

            float extraAngle = Mathf.Lerp(0, targetRotateAngle, t);
            Vector3 nextRotate = new Vector3(startRotate.x, startRotate.y, startRotate.z + (extraAngle * rotatedirection));
            transform.rotation = Quaternion.Euler(nextRotate);

            yield return null;
        }
    }

    IEnumerator Move(Vector3 targetPosition) {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        bool isReached = false;

        while (!isReached) {
            if (elapsedTime >= moveTime) {
                isReached = true;
            }
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp(elapsedTime / moveTime, 0f, 1f);
            t = CommonUtil.Instance.EaseOut(t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

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
