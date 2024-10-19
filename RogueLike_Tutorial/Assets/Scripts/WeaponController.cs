using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform weaponPivot;
    public Camera mainCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeaponToMouse();
    }
    void RotateWeaponToMouse(){
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        
        Vector3 direction = mousePosition - weaponPivot.position;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        weaponPivot.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90 || angle < -90)
            {
                weaponPivot.localScale = new Vector3(1, -1, 1); 
            }
            else
            {
                weaponPivot.localScale = new Vector3(1, 1, 1);
            }
    }
}
