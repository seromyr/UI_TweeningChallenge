using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    CanvasGroup _mainMenuScreen, _quitBtnYesCG, _quitBtnNoCG;
    private RectTransform _mainMenuPlay, _mainMenuContinue, _mainMenuOptions, _mainMenuAbout, _mainMenuQuit, _mainMenuSubPanel, _quitBtnYes, _quitBtnNo;

    private Vector3 _playBtnIn, _playBtnOut, _contBtnIn, _contBtnOut, _optBtnIn, _optBtnOut, _abtBtnIn, _abtBtnOut, _quitBtnIn, _quitBtnOut;
    private Vector2 _mainMenuSubPanelSize;

    private Text _mainMenuSubPanelText;
    private string[] quitText;
    private int currentTextID;

    private void Awake()
    {
        _mainMenuPlay           = GameObject.Find("MainMenuPlay")       .GetComponent<RectTransform>();
        _mainMenuContinue       = GameObject.Find("MainMenuContinue")   .GetComponent<RectTransform>();
        _mainMenuOptions        = GameObject.Find("MainMenuOptions")    .GetComponent<RectTransform>();
        _mainMenuAbout          = GameObject.Find("MainMenuAbout")      .GetComponent<RectTransform>();
        _mainMenuQuit           = GameObject.Find("MainMenuQuit")       .GetComponent<RectTransform>();
        _mainMenuSubPanel       = GameObject.Find("MainMenuSubPanel")   .GetComponent<RectTransform>();
        _mainMenuSubPanelText   = _mainMenuSubPanel.GetComponentInChildren<Text>();
        _quitBtnYes             = GameObject.Find("QuitButtonYes")      .GetComponent<RectTransform>();
        _quitBtnNo              = GameObject.Find("QuitButtonNo")       .GetComponent<RectTransform>();

        _quitBtnYesCG           = _quitBtnYes.gameObject                .AddComponent<CanvasGroup>();
        _quitBtnNoCG            = _quitBtnNo.gameObject                 .AddComponent<CanvasGroup>();

        _playBtnOut = _mainMenuPlay.transform.position = new Vector3(-300, _mainMenuPlay.gameObject.transform.position.y, _mainMenuPlay.gameObject.transform.position.z);
        _contBtnOut = _mainMenuContinue.transform.position = new Vector3(-300, _mainMenuContinue.gameObject.transform.position.y, _mainMenuContinue.gameObject.transform.position.z);
        _optBtnOut = _mainMenuOptions.transform.position = new Vector3(-300, _mainMenuOptions.gameObject.transform.position.y, _mainMenuOptions.gameObject.transform.position.z);
        _abtBtnOut = _mainMenuAbout.transform.position = new Vector3(-300, _mainMenuAbout.gameObject.transform.position.y, _mainMenuAbout.gameObject.transform.position.z);
        _quitBtnOut = _mainMenuQuit.transform.position = new Vector3(-300, _mainMenuQuit.gameObject.transform.position.y, _mainMenuQuit.gameObject.transform.position.z);

        _playBtnIn = _playBtnOut + new Vector3(364, 0, 0);
        _contBtnIn = _contBtnOut + new Vector3(364, 0, 0);
        _optBtnIn = _optBtnOut + new Vector3(364, 0, 0);
        _abtBtnIn = _abtBtnOut + new Vector3(364, 0, 0);
        _quitBtnIn = _quitBtnOut + new Vector3(364, 0, 0);

        _mainMenuSubPanelSize = _mainMenuSubPanel.rect.size;

        quitText = new string[]
        {
            "\nAre you sure you want to quit?\n\nCome on. There's nothing out there.",
            "\nAre you sure you want to quit?\n\nPlease don't do this. I need your presence.",
            "\nAre you sure you want to quit?\n\nEvery second you stay here, Facebook will give you 1 cent.",
            "\nAre you sure you want to quit?\n\nYou will receive the money when you accumulated $10 million.",
            "\nAre you sure you want to quit?\n\nHow about I give you a cake?",
            "\nAre you sure you want to quit?\n\nIt's so delicious and moist.",
            "\nAre you sure you want to quit?\n\nThere's no sense in quitting.",
            "\nAre you sure you want to quit?\n\nPlease stay, for the sake of humanity.",
            "\nAre you sure you want to quit?\n\nHow do I live without you?",
        };

        currentTextID = 0;
    }

    private void Start()
    {
        _mainMenuScreen = GetComponent<CanvasGroup>();

        _mainMenuPlay.gameObject.GetComponent<Button>().onClick.AddListener(Play);
        _mainMenuContinue.gameObject.GetComponent<Button>().onClick.AddListener(Continue);
        _mainMenuOptions.gameObject.GetComponent<Button>().onClick.AddListener(Settings);
        _mainMenuAbout.gameObject.GetComponent<Button>().onClick.AddListener(About);
        _mainMenuQuit.gameObject.GetComponent<Button>().onClick.AddListener(Quit);

        _quitBtnYes.gameObject.GetComponent<Button>().onClick.AddListener(QuitYes);
        _quitBtnNo.gameObject.GetComponent<Button>().onClick.AddListener(QuitNo);

        LeanTween.cancelAll(); // Cancel on OnEnable
        LeanTween.size(_mainMenuSubPanel, new Vector2(_mainMenuSubPanelSize.x, 0f), 0f);

        LeanTween.alphaCanvas(_quitBtnYesCG, 0f, 0f);
        LeanTween.alphaCanvas(_quitBtnNoCG, 0f, 0f);
    }

    private void OnEnable()
    {
        _mainMenuSubPanelText.text = "Hello! Please click a button";
        LeanTween.textAlpha(_mainMenuSubPanelText.gameObject.GetComponent<RectTransform>(), 1f, 0.5f);
        LeanTween.alphaCanvas(_mainMenuScreen, 1f, 1f).setDelay(1.0f);
        LeanTween.move(_mainMenuPlay.gameObject, _playBtnIn, 0.9f).setEase(LeanTweenType.easeOutQuad).setDelay(2.0f);
        LeanTween.move(_mainMenuContinue.gameObject, _contBtnIn, 0.8f).setEase(LeanTweenType.easeOutQuad).setDelay(2.1f);
        LeanTween.move(_mainMenuOptions.gameObject, _optBtnIn, 0.7f).setEase(LeanTweenType.easeOutQuad).setDelay(2.2f);
        LeanTween.move(_mainMenuAbout.gameObject, _abtBtnIn, 0.6f).setEase(LeanTweenType.easeOutQuad).setDelay(2.3f);
        LeanTween.move(_mainMenuQuit.gameObject, _quitBtnIn, 0.5f).setEase(LeanTweenType.easeOutQuad).setDelay(2.4f);
        LeanTween.size(_mainMenuSubPanel, _mainMenuSubPanelSize, 1f).setDelay(2.5f);
    }

    private void OnDisable()
    {
        LeanTween.alphaCanvas(_mainMenuScreen, 0f, 0f);
        LeanTween.move(_mainMenuPlay.gameObject, _playBtnOut, 0f);
        LeanTween.move(_mainMenuContinue.gameObject, _contBtnOut, 0f);
        LeanTween.move(_mainMenuOptions.gameObject, _optBtnOut, 0f);
        LeanTween.move(_mainMenuAbout.gameObject, _abtBtnOut, 0f);
        LeanTween.move(_mainMenuQuit.gameObject, _quitBtnOut, 0f);
    }

    private void Play()
    {
        LeanTween.cancelAll();
        DeactivateQuitYesNoBtns();


        LeanTween.size(_mainMenuSubPanel, new Vector2(_mainMenuSubPanelSize.x, 0f), 0.5f);
        _mainMenuSubPanelText.alignment = TextAnchor.MiddleCenter;
        _mainMenuSubPanelText.text = "You clicked Play Button"; ;

        LeanTween.move(_mainMenuPlay        .gameObject, _playBtnOut , 0.9f).setEase(LeanTweenType.easeOutQuad).setDelay(0.3f);
        LeanTween.move(_mainMenuContinue    .gameObject, _contBtnOut , 0.8f).setEase(LeanTweenType.easeOutQuad).setDelay(0.4f);
        LeanTween.move(_mainMenuOptions     .gameObject, _optBtnOut  , 0.7f).setEase(LeanTweenType.easeOutQuad).setDelay(0.5f);
        LeanTween.move(_mainMenuAbout       .gameObject, _abtBtnOut  , 0.6f).setEase(LeanTweenType.easeOutQuad).setDelay(0.6f);
        LeanTween.move(_mainMenuQuit        .gameObject, _quitBtnOut , 0.5f).setEase(LeanTweenType.easeOutQuad).setDelay(0.7f);

        LeanTween.alphaCanvas(_mainMenuScreen, 0f, 0.5f).setDelay(1f);
    }

    private void Continue()
    {
        LeanTween.cancelAll();
        DeactivateQuitYesNoBtns();

        LeanTween.size(_mainMenuSubPanel, _mainMenuSubPanelSize, 0.5f);
        LeanTween.textAlpha(_mainMenuSubPanelText.gameObject.GetComponent<RectTransform>(), 1f, 0f);
        _mainMenuSubPanelText.alignment = TextAnchor.MiddleCenter;
        _mainMenuSubPanelText.text = "You clicked Continue Button";

    }
    private void Settings()
    {
        LeanTween.cancelAll();
        DeactivateQuitYesNoBtns();

        LeanTween.size(_mainMenuSubPanel, _mainMenuSubPanelSize, 0.5f);
        LeanTween.textAlpha(_mainMenuSubPanelText.gameObject.GetComponent<RectTransform>(), 1f, 0f);
        _mainMenuSubPanelText.alignment = TextAnchor.MiddleCenter;
        _mainMenuSubPanelText.text = "You clicked Settings Button";
    }
    private void About()
    {
        LeanTween.cancelAll();
        DeactivateQuitYesNoBtns();

        LeanTween.size(_mainMenuSubPanel, _mainMenuSubPanelSize, 0.5f);
        LeanTween.textAlpha(_mainMenuSubPanelText.gameObject.GetComponent<RectTransform>(), 0f, 0f);
        LeanTween.textAlpha(_mainMenuSubPanelText.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setDelay(0.6f);

        _mainMenuSubPanelText.alignment = TextAnchor.UpperCenter;
        _mainMenuSubPanelText.text = "\nAbout\n\n\nLEAN TWEEN MENU DEMO\n\nversion 0.1\n\nLead Programmer\nBuu Nguyen";

    }

    private void Quit()
    {
        LeanTween.cancelAll();

        LeanTween.size(_mainMenuSubPanel, new Vector2(_mainMenuSubPanelSize.x, _mainMenuSubPanelSize.y / 2), 0.5f);
        LeanTween.textAlpha(_mainMenuSubPanelText.gameObject.GetComponent<RectTransform>(), 0f, 0f);
        LeanTween.textAlpha(_mainMenuSubPanelText.gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setDelay(0.6f);

        _mainMenuSubPanelText.alignment = TextAnchor.UpperCenter;
        _mainMenuSubPanelText.text = "\nAre you sure you want to quit?\n\nPlease don't quit.";

        LeanTween.alphaCanvas(_quitBtnYesCG, 1f, 0.5f).setDelay(1f);
        LeanTween.alphaCanvas(_quitBtnNoCG, 1f, 0.5f).setDelay(1f);
    }

    private void QuitYes()
    {
        currentTextID = (currentTextID + 1) % quitText.Length;
        _mainMenuSubPanelText.text = quitText[currentTextID];
    }

    private void QuitNo()
    {
        _mainMenuSubPanelText.text = "Please click a button"; ;
        _mainMenuSubPanelText.alignment = TextAnchor.MiddleCenter;
        LeanTween.size(_mainMenuSubPanel, _mainMenuSubPanelSize, 0.5f);

        DeactivateQuitYesNoBtns();
    }

    private void DeactivateQuitYesNoBtns()
    {
        LeanTween.alphaCanvas(_quitBtnYesCG, 0f, 0f);
        LeanTween.alphaCanvas(_quitBtnNoCG, 0f, 0f);
    }
}