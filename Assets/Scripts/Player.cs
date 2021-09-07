using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ThingPrefab;
    Rigidbody playerBody;
    Vector3 velocity;
    private float speed = 10;
    
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move();

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        velocity = input.normalized * speed;
    }

    void FixedUpdate()
    {
        playerBody.position += velocity * Time.deltaTime;
    }

    // OG move for non-rigid body
    // void Move()
    // {
    //     Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    //     Vector3 direction = input.normalized;
    //     Vector3 velocity = direction * speed;
    //     Vector3 moveAmount = velocity * Time.deltaTime;

    //     // transform.position += moveAmount;
    //     transform.Translate(moveAmount);
    // }

    void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "Coin")
        {
            Destroy(triggerCollider.gameObject);
            Instantiate(ThingPrefab, new Vector3(-15, 10, 0), Quaternion.identity);
        }
    }
}
