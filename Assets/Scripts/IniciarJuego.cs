using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IniciarJuego : MonoBehaviour {

    string str;
    // Use this for initialization
    void Start()
    {
        if (!UnitySphinx.IsInitialized())
            UnitySphinx.Init();
        UnitySphinx.Run();
    }

    // Update is called once per frame
    void Update()
    {


        if (UnitySphinx.GetSearchModel() == "kws")
        {
            str = UnitySphinx.DequeueString();
            print("listening for keyword");
            if (str != "")
            {
                //Application.LoadLevel("1");
                SceneManager.LoadScene("1");
                //guitext.text = "order up";
                print(str);
            }
        }
        /*
        else if (UnitySphinx.GetSearchModel() == "jsgf")
        {
            if (str!="")
            {
                Vector3 v;
                if (str == "ALAXA")
                    v = new Vector3(0, 0.5f, 0);
                else if (str == "AYNACHA")
                    v = new Vector3(0, -0.5f, 0);
                else if (str == "KUPI")
                    v = new Vector3(0.5f, 0, 0);
                else v = new Vector3(-0.5f, 0, 0);

                transform.position += v;
                print("de prueba " + str);
            }
                
                
        }*/
    }
}
