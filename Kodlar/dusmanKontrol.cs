using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dusmanKontrol : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject destroyEffect;
    


    void Start()
    {
        target = GameObject.Find("JAVA");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(3f, 7f);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
    
    private void Update()
    {
        moveMonster();

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
       switch (coll.gameObject.tag)
        {
            case "Player" :
                //spawnerKontrol.spawnAllowed = false;
                Instantiate(deathEffect, coll.gameObject.transform.position, Quaternion.identity);
                Destroy(coll.gameObject);
                target = null;
                Invoke("anamenuyeDon", 2f);

                break;

            case "Kursun":
                Instantiate(destroyEffect, transform.position, Quaternion.identity);               
                Destroy(coll.gameObject);
                Destroy(gameObject);
                break;

        }
    }

    void moveMonster()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    void anamenuyeDon()
    {
        SceneManager.LoadScene("anamenu");
    }
}
