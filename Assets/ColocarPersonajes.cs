using UnityEngine;
using System.Collections;

public class ColocarPersonajes : MonoBehaviour {

    public GameObject prefab;
    public GameObject prefabTigre;
    public Transform puntoGeneracion;
    public float Timer = 2f;

    public int numberOfObjects = 20;
    public float radius = 20f;

    public GameObject[] robots;
    private int actualVictima = 0;
    private bool generados = false;

    // Use this for initialization
    void Start () {
        robots = new GameObject[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            pos = pos + transform.position;
            robots[i] = (GameObject)Instantiate(prefab, pos, Quaternion.identity);

            //GameObject go = (GameObject)Instantiate(prefabTigre, puntoGeneracion.position, Quaternion.identity);
            //go.GetComponent<Perseguir>().Victima = robots[i].transform;
        }
        generados = true;
        //StartCoroutine(GenerarPumas());
        
            
    }
    IEnumerator GenerarPumas()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject go = (GameObject)Instantiate(prefabTigre, puntoGeneracion.position, Quaternion.identity);
            go.GetComponent<Perseguir>().Victima = robots[i].transform;
            yield return new WaitForSeconds(2);
        }
            
    }

    // Update is called once per frame
    void Update () {
        if (!generados)
            return;

        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            GameObject go = Instantiate(prefabTigre, puntoGeneracion.position, Quaternion.identity) as GameObject;
            float x = Random.Range(0, 10);
            if (x < 4)
                go.GetComponent<Perseguir>().Victima = transform;
            else
            {
                go.GetComponent<Perseguir>().Victima = robots[actualVictima].transform;
                actualVictima = (actualVictima + 1) % numberOfObjects;
            }
            Timer = 4f;
        }
    }
}
