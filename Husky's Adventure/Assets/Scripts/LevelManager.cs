using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject blurPanel;
    public Animator AboutPanel;
    public Animator pausePanel;
    public Animator winPanel;

    public GameObject mainMenuPanel;
    public GameObject aboutPanel;

    public GameObject pauseButton;

    public AudioSource playAud;
    public AudioSource aboutAud;
    public AudioSource quitAud;
    public AudioSource backAud;
    public AudioSource pauseAud;
    public AudioSource mainMenuAud;
    public AudioSource continueAud;
    public AudioSource nextBtn;
    public AudioSource winSound;

    private void Start()
    {
        blurPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void PlayButton()
    {
        playAud.Play();
        StartCoroutine(LoadLevel());
        
    }

    public void QuitButton()
    {
        quitAud.Play();
        Application.Quit();
        
    }

    public void AboutButton()
    {
        aboutAud.Play();
        aboutPanel.SetActive(true);
        blurPanel.SetActive(true);
        StartCoroutine(WaitForSomeTime());
       

    }

    public void BlurPanelBackButton()
    {
        backAud.Play();
        blurPanel.SetActive(false);
        AboutPanel.SetTrigger("go");
        AboutPanel.SetTrigger("idle");
        mainMenuPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void NextButton()
    {
        nextBtn.Play();
        StartCoroutine(LoadLevel());
    }

    public void PauseButton()
    {
        pauseAud.Play();
        pausePanel.SetTrigger("come");
        blurPanel.SetActive(true);
        StartCoroutine(PauseBtn());
        
    }

    public void ContinueButton()
    {
        continueAud.Play();
        pausePanel.SetTrigger("go");
        pausePanel.SetTrigger("idle");
        blurPanel.SetActive(false);
        pauseButton.SetActive(true);
        
    }

    public void MainMenuButton()
    {
        mainMenuAud.Play();
        SceneManager.LoadScene(0);
    }
	
    IEnumerator WaitForSomeTime()
    {
        yield return new WaitForSeconds(.6f);
        AboutPanel.SetTrigger("come");
        mainMenuPanel.SetActive(false);

       
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator PauseBtn()
    {
        yield return new WaitForSeconds(.6f);
        pauseButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            blurPanel.SetActive(true);
            winPanel.SetTrigger("come");
            winSound.Play();
            pauseButton.SetActive(false);

        }
    }
}
