using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public  Image healthBar;
    public Animator anim;
    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        UpdateHealthBar();
        anim.SetTrigger("Hurt"); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
        Debug.Log("Health bar fill amount: " + healthBar.fillAmount);
    }

    private void Die()
    {
        isDead = true;
        anim.SetTrigger("Death");  
        FindObjectOfType<RetryMenu>().ShowRetryMenu();
        Time.timeScale = 0; 
        
    }
}
