using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    public float strength = 0.2f;
    public float speed = 1.0f;

    private Vector3 initialPosition;
    private float time = 0.0f;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        float yPos = Mathf.Lerp(initialPosition.y - strength, initialPosition.y + strength, Mathf.PingPong(time, 1));
        transform.position = new Vector3(initialPosition.x, yPos, initialPosition.z);
    }
}
