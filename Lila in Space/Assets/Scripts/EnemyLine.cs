using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLine : EnemyBase
{
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float shootTime = 1f;

    private float timeElapsedShootTime = 0f;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        calcuateNewMovementVector(Bounds.MaxX);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= boundsHighX)
        {
            calcuateNewMovementVector(Bounds.MaxX);
        }
        else if (transform.position.x <= boundsLowX)
        {
            calcuateNewMovementVector(Bounds.MinX);
        }
            
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
        
        timeElapsedShootTime += Time.deltaTime;
        if(timeElapsedShootTime > shootTime)
        {
            this.Shoot();
            timeElapsedShootTime = 0;
        }
    }

    void calcuateNewMovementVector(Bounds bounds)
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        if(bounds == Bounds.MaxX)
        {
            movementDirection = Vector2.left;
        }
        else
        {
            movementDirection = Vector2.right;
        }
        
        movementPerSecond = movementDirection * enemyVelocity;
    }

    void Shoot()
    {
        //EnemyProjectile projectile1 = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyProjectile>();
        //EnemyProjectile projectile2 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 90)).GetComponent<EnemyProjectile>();
        //EnemyProjectile projectile3 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 90)).GetComponent<EnemyProjectile>();
        EnemyProjectile projectile4 = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyProjectile>();
        //projectile1.Shoot(Vector2.up);
        //projectile2.Shoot(Vector2.left);
        //projectile3.Shoot(Vector2.right);
        projectile4.Shoot(Vector2.down);
    }
}