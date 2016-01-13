using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    private int dinero;
    public int speed;
    private int pos;
    public Text countText;
    private float nextMove;
    public float moveColldown;

	// Use this for initialization
	void Start () {
        dinero = 100;
        pos = 2;
        nextMove = Time.time;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = (transform.position + new Vector3(-1, 0, 0)*Time.deltaTime*speed) ;
        if (Input.GetKey(KeyCode.LeftArrow) && pos != 1 && Time.time > nextMove)
        {
            nextMove = Time.time+moveColldown;
            transform.position = transform.position + new Vector3(0, 0, -1);
            pos -= 1;
        }

        if (Input.GetKey(KeyCode.RightArrow) && pos != 3 && Time.time > nextMove)
        {
            nextMove = Time.time + moveColldown;
            transform.position = transform.position + new Vector3(0, 0, 1);
            pos += 1;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {

            Destroy(other.gameObject);
            dinero += 10;
            countText.text = dinero.ToString();
        }

    }
}
