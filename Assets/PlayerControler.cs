using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    private int dinero;
    public int speed;
    private int pos;
    public Text countText;
    public Animator anim;

	// Use this for initialization
	void Start () {
        dinero = 100;
        pos = 2;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = (transform.position + new Vector3(-1, 0, 0)*Time.deltaTime*speed) ;

        if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.MOB1_M1_Run_F"))
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow) && pos != 1)
            {
                transform.position = transform.position + new Vector3(0, 0, -1);
                pos -= 1;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && pos != 3)
            {
                transform.position = transform.position + new Vector3(0, 0, 1);
                pos += 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.Play("MOB1_M1_Run_F_Jump", -1, 0);
            }

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
