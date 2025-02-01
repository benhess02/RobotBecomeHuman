using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8;
    Vector2 movement;
    InputAction moveAction;
    Rigidbody2D rb;

    public KeyCode dashKey;
    public int dashSpeed = 25;
    public float dashDuration = 10;
    public int dashCooldown = 500;
    float currentDashTime;
    int dashDowntime = 500;

    // Start is called before the first frame update
    void Start()
    {
        currentDashTime = dashDuration;
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool dashReady = (movement != Vector2.zero) && (dashDowntime == dashCooldown);

        if (Input.GetKeyDown(dashKey) && dashReady) {
            currentDashTime = 0.0f;
            dashDowntime = 0;
        }

        if (currentDashTime < dashDuration) {
            currentDashTime += 0.1f;
            rb.velocity = movement * dashSpeed;
        } else {
            movement = moveAction.ReadValue<Vector2>();
            rb.velocity = movement * speed;
        }

        if (dashDowntime < dashCooldown)
            dashDowntime++;
    }
}
