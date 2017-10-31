using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportal : MonoBehaviour {

	[SerializeField] private Cubo cubo;
	[SerializeField]GameObject tpLlegada;

	[SerializeField] private InterfazGrafica inter;

	void OnTriggerEnter(Collider other){

		Debug.Log ("tocado");
		if (inter.GetPodertp()) {
			if (other.gameObject.tag == "Cubo") {

				cubo.transform.position = tpLlegada.transform.position;
			}
		}
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

}
