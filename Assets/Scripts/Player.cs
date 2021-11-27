using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask collectibleLayer;
    [SerializeField] LayerMask deathPlaneLayer;
    CoinCounter coinCounter;
    Rigidbody rb;
    float movementInput;
    bool jumpKeyPressed;
    int jumpsUsed;

    // Start is called before the first frame update
    void Start()
    {
        var ccObj = GameObject.Find("Coin Counter");
        coinCounter = ccObj.GetComponent<CoinCounter>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }

        movementInput = Input.GetAxis("Vertical");
    }

    // FixedUpdate is called once every Physics Update, independent of the frame rate
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (jumpKeyPressed)
        {
            if (jumpsUsed < 2)
            {
                rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
                jumpsUsed++;
            }
            jumpKeyPressed = false;
        }

        rb.velocity = new Vector3(movementInput * 1.5f, rb.velocity.y, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpsUsed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((int)Math.Pow(2, other.gameObject.layer) == collectibleLayer.value)
        {
            coinCounter.IncrementCounter();
            Destroy(other.gameObject);
        }

        if ((int)Math.Pow(2, other.gameObject.layer) == deathPlaneLayer.value)
        {
            transform.position = new Vector3(0, 1.725f, 0);
        }
    }
}
