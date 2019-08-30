using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class karakterKontrol : MonoBehaviour
{
    public Sprite[] beklemeAnim;
    public Sprite[] ziplamaAnim;
    public Sprite[] yurumeAnim;
    public Transform Weapon;
    

    float horizontal=0;
    float beklemeAnimZaman = 0;
    float yurumeAnimZaman = 0;
    float atesZamani = 0;
    

    int beklemeAnimSayac = 0;
    int yurumeAnimSayac = 0;

    Vector3 vec;
    
    

    SpriteRenderer spriteRenderer;
    Rigidbody2D fizik;

    bool birkerezipla = true;

    
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.Space))
        {
            if (birkerezipla)
            {
                fizik.AddForce(new Vector2(0, 570));
                birkerezipla = false;
            }
            
        }
    }

    void FixedUpdate()
    {
        Animasyon();
        karakterHareket();
    }

    public void karakterHareket()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * 10, fizik.velocity.y,0);
        fizik.velocity = vec;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        birkerezipla = true;   
    }
    void Animasyon()
    {
        if (birkerezipla)
        {
            if (horizontal == 0)
            {
                beklemeAnimZaman += Time.deltaTime;
                if (beklemeAnimZaman > 0.05f)
                {
                    spriteRenderer.sprite = beklemeAnim[beklemeAnimSayac++];
                    if (beklemeAnimSayac == beklemeAnim.Length)
                    {
                        beklemeAnimSayac = 0;
                    }
                    beklemeAnimZaman = 0;
                }
            }
            else if (horizontal > 0)
            {
                yurumeAnimZaman += Time.deltaTime;
                if (yurumeAnimZaman > 0.01f)
                {
                    spriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                    if (yurumeAnimSayac == yurumeAnim.Length)
                    {
                        yurumeAnimSayac = 0;
                    }
                    yurumeAnimZaman = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                yurumeAnimZaman += Time.deltaTime;
                if (yurumeAnimZaman > 0.01f)
                {
                    spriteRenderer.sprite = yurumeAnim[yurumeAnimSayac++];
                    if (yurumeAnimSayac == yurumeAnim.Length)
                    {
                        yurumeAnimSayac = 0;
                    }
                    yurumeAnimZaman = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (fizik.velocity.y > 0)
            {
                spriteRenderer.sprite = ziplamaAnim[0];
            }
            
            else
            {
                spriteRenderer.sprite = ziplamaAnim[1];
            }
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
