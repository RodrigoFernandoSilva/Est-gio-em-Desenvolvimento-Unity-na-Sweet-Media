using UnityEngine;

using UnityEngine.UI;
using System.Text.RegularExpressions;

public class BirthDateInputField : MonoBehaviour {

    private InputField _myInputField;

    private string _lastStr;

    private void Awake() {
        _myInputField = GetComponent<InputField>();
    }

    public void ApplyMask() {
        if (_lastStr != _myInputField.text) {
            if (_myInputField.text.Length > 10) {
                _myInputField.text = _lastStr;
            }

            //Permite somente números, não foi setado isso direto no inputfiled pois o quando o script vai color o "/" da erro caso o inputfield
            //esta aceitando somente números.
            string strResult = Regex.Replace(_myInputField.text, @"\W|\D", "");
            int caretPosition = _myInputField.caretPosition;

            //Como na linha acima é tirado tudo aquilo que não é um número, é preciso mover o cursor no inputfield caso tenha
            //sido tirado alguma letra antes da posição que ele esta.
            for (int i = 0; i < _myInputField.caretPosition; i++) {
                if (Regex.IsMatch(_myInputField.text[i].ToString(), @"[^\d]")) {
                    caretPosition--;
                }
            }

            //Adiciona as / na data.
            for (int i = 2; i < strResult.Length && i < 6; i+=3) {
                strResult = strResult.Insert(i, "/");
                if (caretPosition > i)
                    caretPosition++;
            }

            _lastStr = strResult;
            _myInputField.text = strResult;
            _myInputField.caretPosition = caretPosition;
        }
    }
}
