using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PopupController : MonoBehaviour {

    public static PopupController instance;

    [SerializeField]
    private Popup[] _popups;

    private int _lastPopup;

    private void Awake() {
        instance = this;

        _popups = GetComponentsInChildren<Popup>(true);
    }

    public void ShowPopupMessage(string message) {
        ShowPopup(0, message);
    }

    public void ShowPopupJustText(string text) {
        ShowPopup(1, text);
    }

    public void ShowPopup(int indice, string message = "") {
        _popups[_lastPopup].HideMySelft();
        _popups[indice].ShowMySelft();
        _popups[indice].TextValue = message;
        _lastPopup = indice;
    }

    public void ClosePopup() {
        _popups[_lastPopup].HideMySelft();
    }
}
