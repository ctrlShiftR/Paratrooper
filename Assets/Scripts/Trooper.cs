using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trooper : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject parashute;
    public float rotAngle=40;
    public float rotSpeed;
    public float rotTime;
    private bool ismoving=false;
    public bool hasHeadSpace ;
    public bool isGrounded=false;
    //public Transform pivot;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Parashute", 1.2f);
        hasHeadSpace = true;
    }
    

    
    void Update()
    {
        if (parashute.activeInHierarchy)
        {
            rotTime += Time.deltaTime;
            parashute.transform.rotation=Quaternion.Euler(0,0,rotAngle*Mathf.Sin(rotTime*rotSpeed));
            transform.rotation = parashute.transform.rotation;
           
            
        }
        
    }
    public void Parashute()
    {
        parashute.SetActive(true);
        rb.drag = 1.8f;
        
    }
    public void Move()
    {
        var direction=transform.position-new Vector3(0,transform.position.y,0);
        direction.Normalize();
        if (ismoving)
        {

            transform.Translate(-direction * 2 * Time.deltaTime);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            ismoving = true;
            isGrounded = true;
            parashute.SetActive(false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (transform.position.x > 0)
            {
                GameManager.instance.rightTroops.Add(this);
            }
            else
            {
                GameManager.instance.leftroops.Add(this);
            }

        }
        if (ismoving)
        {
            
            if (other.gameObject.tag == "wall")
            {

                ismoving = false;
            }
            if (other.gameObject.tag == "trooper"&&other.gameObject.GetComponent<Trooper>().isGrounded)
            {
                //ismoving = false;
                if (other.gameObject.GetComponent<Trooper>().hasHeadSpace)
                {
                    Vector3 position = other.gameObject.transform.position+new Vector3(0,other.collider.bounds.size.y,0);
                    Debug.Log(position);
                    transform.position = position;
                   other.gameObject.GetComponent<Trooper>().hasHeadSpace = false;
                }
                else
                {
                    ismoving = false;
                }
            }
        }
        if (other.gameObject.tag == "Turret")
        {
            Destroy(other.gameObject);
            GameManager.instance.GameOver();
        }
        

    }
}
