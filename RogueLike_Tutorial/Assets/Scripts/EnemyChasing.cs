using System;
using System.Collections;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    Transform player;
    public float enemySpeed;
    public int maxHealth = 100;
    private int currentHealth;
    public float attackRange = 0.5f;
    public Animator anim;
    private bool isDeath;
    private bool canAttack;
    public float disappearTime = 0.5f;
    private EnemySpawner spawner;

    void Start()
    {
        currentHealth = maxHealth;
        player = FindObjectOfType<PlayerMovement>().transform;
        anim = GetComponent<Animator>();
        spawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        

        if(isDeath){return;}
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < attackRange){
            Attack();
        }
        else{
            Move();
        }
    }
    void Move(){
        if(!canAttack){
            anim.SetBool("isFlying", true);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed*Time.deltaTime);
    }
    void Attack(){
        if(!canAttack){
            canAttack = true;
            anim.SetTrigger("Attack");
            anim.SetBool("isFlying", false);
            player.GetComponent<PlayerHealth>().TakeDamage(20);
            
            Invoke("EndAttack", 1.0f);
            
        }
    }
    void EndAttack(){
    canAttack = false;
}
    public void TakeDamage(int damage){
        if(isDeath){return; }
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
         if (currentHealth <= 0) 
        {
            Dead();
        }
    }
    private void Dead(){
        isDeath = true;
        anim.SetTrigger("Death");

        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null){
            enemyCollider.enabled = false;
        }
        if (spawner != null)
    {
        spawner.DecreaseEnemyCount();
    }


        StartCoroutine(Disappear());
    }
     private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(disappearTime);
        Destroy(gameObject); 
    }
}
