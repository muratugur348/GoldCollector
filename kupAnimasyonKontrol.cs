using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kupAnimasyonKontrol : MonoBehaviour
{
    float sayac;
    public bool kupAnimasyon = true;
    // Start is called before the first frame update
    void Start()
    {
        sayac = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (kupAnimasyon == true)
        {
            sayac -= Time.deltaTime;
            if (sayac < 0)
            {
                GetComponent<Animator>().Play(0);
                sayac = Random.Range(1, 3);
            }
        }
    }
}
