﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public int dinero;
    public int speed;
    private int pos;
    public GameObject camara;
    public Text countText;
    public Text finText;
    public Text finText2;
    public Animator anim;
    private Material[] m;
    public GameObject plano;
    private Color activeLineColor;
    private Color unactiveLineColor;

	// Use this for initialization
	void Start () {
        pos = 2;
        m = plano.GetComponent<Renderer>().materials;
        activeLineColor = new Color(1, 1, 1);
        unactiveLineColor = new Color(0.4980392f, 0.4980392f, 0.4980392f, 1);
        m[1].color = activeLineColor;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetButtonDown("Submit"))
        {
            Application.LoadLevel(0);
        }


        transform.position = (transform.position + new Vector3(-1, 0, 0)*Time.deltaTime*speed);
        camara.transform.position = (camara.transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed);

        if (anim.GetCurrentAnimatorStateInfo(0).nameHash == Animator.StringToHash("Base Layer.MOB1_M1_Run_F"))
        {
            transform.position = new Vector3(transform.position.x, 0.08f, transform.position.z);
            if (Input.GetKeyDown(KeyCode.LeftArrow) && pos != 1)
            {
                transform.position = transform.position + new Vector3(0, 0, -1.10f);
                camara.transform.position = camara.transform.position + new Vector3(0, 0, -1.10f);
                m[pos - 1].color = unactiveLineColor;
                pos -= 1;
                m[pos - 1].color = activeLineColor;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && pos != 3)
            {
                transform.position = transform.position + new Vector3(0, 0, 1.10f);
                camara.transform.position = camara.transform.position + new Vector3(0, 0, 1.10f);
                m[pos - 1].color = unactiveLineColor;
                pos += 1;
                m[pos - 1].color = activeLineColor;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.Play("MOB1_M1_Run_F_Jump", -1, 0);
                transform.position = (transform.position + new Vector3(0, 0.1f, 0));
            }

        }

	}

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Coins"))
        {

            Destroy(other.gameObject);
            dinero += 10;
            countText.text = dinero.ToString();
        }
        if (other.gameObject.CompareTag("slot"))
        {
            speed = 0;
            anim.Play("dead", -1, 0);
            transform.Rotate(-90,0,0);
            finText.text = "Score: " + dinero.ToString();
            finText2.text = "Press 'enter' to restart";
        }
        if (other.gameObject.CompareTag("saltable"))
        {
            speed = 0;
            anim.Play("dead", -1, 0);
            transform.Rotate(-90, 0, 0);
            finText.text = "Score: " + dinero.ToString();
            finText2.text = "Press 'enter' to restart";
        }
        if (other.gameObject.CompareTag("fin"))
        {
            speed = 0;
            finText.text = "Score: " + dinero.ToString();
            finText2.text = "Press 'enter' to restart";
        }

    }
}
