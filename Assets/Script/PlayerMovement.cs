using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    Vector2 moveDirection;
    bool isLightOpen;
    public Light2D torchLight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        torchLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        TorchLightChange();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    void TorchLightChange()
    {
        if (isLightOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                torchLight.gameObject.SetActive(false);
                isLightOpen = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                torchLight.gameObject.SetActive(true);
                isLightOpen = true;
            }
        }
    }
}
