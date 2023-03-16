using UnityEngine;
using System.Collections;

public class mainmenu : MonoBehaviour {

	public void start()
	{
		Application.LoadLevel (0);
		Time.timeScale = 1;
	}

	public void cikis()
	{
		Application.Quit ();
	}
}
