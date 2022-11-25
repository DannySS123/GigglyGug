using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public float length = 10f;
    public float speed = 2f;
    private float startPosX;
    private float alpha;
    private float startPosY;
    public int direction = -1;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        alpha = transform.rotation.z;
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (crossedTheBoundary()) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            direction *= -1;
        }
        
        transform.position += new Vector3(direction * speed * Time.deltaTime * (float)Math.Cos(alpha), (alpha<180 ? -1:1) * direction * speed * Time.deltaTime * (float)Math.Sin(alpha), 0);
    }

    bool crossedTheBoundary(){
        if(startPosX < transform.position.x) return true;
         return length < Math.Sqrt(Math.Pow(transform.position.x-startPosX, 2) + Math.Pow(transform.position.y-startPosY, 2));
    }
}
