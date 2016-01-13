using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public int rotationSpeed;

	// Update is called once per frame
	void Update () {
        transform.Rotate(45*Time.deltaTime*rotationSpeed,0,0);
	}
}
