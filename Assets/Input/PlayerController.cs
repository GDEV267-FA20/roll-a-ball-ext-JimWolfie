using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private int spd; //modifier so for the ball
    //[SerializeField] private float lmt = 5; //speed limit 
    private Rigidbody rb;
    private float x;
    private float y; //direction on which force is applied
   // private Vector3 moving;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    void FixedUpdate()
    {
        Vector3 move = new Vector3(x, 0.0f, y);
        //moving += move;
        rb.AddForce(move *spd *Time.fixedDeltaTime);

    }
    void OnMove(InputValue movementVal)
    {
        Vector2 movementVec = movementVal.Get<Vector2>();
        x = movementVec.x;
        y = movementVec.y;
    }
}
