using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CamCastScript : MonoBehaviour {

    private int pumasmuertos = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit Hit;
        
        
        if (Physics.Raycast(transform.position, fwd, out Hit, 100f))
        {
            string str = UnitySphinx.DequeueString();
            bool morirpuma = false;
            bool corrergente = false;
            if (UnitySphinx.GetSearchModel() == "jsgf")
            {
                if (str != "")
                {

                    if (str == "THANTHA TITI")
                        morirpuma = true;
                    else if (str == "SINTI TITI")
                    {
                        corrergente = true;
                        pumasmuertos++;
                    }
                        
                    print(str);
                }


            }

            if (Hit.collider.gameObject.tag == "Highlightable" && morirpuma)
            {
                Debug.Log("puma hiteado");
                Hit.collider.gameObject.GetComponent<Perseguir>().Highlighted = true;
                Destroy(Hit.collider.gameObject);
                pumasmuertos++;
                if (pumasmuertos >= 15)
                {
                    SceneManager.LoadScene("Menu");
                }
                
            }

            if (Hit.collider.gameObject.tag.Equals("Escapador") && corrergente)
            {
                Debug.Log("roboot hiteado");
                
                Hit.collider.gameObject.GetComponent<Corredor>().Correr = true;
                // Destroy(Hit.collider.gameObject);

            }
        }
    }
}
