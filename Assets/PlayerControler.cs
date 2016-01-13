using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    private int dinero;
    public int speed;

	// Use this for initialization
	void Start () {
        dinero = 100;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = (transform.position + new Vector3(-1, 0, 0)*Time.deltaTime*speed) ; 
	}
}
