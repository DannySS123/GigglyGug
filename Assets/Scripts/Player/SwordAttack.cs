using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject sword;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackTime = 0.5f;
    public LayerMask enemyLayers;
    private bool canAttack = true;

    public bool isSwordPickedUp = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack && isSwordPickedUp) {
            Attack();
        }
    }

    void Attack() {
        canAttack = false;
        sword.SetActive(true);
        animator.SetTrigger("SwordAttack");

        Invoke("DisableSword", 0.3f);
        Invoke("AllowAttack", attackTime);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("HIT");
            Destroy(enemy.gameObject);
        }
    }

    void DisableSword() {
        sword.SetActive(false);
    }

    void AllowAttack() {
        canAttack = true;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
