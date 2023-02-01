using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour {

    public AudioSource play;
    public AudioSource quit;
    public AudioSource notes;
    public AudioSource drums;
    public AudioSource mix1;
    public AudioSource mix2;

    public Animator anim;

	public void PlayButton()
    {
        SceneManager.LoadScene("Modes");
        play.Play();
        
    }

    public void NotesButton()
    {
        SceneManager.LoadScene("Level1");
        notes.Play();
    }

    public void DrumsButton()
    {
        SceneManager.LoadScene("Level2");
        drums.Play();
    }

    public void Mix1Button()
    {
        SceneManager.LoadScene("Level3");
        mix1.Play();

    }

    public void Mix2Button()
    {
        SceneManager.LoadScene("Level4");
        mix2.Play();
    }

    public void Quit()
    {
        Application.Quit();
        quit.Play();
    }
}
