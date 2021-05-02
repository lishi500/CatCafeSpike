using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : CatToy {
    public float moveTime = 3f;
    const float DEFAULT_PUSH_DISTANCE = 3f;

    private bool isMoving = false;
    private float rotatedirection = 1;
    private Coroutine m_spinCorotine;
    private Coroutine m_moveCorotine;
    private int m_playBallID = 0;

    private Vector3 testTarget;

    public override void PlayBy(Cat cat) {
        PlayBy(cat, DEFAULT_PUSH_DISTANCE);
    }

    public void PlayBy(Cat cat, float pushDistance) {
        KnockBy(cat.transform.position, pushDistance);
    }

    public void KnockBy(Vector3 fromPos, float pushDistance) {
        m_playBallID++;
        if (isMoving) {
            interrupt();
        }
        Vector3 heading = transform.position - fromPos;
        Vector3 direction = heading / heading.magnitude;

        Vector3 nextVector = direction * pushDistance;
        Vector3 targetPosition = transform.position + nextVector;
        testTarget = targetPosition;
        KnockBall(targetPosition);
    }

    private void interrupt() {
        if (m_spinCorotine != null) { 
            StopCoroutine(m_spinCorotine);
        }
        if (m_moveCorotine != null) { 
            StopCoroutine(m_moveCorotine);
        }
        isMoving = false;
    }

    private void KnockBall(Vector3 targetPosition) {
        if (targetPosition.x > transform.position.x) {
            // go right
            rotatedirection = -1;
        } else {
            // go left
            rotatedirection = 1;
        }

        m_spinCorotine = StartCoroutine(Spin());
        m_moveCorotine = StartCoroutine(Move(targetPosition));
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
        isMoving = true;
        //Debug.Log("Play Ball: [" + m_playBallID + "] from " + startPosition + " To " + targetPosition);

        while (!isReached) {
            if (elapsedTime >= moveTime) {
                isReached = true;
                isMoving = false;
                //Debug.Log("Play Ball reched: [" + m_playBallID + "] " + " To " + testTarget);
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
