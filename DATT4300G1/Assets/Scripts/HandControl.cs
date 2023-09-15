using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    [Header("Speed Setting")]
    public float moveSpeed = 5f;
    public float runAcceleration = 1f;
    public float runDecceleration = 2f;
    public float runMaxSpeed = 5f;
    [HideInInspector]
    private float runAccelAmount;
    [HideInInspector]
    private float runDeccelAmount;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxisRaw("Vertical") * moveSpeed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        Debug.Log(verticalMove);
        Debug.Log(horizontalMove);
    }

    void FixedUpdate()
    {
        MoveV(verticalMove);
        MoveH(horizontalMove);
    }

    public void MoveV(float speed)
    {
        float targetSpeed = speed;
        float accelRate = 0f;
        runAccelAmount = (50 * runAcceleration) / runMaxSpeed;
        runDeccelAmount = (50 * runDecceleration) / runMaxSpeed;

        accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccelAmount : runDeccelAmount;

        float speedDif = targetSpeed - m_Rigidbody2D.velocity.y;

        float movement = speedDif * accelRate;

        m_Rigidbody2D.AddForce(movement * Vector2.up, ForceMode2D.Force);
    }

    public void MoveH(float speed)
    {
        float targetSpeed = speed;
        float accelRate = 0f;
        runAccelAmount = (50 * runAcceleration) / runMaxSpeed;
        runDeccelAmount = (50 * runDecceleration) / runMaxSpeed;

        accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? runAccelAmount : runDeccelAmount;

        float speedDif = targetSpeed - m_Rigidbody2D.velocity.x;

        float movement = speedDif * accelRate;

        m_Rigidbody2D.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    public void SetSpeedSetting(float moveS, float accelS, float deccelS){
        this.moveSpeed = moveS;
        this.runAcceleration = accelS;
        this.runDecceleration = deccelS;
    }
}
