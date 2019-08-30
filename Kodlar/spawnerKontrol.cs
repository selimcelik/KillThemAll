using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spawnerKontrol : MonoBehaviour
{
    public GameObject enemy;
    Vector2 whereToSpawn;

    float randX;
    float nextSpawn = 0.0f;
    public float spawnRate = 0.75f;

    bool dusmanolustur = true;

    public static int dusmansayac = 0;
    public static int KillCount = 0;
    public int olusandusman = 0;
    int dusmanSayisi = 2;
    int wave = 1;
  
    public Text killwaveText;
    public Text waveText;
    public Text levelbittitext;
    public Text scoreText;

    void Update()
    {

        if (Time.time > nextSpawn && dusmanolustur)
        {
            Spawner();
        }


        if (dusmansayac == dusmanSayisi)
        {
            dusmanolustur = false;
            dusmansayac = 0;
        }

        if (KillCount < dusmanSayisi)
        {
            scoreText.text = KillCount + "/";
        }

        if (KillCount == dusmanSayisi)
        {
            dusmanolustur = true;
            KillCount = 0;



        if (olusandusman == dusmanSayisi * 2)
        {
        
            dusmanolustur = false;
        
            Debug.Log("Wave Bitti");

            waver();


        }
        }
        if (wave == 4)
        {
            dusmanolustur = false;
            levelbittitext.text = "LEVEL BİTTİ";
            Invoke("anaMenuyeDon", 2f);
        }

        Debug.Log(dusmanSayisi);
    }
    

    void waver ()
    {
        wave++;
        waveText.text = "Wave = " + wave;
        dusmansayac = 0;
        dusmanSayisi += 2;
        olusandusman = 0;
        dusmanolustur = true;

    }

    public void Spawner()
    {
        
        nextSpawn = Time.time + spawnRate;
        randX = Random.Range(-13.26f, 13.26f);
        whereToSpawn = new Vector2(randX, transform.position.y);
        Instantiate(enemy, whereToSpawn, Quaternion.identity);
        dusmansayac++;
        olusandusman++;
        killwaveText.text =  "/" + dusmansayac;
    }
    public void anaMenuyeDon()
    {
        SceneManager.LoadScene("anamenu");
    }
}
