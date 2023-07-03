using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightScripts : MonoBehaviour
{
    private float score;

    public GameObject[] nights;

    void Start()
    {
        for (int i = 0; i < nights.Length; i++)
        {
            nights[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManager.instance.getScore();

        if (score >= 200)
        {
            int check = (int)score / 200;
            if (check > 7) check %= 7;

            if ((int)score % 200 <= 70)
            {
                for (int i = 0; i < 9; i++)
                {
                    nights[i].SetActive(true);
                }

                nights[8 + check].SetActive(true);
            }
            else
            {
                for (int i = 0; i < nights.Length; i++)
                {
                    nights[i].SetActive(false);
                }
            }
        }
    }
}
