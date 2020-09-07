using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private int spd;//modifier so for the ball
    [SerializeField]private float jumpVal;
    //[SerializeField] private float lmt = 5; //speed limit 
    private Rigidbody rb;
    private int score;
    private int jumps;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI jumpText;
    public GameObject winTextObject;
    private float x;
    private float y; //direction on which force is applied
   // private Vector3 moving;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        jumps = 0;
        SetScoreText();
        SetJumpText();
        winTextObject.SetActive(false);
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
    void OnJump()
    {
        jumps+=1;
        SetJumpText();
        //Debug.Log("lovely day no?");
        Vector3 jmp = new Vector3(x, jumpVal, y);
        rb.AddForce(jmp);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            SetScoreText();
        }
    }
    private void SetJumpText()
    {
        jumpText.text = "jumps: " + jumps.ToString();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

        if(score >= 16)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }
}
