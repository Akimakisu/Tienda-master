using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour {

	private Transform myTransform;
	public float avance;
	public float salto;
	public int numeroMoneda;
	Rigidbody rigi;
	public bool poderSaltar;
	public bool escudo;
	bool enTierra;
	public int vida;

	[SerializeField]
	InterfazGrafica mInterfaz;

	void Start () {
		myTransform = GetComponent<Transform> ();
		numeroMoneda = 0;
		vida = 1;
		rigi=gameObject.GetComponent<Rigidbody> ();

		//mInterfaz = transform.Find ("Canvas").GetComponent<InterfazGrafica> ();
		poderSaltar = false;
	}
		

	public void SubirVidas() 
	{
		if (GetMonedas () >= 0 && escudo == true)
		{
			vida = vida + 1;
			numeroMoneda = numeroMoneda - 1;
		}
	}
    
	public void contador()
    {
        numeroMoneda = numeroMoneda + 1;
		if(numeroMoneda > 0) {

			 poderSaltar = true;
			 escudo = true;
		}


    }

    public int GetMonedas()
    {
        return numeroMoneda;
    }

   void Update () {



		if (Input.GetKey (KeyCode.D)) {
			myTransform.Translate (new Vector2 (-avance, 0.0f) * Time.deltaTime);

		}
		if(enTierra){
			if (Input.GetKey (KeyCode.W)) {
			
			
				myTransform.Translate (new Vector2 (0.0f, salto) * Time.deltaTime);
				enTierra = false;
			}
			
		}
		if (Input.GetKey (KeyCode.A)) {
			myTransform.Translate (new Vector2 (avance, 0.0f) * Time.deltaTime);

		}

		
		}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("piso")) {
			enTierra = true;
		}
		if (other.gameObject.CompareTag("Piso2")) {

			vida = vida - 1;

			if (vida == 0) {
				Destroy (this.gameObject);

			}
		}
	}

	public void AumentarSalto()
	{
	    if (GetMonedas()>= 0 && poderSaltar==true)
		{
			salto = salto+120;
			numeroMoneda = numeroMoneda - 1;
		
		}

	}

}
	
	



	



