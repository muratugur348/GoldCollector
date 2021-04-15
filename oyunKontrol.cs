using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oyunKontrol : MonoBehaviour
{
    public bool oyunDevam=false;
    public UnityEngine.UI.Button buton;
    public GameObject oyuncu,top;
    public oyuncuKontrol oyuncuK;
    public kameraKontrol kameraK;
    public kupAnimasyonKontrol kupK;
    public GameObject menu;
    public UnityEngine.UI.Image baslik,talimat;
    // Start is called before the first frame update
    void Start()
    {
        oyuncuK.disableImage();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale==1&& oyunDevam==true)
        {
            baslik.gameObject.SetActive(true);
            Time.timeScale = 0;
            oyunDevam = false;
            menu.SetActive(true);
            
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            oyunDevam = true;
            baslik.gameObject.SetActive(false);
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
    public void oyundevam()
    {
        baslik.gameObject.SetActive(false);
        oyunDevam = true;
        Time.timeScale = 1;
        menu.SetActive(false);

    }
    public void oyundancik()
    {

        Application.Quit();
    }
    public void oyunaBasla()
    {
        talimat.gameObject.SetActive(false);
        baslik.gameObject.SetActive(false);
        top.GetComponent<Rigidbody>().useGravity = true;
        kupK.kupAnimasyon = true;
        oyuncuK.disableImage();
        kameraK.camPos.y = 7f;
        kameraK.camPos.x = -1f;

        oyuncuK.SetActive();
        oyuncuK.altin = 0;
        oyuncuK.altintext.text = ("Kalan Altin = " + (3 - oyuncuK.altin)).ToString();
        oyuncu.transform.SetPositionAndRotation(new Vector3(44.3f, 10.71f, -18.75f), new Quaternion(0, 0, 0,0));
        top.GetComponent<Rigidbody>().velocity = Vector3.zero;
        top.transform.SetPositionAndRotation(new Vector3(-21.14631f, 15f, -17.61509f), new Quaternion(0, 0, 0, 0));
        buton.gameObject.SetActive(false);
        oyunDevam = true;
    }
}
