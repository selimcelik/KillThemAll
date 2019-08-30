using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kursunKontrol : MonoBehaviour
{
    //Rigidbody2D fizik;
    public float hiz;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    //public Text scoreText;
    //public static int kill;
    //public int score = 0;
    

    public GameObject destroyEffect;
   

    void Start()
    {
        //fizik = GetComponent<Rigidbody2D>();
        //fizik.velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition) * hiz;
        Invoke("DestroyKursun", lifetime);
        
        //score = 0;
        //scoreText.text = "Score = " + score;
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.up,distance,whatIsSolid);
        if(hitInfo.collider !=null)
        {
            if (hitInfo.collider.CompareTag("enemy"))
            {
                hitInfo.collider.GetComponent<dusmanKontrol>().takeDamage(damage);
                spawnerKontrol.KillCount++;


            }
            DestroyKursun();
        }
        transform.Translate(Vector2.up * hiz * Time.deltaTime);


    }
    void DestroyKursun()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
