using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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

    public bool hasLight = false;
    private Light2D light2D;
    public float startRadius = 1.0f;
    public float endRadius = 20.0f;
    public float animationDuration = 2.0f;
    private float startTime;
    private bool isAnimating = false;
    private bool forwardAnimation = false;
    public bool isWave = false;
    private FloatingAnimation fa;
    void Start()
    {
        originalLoaction = (Vector3)this.transform.position;
        if (pivot != null)
        {
            pivotTransform = pivot.transform.position;
        }
        if (hasLight)
        {
            light2D = this.gameObject.GetComponent<Light2D>();
        }
        if (isWave)
        {
            fa = this.gameObject.GetComponent<FloatingAnimation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveIn)
        {
            isMovingIn = true;
            if (hasLight && !isAnimating)
                StartAnimation();
            FadeIn();
        }
        if (MoveOut)
        {
            if (isWave)
                {
                    fa.enabled = false;
                }
            isMovingOut = true;
            if (hasLight && !isAnimating)
                StartAnimation();
            FadeOut();
        }
        if (RotateIn && !rotating)
        {
            RotateIn = false;
            StartCoroutine(Rotate(this.transform, pivotTransform, Vector3.right, -90, rotationTime));
        }
        if (RotateOut && !rotating)
        {
            RotateOut = false;
            StartCoroutine(Rotate(this.transform, pivotTransform, Vector3.right, 90, rotationTime));
        }
        if (isAnimating)
        {
            AnimateLight();
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
                if (isWave)
                {
                    fa.enabled = true;
                }
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

    private void StartAnimation()
    {
        startTime = Time.time;
        isAnimating = true;
        forwardAnimation = !forwardAnimation;
    }

    private void AnimateLight()
    {
        float elapsed = Time.time - startTime;
        float newRadius;
        if (elapsed <= animationDuration)
        {
            if (forwardAnimation)
            {
                newRadius = Mathf.Lerp(startRadius, endRadius, elapsed / animationDuration);
            }
            else
            {
                newRadius = Mathf.Lerp(endRadius, startRadius, elapsed / animationDuration);
            }
            light2D.pointLightOuterRadius = newRadius;
        }
        else
        {
            isAnimating = false;
        }
    }
}
