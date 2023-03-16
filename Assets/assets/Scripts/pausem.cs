using UnityEngine;
using System.Collections;

public class pausem : MonoBehaviour {
	public GameObject pauseButton, pausePanel,mainmenuButton, restartButton, quitButton , muteButton;
	private bool muted;


	void Start ()
	{
		OnUnPause ();
	}

	void Update()
	{
		if(muted)
		{
			AudioListener.volume= 0;

		}

		if(!muted)
		{
			AudioListener.volume= 1;

		}
	}

	public void OnPause()
	{
		pausePanel.SetActive (true);
		pauseButton.SetActive (false);
		Time.timeScale = 0;
	}
	public void OnUnPause()
	{
		pausePanel.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1;




	}

	public void restart()
	{
		Application.LoadLevel (0);
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}
	
	public void mainmenu()
	{
		Application.LoadLevel (1);
		Time.timeScale = 0;
		pausePanel.SetActive (false);
	}
	public void quit()
	{
		Application.Quit ();
		pausePanel.SetActive (false);
		
	}

	public void mute()
	{
		muted = !muted;
		pausePanel.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1;
	}


}
