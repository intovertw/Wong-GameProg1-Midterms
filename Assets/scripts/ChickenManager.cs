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
        for (int i = 0; i < 2; i++)
        {
            //first loop, egg spawns +10s
            //second loop, chick grows to adult +10s
            yield return new WaitForSeconds(1f);
            //chick to adult added time and randomizes adult gender
            if (i == 1)
            {
                Debug.Log("i == 1 is running");

                /**if (firstTime == true)
                {
                    chickenStages[i].SetActive(false);
                    chickenStages[i + 2].SetActive(true);
                }
                else
                {**/
                    chickenStages[i].SetActive(false);
                    chickenStages[i + Random.Range(1, 2)].SetActive(true);
                //}
                
                yield return new WaitForSeconds(3f); //+30s

                if (chickenStages[3].activeSelf == true)
                {
                    for (int j = 0; j < Random.Range(2, 10); j++)
                    {
                        Instantiate(chickenLife);
                    }
                }

                yield return new WaitForSeconds(1f); //+10s
                Destroy(chickenLife);
            }
            //egg to chick
            else
            {
                Debug.Log("else is running");
                chickenStages[i].SetActive(false);
                chickenStages[i + 1].SetActive(true);
            }
        }
    }
}
