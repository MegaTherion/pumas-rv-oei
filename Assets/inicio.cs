using UnityEngine;
using System.Collections;

public class inicio : MonoBehaviour 
{
	public void jugar(string LevelName)
	{
	Application.LoadLevel("1");
	}
	public void salir()
	{
		Application.Quit ();
	}


}
