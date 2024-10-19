using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject[] bullets;
    public float shootingCooldown;
    private float cooldownTimer = 0;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && cooldownTimer > shootingCooldown){
            Shoot();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Shoot(){
        bullets[FindBullet()].transform.position = bulletPoint.position;
        Vector2 direction = bulletPoint.right;
        bullets[FindBullet()].GetComponent<ProjectTile>().SetDirection(direction); 
        cooldownTimer = 0f;

    }
    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
