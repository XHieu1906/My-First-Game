using System.Collections;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public float bulletSpeed;
    private Vector2 direction;
    private bool hit;
    private Animator anim;
    private CapsuleCollider2D capCollider;
    private Rigidbody2D rb;
    private float lifetime;
    public int damage = 20;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capCollider = GetComponent<CapsuleCollider2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void FixedUpdate(){
        if (hit) return;
        rb.velocity = direction * bulletSpeed;
        lifetime += Time.deltaTime;
        if (lifetime > 10) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Wall")){
            Explode();
        }
        else if (collision.CompareTag("Enemy")){
            EnemyChasing enemy = collision.GetComponent<EnemyChasing>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage); 
            }
            Explode();
        }
    }
    public void Explode(){
        hit = true; 
        capCollider.enabled = false; 
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Explode"); 

        Invoke("Deactivate", 0.5f);
    }

    public void SetDirection(Vector2 _direction){
        lifetime = 0;
        direction = _direction.normalized;
        gameObject.SetActive(true);
        hit = false;
        capCollider.enabled = true;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        
        float localScaleX = Mathf.Abs(transform.localScale.x);
        if (direction.x < 0) {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
