using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Vector2 movement;
    InputAction moveAction;
    Rigidbody2D rb;

    public KeyCode dashKey;
    public float maxDashTime = 10f;
    public float currentDashTime;

    // Start is called before the first frame update
    void Start()
    {
        currentDashTime = maxDashTime;
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(dashKey) && movement != Vector2.zero)
            currentDashTime = 0.0f;
        
        if (currentDashTime < maxDashTime) {
            currentDashTime += 0.1f;
            speed = 30;
        } else {
            movement = moveAction.ReadValue<Vector2>();
            speed = 8;
        }

        rb.velocity = movement * speed;
    }

    private void Dash() {
        
    }
}
