using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, transform.position+(new Vector3(0, Mathf.Sin(Time.fixedTime), 0)), .01f);
    }
}
