using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameRanking : MonoBehaviour
{
    public CheckCollisions cc;
    public Text[] namesTxt;
    public string a, b, c, d, e, f, g;

    void Start()
    {
        cc = FindObjectOfType<CheckCollisions>();

    }
    private void Update()
    {
    
    if (cc.isGameFinished == false)
    {
        namesTxt[0].text = a;
        namesTxt[1].text = b;
        namesTxt[2].text = c;
        namesTxt[3].text = d;
        namesTxt[4].text = e;
        namesTxt[5].text = f;
        namesTxt[6].text = g;
    } 

    }
}
