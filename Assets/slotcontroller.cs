using UnityEngine;
using System.Collections;
using System;

public class slotcontroller : MonoBehaviour {

    private Color[] colores = new Color[] { new Color(0, 0, 0, 1), new Color(0, 0, 1, 1), 
    new Color (0,1,1,1),new Color (0.5f,0.5f,0.5f,1),new Color (0,1,0,1),new Color (1,0,1,1),
    new Color (1,0,0,1),new Color (1,0.92f,0.016f,1)};
    public GameObject[] wheels;
    public Animator anim;
    private System.Random rnd;
    private Material[] ruedas;

	// Use this for initialization
	void Start () {
        ruedas = new Material[wheels.Length];
        for (int i = 0; i < wheels.Length; i++) { 
            ruedas[i] = wheels[i].GetComponent<Renderer>().material;
        }
	}
	
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            bool iguales = true;
            anim.Play("Take 001", -1, 0);
            rnd = new System.Random();
            ruedas[0].color = colores[rnd.Next(0, colores.Length)];
            for (int i = 1; i < wheels.Length; i++)
            {
                ruedas[i].color = colores[rnd.Next(0,colores.Length)];
                iguales = iguales && ruedas[i].color == ruedas[i-1].color;
            }
            if (iguales) {
                other.gameObject.GetComponent<PlayerControler>().dinero += 1000;
            }
            
        }

    }
}
