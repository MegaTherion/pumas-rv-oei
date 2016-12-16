using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Perseguir : MonoBehaviour {
    public Transform Victima;
    public int velocidadePerseguidor = 4;
    public int damp = 2;
    public Rigidbody projectile;
    public int speed = 20;

    private Animator anim;
    public bool Highlighted = false;
    private bool quieto;
    private int hits = 0;
    private int hitsEnd = 0;
    private bool matador = false;
    int runHash = Animator.StringToHash("run");

    void Awake()
    {
        gameObject.tag = "Highlightable";
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        quieto = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        Shader shader1 = Shader.Find("Diffuse");
        //if (shader1 != null) Debug.Log("habia sido nulo");
        if (GetComponentInChildren<SkinnedMeshRenderer>() == null)
            Debug.Log("es nulo");
        /*
        if (GetComponentInChildren<Renderer>().GetComponent<Material>() == null)
            Debug.Log("nada de nada");
        Shader shader2 = Shader.Find("Self-Illumin/Diffuse");
        if (Highlighted)
            GetComponentInChildren<SkinnedMeshRenderer>().material.shader = shader2;
        else
            GetComponentInChildren<SkinnedMeshRenderer>().material.shader = shader1;

        */

        if (Victima != null)
        {
            if (quieto)
                return;

            if (Vector3.Distance(Victima.position, transform.position) < 1)
            {
                anim.Play("hit");

                if (!matador)
                {
                    hits++;
                    if (hits > 5)
                    {
                        Color colorStart = Victima.gameObject.GetComponentInChildren<Renderer>().material.color;
                        Color colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);
                        for (float t = 0.0f; t < 2f; t += Time.deltaTime)
                        {
                            Victima.gameObject.GetComponentInChildren<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, t / 2f);
                            
                        }
                        

                        Destroy(Victima.gameObject);
                        Victima = GameObject.Find("FPSController").transform;
                        matador = true;
                    }
                }
                else
                {
                    hitsEnd++;
                    if (hitsEnd >= 10)
                        SceneManager.LoadScene("Menu");
                }
                
                    
            }
                
            else if (Vector3.Distance(Victima.position, transform.position) < 200)
            {
                // animacion
                //anim.SetTrigger(runHash);
                anim.Play("run");

                var rotate = Quaternion.LookRotation(Victima.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotate, damp * Time.deltaTime);
                transform.Translate(0, 0, velocidadePerseguidor * Time.deltaTime);
                /*
                Rigidbody instantiatedProjectile  = (Rigidbody)Instantiate(projectile, transform.position, transform.rotation);
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>());*/
            }
            if (Vector3.Distance(Victima.position, transform.position) < 2)
            {
                //anim
                //animation.wrapMode =WrapMode.Once;
            }
        }
    }
}
