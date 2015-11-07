using System;
using UnityEngine;
using System.Collections;

public class MusicChoose : MonoBehaviour
{

    public AudioClip[] songList;

    public GameObject musicMneu, comingSoon, paymentWindow, wantToPayWindow, MainMenu, secondaryMenu, loadingScreen;

	// Use this for initialization
	void Start () {
        MainMenu.SetActive(true);
        secondaryMenu.SetActive(false);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
        loadingScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openMusicMenu()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(false);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(true);
    }

    public void closeMusicMenu()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(true);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }

    public void openComingSoon()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(false);
        comingSoon.SetActive(true);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }
    public void closeComingSoon()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(true);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }

    public void openPaymentWindow()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(false);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(true);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }

    public void closePaymentWindow()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(true);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }

    public void openWantToPayWindow()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(false);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(true);
        musicMneu.SetActive(false);
    }

    public void closeWantToPayWindow()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(true);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }

    public void openMainMenu()
    {
        MainMenu.SetActive(true);
        secondaryMenu.SetActive(false);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }
    public void closeMainMenu()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(true);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }
    public void openSecondaryMenu()
    {
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(true);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }
    public void closeSecondaryMenu()
    {
        secondaryMenu.SetActive(false);
    }

    public void StartGame()
    {
        openLoadingScreen();
        Application.LoadLevel("First");
    }

    public void openLoadingScreen()
    {
        loadingScreen.SetActive(true);
        MainMenu.SetActive(false);
        secondaryMenu.SetActive(false);
        comingSoon.SetActive(false);
        paymentWindow.SetActive(false);
        wantToPayWindow.SetActive(false);
        musicMneu.SetActive(false);
    }
}
