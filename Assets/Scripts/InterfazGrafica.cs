using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazGrafica : MonoBehaviour {
	
    bool enPausa;
    [SerializeField]GameObject MenuTienda;
	[SerializeField]GameObject objeto;
    [SerializeField]Cubo jugador;
    [SerializeField]Text textoMonedas;
    [SerializeField]Button botonCambiarSalto;
	[SerializeField]Button botonCambiarVida;
	[SerializeField]Button teleport;
    int cantidadMejorasSalto;
	int cantidadMejorasVida;
	int cantidadTp;
	bool poderTeleportar;
    
	public void BotonPausa()
    {
		if (!enPausa)
		{MenuTienda.SetActive(true);
			objeto.SetActive (true);
            enPausa = true;
			Time.timeScale = 0;
        }
        else
		{objeto.SetActive (false);
            Time.timeScale = 1;
            enPausa = false;
            MenuTienda.SetActive(false);
        }
    }
	public void Teleportar(){

		if (jugador.GetMonedas() >= 1)
		{
			jugador.numeroMoneda = jugador.numeroMoneda - 1;
			poderTeleportar = true;
			cantidadTp--;

		}

	}
	public bool GetPodertp()
	{

		return poderTeleportar;
	}

    public  void CambiarSalto()
    {
		
		jugador.AumentarSalto();
		cantidadMejorasSalto--;
		//jugador.numeroMoneda = jugador.numeroMoneda - 1;

        
    }

	public void CambiarVida()
	{
		jugador.SubirVidas();
		cantidadMejorasVida--;
	}

	// Use this for initialization
	void Start () {
        enPausa = false;
        cantidadMejorasSalto = 3;
		cantidadMejorasVida = 1;
		cantidadTp = 1;
		//jugador = GetComponent<Cubo> ();
	}

    // Update is called once per frame
    void Update() {
		//Debug.Log (enPausa);
        textoMonedas.text = jugador.GetMonedas().ToString();
        if (cantidadMejorasSalto <= 0)
        {
            botonCambiarSalto.interactable = false;
        }
		if (cantidadMejorasVida <= 0) 
		{
			botonCambiarVida.interactable = false;
		}
		if(cantidadTp <= 0)
		{
			teleport.interactable = false;
		}
	}
}
