using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Popup : MonoBehaviour {

    [SerializeField]
    private Text _text;

    public void ShowMySelft() {
        gameObject.SetActive(true);
    }
    public void HideMySelft() {
        gameObject.SetActive(false);
    }

    public string TextValue {
        set {
            _text.text = value;
        }
    }

    public void ClosePopup() {
        PopupController.instance.ClosePopup();
    }
}
