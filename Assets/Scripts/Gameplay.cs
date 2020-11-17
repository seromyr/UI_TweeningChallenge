using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    private RectTransform _backToMain;
    private Button _backToMainBtn;
    private GameObject _mainMenu;

    private void Awake()
    {
        _backToMain = GameObject.Find("GameplayScreenPanelButton").GetComponent<RectTransform>();
        _mainMenu = GameObject.Find("MainMenu");
        _backToMain.gameObject.AddComponent<CanvasGroup>();
        _backToMainBtn = _backToMain.gameObject.GetComponent<Button>();
        _backToMainBtn.onClick.AddListener(ReturnToMain);
    }

    private void Start()
    {
        LeanTween.alphaCanvas(_backToMain.gameObject.GetComponent<CanvasGroup>(), 0f, 0f);
    }

    private void OnEnable()
    {
        LeanTween.alphaCanvas(_backToMain.gameObject.GetComponent<CanvasGroup>(), 1f, 0.5f).setDelay(1f);
    }

    private void OnDisable()
    {
        LeanTween.alphaCanvas(_backToMain.gameObject.GetComponent<CanvasGroup>(), 0f, 0f);
    }

    private void ReturnToMain()
    {
        _mainMenu.SetActive(false);
        _mainMenu.SetActive(true);
        LeanTween.alphaCanvas(_backToMain.gameObject.GetComponent<CanvasGroup>(), 0f, 1f);
    }

}
