using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKontrol : MonoBehaviour
{
    float hassasiyet = 5f, yumusaklik = 2f;
    public Vector2 gecisPos, camPos;
    GameObject oyuncu;
    public oyunKontrol oyunK;
    public UnityEngine.UI.Scrollbar hassasscroll;
    public UnityEngine.UI.Text hassdeger;
    int oyunbaslangic = 0;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = transform.parent.gameObject;
        if (PlayerPrefs.HasKey("hassasscroll"))  //totalScoreKey anahtarıyla kaydedilmiş bir veri var mı ?
        {
            hassasiyet = PlayerPrefs.GetFloat("hassasscroll"); // totalScoreKey anahtarıyla kaydedilmiş veriyi getir
        }
        else
        {
            hassasiyet = 5f;

        }
        hassasscroll.value = hassasiyet/10;
        hassdeger.text = ((int)(hassasiyet * 10)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (oyunK.oyunDevam == true)
        {
            Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            farePos = Vector2.Scale(farePos, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));
            gecisPos.x = Mathf.Lerp(gecisPos.x, farePos.x, 1f / yumusaklik);
            gecisPos.y = Mathf.Lerp(gecisPos.y, farePos.y, 1f / yumusaklik);
            camPos += gecisPos;
            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
            oyuncu.transform.localRotation = Quaternion.AngleAxis(camPos.x, oyuncu.transform.up);
            if (camPos.y < -70)
                camPos.y = -70;
            if (camPos.y > 30)
                camPos.y = 30;
        }
    }
    public void hassasiyetDegis()
    {
        if (oyunbaslangic == 0)
            oyunbaslangic = 1;
        else if (oyunbaslangic == 1)
        {
            if (hassasscroll.value == 0)
                hassasscroll.value = 0.01f;
            hassasiyet = (float)(hassasscroll.value * 10);
            PlayerPrefs.SetFloat("hassasscroll", hassasiyet);
            hassdeger.text = ((int)(hassasiyet * 10)).ToString();
        }
    }
}
