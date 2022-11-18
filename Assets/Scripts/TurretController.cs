using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform spawnPoint;
     private Camera cam;
    public float _rotationSpeed;
    void Start()
    {
        cam=Camera.main;
    }

    
    void Update()
    {
        
        var mouseposition=cam.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;
        var dir = mouseposition - transform.position;
        
        dir.Normalize();
        Debug.Log(dir);
        if(dir.y > 0)
        {
            transform.up = Vector3.MoveTowards(transform.up, dir, _rotationSpeed * Time.deltaTime);

        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab,spawnPoint.position,Quaternion.identity).Init(transform.up);
        }
    }
}
