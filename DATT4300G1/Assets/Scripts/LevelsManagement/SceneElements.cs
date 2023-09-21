using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElements : MonoBehaviour
{
    private Vector3 originalLoaction;
    public bool MoveIn = false;
    public bool MoveOut = false;
    public Transform destination;
    public float moveSpeed = 5.0f; // Adjust this speed as needed.
    public bool isMovingIn = false;
    public bool isMovingOut = false;
    public bool RotateIn = false;
    public bool RotateOut = false;
    public GameObject pivot;
    private Vector3 pivotTransform;
    public float rotationTime = 2f;
    private bool rotating = false;


    void Start()
    {
        originalLoaction = (Vector3)this.transform.position;
        if(pivot != null){
            pivotTransform = pivot.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveIn ){
            isMovingIn = true;
            FadeIn();
        }
        if(MoveOut){
            isMovingOut = true;
            FadeOut();
        }
        if(RotateIn && !rotating){
            RotateIn = false;
            StartCoroutine(Rotate(this.transform, pivotTransform, Vector3.right, -90, rotationTime));
        }
        if(RotateOut && !rotating){
            RotateOut = false;
            StartCoroutine(Rotate(this.transform, pivotTransform, Vector3.right, 90, rotationTime));
        }
    }

    private void FadeIn()
    {
        if (isMovingIn)
        {
            // Calculate the direction to the destination.
            Vector3 direction = (destination.position - transform.position).normalized;

            // Calculate the distance to the destination.
            float distance = Vector3.Distance(transform.position, destination.position);

            if (distance > 0.1f)
            {
                // Move the object towards the destination.
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
            else
            {
                // The object has reached the destination, stop moving.
                isMovingIn = false;
                MoveIn = false;
            }
        }
    }

    private void FadeOut()
    {
        if (isMovingOut)
        {
            // Calculate the direction to the destination.
            Vector3 direction = (originalLoaction - transform.position).normalized;

            // Calculate the distance to the destination.
            float distance = Vector3.Distance(transform.position, originalLoaction);

            if (distance > 0.1f)
            {
                // Move the object towards the destination.
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
            else
            {
                // The object has reached the destination, stop moving.
                isMovingOut = false;
                MoveOut = false;
            }
        }
    }

    private IEnumerator Rotate(Transform Transform, Vector3 targetTransform, Vector3 rotateAxis, float degrees, float totalTime)
    {
        if (rotating)
            yield return null;
        rotating = true;
 
        Quaternion startRotation = Transform.rotation;
        Vector3 startPosition = Transform.position;

        // Get end position;
        transform.RotateAround(targetTransform, rotateAxis, degrees);

        Quaternion endRotation = Transform.rotation;
        Vector3 endPosition = Transform.position;

        Transform.rotation = startRotation;
        Transform.position = startPosition;
 
        float rate = degrees / totalTime;
        //Start Rotate
        for (float i = 0.0f; Mathf.Abs(i) < Mathf.Abs(degrees); i += Time.deltaTime * rate)
        {
            Transform.RotateAround(targetTransform, rotateAxis, Time.deltaTime * rate);
            yield return null;
        }
        Transform.rotation = endRotation;
        Transform.position = endPosition;
        rotating = false;
    }
}
