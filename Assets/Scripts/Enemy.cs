using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    public Slider heath;

    private static Vector3 moveTarget;
    private static bool isDefaultPosition;
    
    void Start()
    {
        moveTarget = transform.position;
        isDefaultPosition = true;
        
        setMoveTarget();
    }

    void Update()
    {
        move();
    }

    void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, 3 * Time.deltaTime );
        
        if (Vector3.Distance(transform.position, moveTarget) < 0.001f)
        {
            setMoveTarget();
        }
    }
    
    void setMoveTarget()
    {
        if (isDefaultPosition)
        {
            moveTarget.x += 12;
            isDefaultPosition = false;
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            moveTarget.x -= 12;
            isDefaultPosition = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void heathCheck()
    {
        if (heath.value <= 0) {
            Destroy(gameObject);   
        }
    }
    
    public void hit(float heathValue)
    {
        heath.value -= heathValue;
        heathCheck();
    }
}
