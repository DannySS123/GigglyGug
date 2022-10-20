using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public float lentght = 10f;
    public float speed = 2f;
    private float startPosX;
    public int direction = -1;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startPosX - lentght > transform.position.x || startPosX < transform.position.x) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            direction *= -1;
        }
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }
}
