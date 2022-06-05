using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour
{
    private Animator animator;

    public Slider heath;
    public int damage;
    
    public float moveSpeed;
    // object nào có thể bị tác động vật lý thì dùng rigi
    
    public LayerMask enemyLayer;
    public Transform attackPoint;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += moveSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= moveSpeed;
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            animator.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isJump", true);
        }

        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isAttack", true);
            attack();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("isWalk", false);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("isJump", false);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isAttack", false);
        }
    }

    void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.position, 1f,enemyLayer);
        Debug.Log(enemy.Length);
        foreach (Collider2D e in enemy)
        {
            Debug.Log("attack 123");
            e.GetComponent<Enemy>().hit(200);
        }
    }
}