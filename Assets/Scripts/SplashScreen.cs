using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    private CanvasGroup _splashScreen, _mainMenuScreen;
    private RectTransform _splashText;
    private bool _isTweening;
    public event EventHandler OnSplashScreenClickEvent;

    private void Awake()
    {
        _splashText   = GameObject.Find("SplashText").GetComponent<RectTransform>();
        _mainMenuScreen = GameObject.Find("MainMenu").AddComponent<CanvasGroup>();
        LeanTween.alphaCanvas(_mainMenuScreen, 0f, 0f);
        _splashScreen = gameObject.AddComponent<CanvasGroup>();
        _isTweening = true;
    }

    void Start()
    {
        OnSplashScreenClickEvent += SplashScreenMechanic;
        _mainMenuScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_isTweening)
        {
            LeanTween.colorText(_splashText, Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.time, 1f)), 0f);
            LeanTween.alphaText(_splashText, Mathf.PingPong(Time.time, 1f), 0f);
        }

        if (Input.anyKey || Input.GetMouseButton(1))
        {
            OnSplashScreenClickEvent?.Invoke(this, EventArgs.Empty);
            _isTweening = false;
            LeanTween.alphaText(_splashText, 0f, 0f);
        }
    }

    private void OnDisable()
    {
        LeanTween.cancelAll();
    }

    private void SplashScreenMechanic(object sender, EventArgs e)
    {
        LeanTween.alphaCanvas(_splashScreen, 0f, 1f);
        LeanTween.alphaCanvas(_mainMenuScreen, 1f, 1f).setDelay(1f);
        OnSplashScreenClickEvent -= SplashScreenMechanic;
        _mainMenuScreen.gameObject.SetActive(true);
    }
}
