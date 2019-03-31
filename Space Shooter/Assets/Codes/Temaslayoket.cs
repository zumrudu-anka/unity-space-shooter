using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temaslayoket : MonoBehaviour {
    public GameObject patlama;
    public GameObject player_patlama;
    GameObject OyunKont;
    OyunKontrol kontrol;
    void Start()
    {
        OyunKont = GameObject.FindGameObjectWithTag("OyunKontrol");
        kontrol = OyunKont.GetComponent<OyunKontrol>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Sinir")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            if(other.tag!="Player")
                kontrol.ScoreArttir(10);
        }
        if (other.tag == "Player")
        {
            Instantiate(player_patlama, other.transform.position, other.transform.rotation);
            kontrol.OyunBitti();
        }
    }
}
