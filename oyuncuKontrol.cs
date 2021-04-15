using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuKontrol : MonoBehaviour
{
    public AudioClip altinses, dusmeses;
    private float hiz = 10;
    public UnityEngine.UI.Text altintext;
    public oyunKontrol oyunK;
    public GameObject altin0, altin1, altin2;
    public UnityEngine.UI.Image win, lose;
    public kupAnimasyonKontrol kupK;
    Rigidbody jump;
    bool ziplama = false;
    // Start is called before the first frame update
    void Start()
    {
        
         jump = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (oyunK.oyunDevam == true)
        {
            
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            x *= Time.deltaTime * hiz;
            y *= Time.deltaTime * hiz;
            transform.Translate(x, 0f, y);

            if (Input.GetKeyDown(KeyCode.Space)&& ziplama==true)
            {
                jump.AddForce(Vector2.up * 200f);
            }
        }
    }
    public int altin = 0;

    private void OnCollisionStay(Collision collision)
    {
        ziplama = true; 
        
    }
    private void OnCollisionExit(Collision collision)
    {
            ziplama = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        

        if (collision.gameObject.tag.Equals("altin"))
        {

            collision.gameObject.SetActive(false);
            altin++;
            altintext.text = ("Kalan Altin = " +(3 - altin)).ToString();
            GetComponent<AudioSource>().PlayOneShot(altinses,1f);
        }
        else if (collision.gameObject.tag.Equals("rakip")) 
        {
            if(collision.gameObject.name.Equals("top"))
            {
                collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            kupK.kupAnimasyon = false;
            GetComponent<AudioSource>().PlayOneShot(dusmeses, 1f);
            lose.gameObject.SetActive(true);
            
            oyunK.buton.gameObject.SetActive(true);
            oyunK.oyunDevam = false;

        }
        
        if (altin==3)
        {

            win.gameObject.SetActive(true);
            oyunK.buton.gameObject.SetActive(true);
            oyunK.oyunDevam = false;
        }
    }
    public void disableImage()
    {
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
    }
    public void SetActive()
    {
        altin0.gameObject.SetActive(true);
        altin1.gameObject.SetActive(true);
        altin2.gameObject.SetActive(true);
    }
}
