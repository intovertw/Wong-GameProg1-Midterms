using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerGUI : MonoBehaviour
{
    public TextMeshProUGUI totalTxt;
    static public int total = 0;
    public TextMeshProUGUI[] countsTxt = new TextMeshProUGUI[4];
    static public int[] counts = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTxt.text = "Total spawned: " + total.ToString();
        for(int i = 0; i < 4; i++)
        {
            countsTxt[i].text = counts[i].ToString();
        }
    }
}
