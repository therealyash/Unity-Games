using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mange : MonoBehaviour {

	public AudioSource playAud;
	public AudioSource aboutAud;
	public AudioSource aboutBack;
	public AudioSource quitAud;

	public GameObject blurPanel;

	public Animator aboutAnim;

	public GameObject MainMenuPanel;
	public GameObject aboutPanel;

	void Start(){
		
		aboutPanel.SetActive (false);
		blurPanel.SetActive (false);
	}

	public void PlayButton(){
		playAud.Play ();
		StartCoroutine (WaitTime ());
	}

	public void AboutButton(){

		aboutPanel.SetActive (true);
		MainMenuPanel.SetActive (false);
		aboutAud.Play ();
		aboutAnim.SetTrigger ("come");
		blurPanel.SetActive (true);


	}

	public void MainMenuButton(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void AboutBack(){

		aboutPanel.SetActive (false);
		MainMenuPanel.SetActive (true);
		aboutBack.Play ();
		aboutAnim.SetTrigger ("go");
		aboutAnim.SetTrigger ("idle");
		blurPanel.SetActive (false);

	}

	public void QuitButton(){
		quitAud.Play ();
		Application.Quit ();
	}

	 

	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

}
