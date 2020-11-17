using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private RectTransform _backToMain;
    private Vector3 _backToMainIn, _backToMainOut;

    private void Awake()
    {
        _backToMain = GameObject.Find("GameplayScreenPanelButton").GetComponent<RectTransform>();

        _backToMainOut = _backToMain.position;
        _backToMainIn = _backToMainOut + new Vector3(0, _backToMain.position.y + 128, 0);
    }

    private void Start()
    {
        LeanTween.cancelAll();
    }

    private void OnEnable()
    {
        LeanTween.move(_backToMain.gameObject, _backToMainIn, 0.5f);
    }

    private void OnDisable()
    {
        LeanTween.move(_backToMain.gameObject, _backToMainOut, 0f);
    }
}
