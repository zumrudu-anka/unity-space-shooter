using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxControls : MonoBehaviour {
    Rigidbody fizik;
    public float hiz;
	void Start () {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * hiz;
	}
	
	
}
