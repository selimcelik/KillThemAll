using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class anaMenuKontrol : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void oyunaGit()
    {
        SceneManager.LoadScene("level1");
    }
    public void oyundanCik()
    {
        Application.Quit();
    }
}
