using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 position;
    public float speed;
    public bool isFacingRight=true ;
    [SerializeField] GameObject Troops;
    int regionValue;
    bool TroopSpawned;
    private void Start()
    {
        position = transform.position;
        if (transform.position.x > 0)
        {
            Flip();
        }
        regionValue = (int)Random.Range(0,3);
        TroopSpawned = false;
    }
    private void Update()
    {
        if (isFacingRight)
        {
            position += transform.right * speed * Time.deltaTime;

        }
        else { 
        
            position += -transform.right * speed * Time.deltaTime;

        }
        transform.position = position;
        if (TroopSpawned == false&&GameManager.instance.spawingAllowed)
        {
            if (regionValue == 0)
            {
                if (transform.position.x > -8 && transform.position.x < -2)
                {
                    StartCoroutine("Spawn");
                }
            }
            else if(regionValue == 1)
            {
                if (transform.position.x > 3 && transform.position.x < 8)
                {
                    StartCoroutine("Spawn");
                }
            }

        }
        

    }
    IEnumerator Spawn()
    {
        TroopSpawned = true;
        yield return new WaitForSeconds(Random.Range(0.1f,1.5f));
        Instantiate(Troops, new Vector3(transform.position.x, transform.position.y - 0.3f, 0), Quaternion.identity);



    }

   
    public void Flip()
    {
        Vector3 currentScale =transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
