using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour {
    public Transform target;
    public float speed;
    public float nextWayPointDistance;

    public float checkDistance;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    private bool invoking = true;
    // Start is called before the first frame update
    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        InvokeRepeating("updatePath", 0f, 0.5f);
    }

    void updatePath() {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, onPathComplete);
    }

    void Update() {
        if(getDistanceFromTarget() > checkDistance && invoking) {
            CancelInvoke();
            invoking = false;
        } else if(!invoking && getDistanceFromTarget() < checkDistance) {
            InvokeRepeating("updatePath", 0f, 0.5f);
            invoking = true;
        }
    }

    float getDistanceFromTarget() {
        return Mathf.Sqrt(Mathf.Pow(target.position.x - rb.position.x,2) + Mathf.Pow(target.position.y - rb.position.y,2));
    }

    void onPathComplete(Path p) {
        if(!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate() {
        if(path == null || currentWaypoint >= path.vectorPath.Count) return;
        moveMonster();

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWayPointDistance) currentWaypoint++;
    }

    void moveMonster() {
        if(invoking) {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;
            rb.AddForce(force);
        }
    }
}
