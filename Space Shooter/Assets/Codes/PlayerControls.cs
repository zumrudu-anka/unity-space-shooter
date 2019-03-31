using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    Rigidbody fizik;
    float horizontal = 0, vertical = 0, ateszamani = 0;
    public float karakterhiz, minX, maxX, minZ, maxZ, atesgecensure;
    public GameObject kursun;
    public Transform Kursunnerdenciksin;
    AudioSource ates;
	void Start () {
        fizik = GetComponent<Rigidbody>();
        ates = GetComponent<AudioSource>();
	}

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>ateszamani)
        {
            ateszamani = Time.time + atesgecensure;
            Instantiate(kursun, Kursunnerdenciksin.position, Quaternion.identity);
            ates.Play();
        }
    }

    void FixedUpdate () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        fizik.velocity = new Vector3(horizontal,0,vertical) * karakterhiz;
        fizik.position = new Vector3(Mathf.Clamp(fizik.position.x, minX, maxX), 0,Mathf.Clamp(fizik.position.z,minZ,maxZ));
        fizik.rotation = Quaternion.Euler(0, 0, -fizik.velocity.x);
    }
}
