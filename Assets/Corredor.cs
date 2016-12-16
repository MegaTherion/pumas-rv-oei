using UnityEngine;
using System.Collections;

public class Corredor : MonoBehaviour {
    public bool Correr = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Correr)
        {
            Animator anim = GetComponent<Animator>();
            anim.Play("Run");
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
            
	}
}
