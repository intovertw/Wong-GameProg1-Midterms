using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenManager : MonoBehaviour
{
    public GameObject chickenLife;
    public GameObject[] chickenStages = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        ManagerGUI.total += 1;
        ManagerGUI.counts[0] += 1;
        for (int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                chickenStages[i].SetActive(true);
            }
            else
            {
                chickenStages[i].SetActive(false);
            }
        }

        StartCoroutine(ChickenCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChickenCoroutine()
    {
        int random;

        if (ManagerGUI.total == 1)
        {
            random = 2;
        }
        else
        {
            random = Random.Range(1, 3);
        }

        for (int i = 0; i < 2; i++)
        {
            //first loop, egg spawns +10s
            //second loop, chick grows to adult +10s
            yield return new WaitForSeconds(10f);
            //chick to adult added time and randomizes adult gender
            if (i == 1)
            {
                //chick to adult
                chickenStages[i + random].SetActive(true);
                chickenStages[i].SetActive(false);
                ManagerGUI.counts[i + random] += 1;
                ManagerGUI.counts[i] -= 1;

                yield return new WaitForSeconds(30f); //+30s

                //if hen, this lay eggs
                if (chickenStages[3].activeSelf == true)
                {
                    for (int j = 0; j < Random.Range(2, 10); j++)
                    {
                        Instantiate(chickenLife);
                    }
                }

                yield return new WaitForSeconds(10f); //+10
                ManagerGUI.counts[i + random] -= 1;
                Destroy(chickenLife);
            }
            //egg to chick
            else
            {
                chickenStages[i].SetActive(false);
                chickenStages[i + 1].SetActive(true);
                ManagerGUI.counts[i] -= 1;
                ManagerGUI.counts[i + 1] += 1;
            }
        }
    }
}
