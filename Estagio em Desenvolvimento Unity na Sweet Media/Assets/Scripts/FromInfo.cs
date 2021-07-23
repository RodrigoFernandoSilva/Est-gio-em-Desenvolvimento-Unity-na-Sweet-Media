using UnityEngine;

using System;
using UnityEngine.UI;

public class FromInfo : MonoBehaviour {

    [SerializeField]
    private InputField _name;
    [SerializeField]
    private InputField _email;
    [SerializeField]
    private InputField _birthDate;

    public string strModelo;

    public void Submit() {
        if (string.IsNullOrEmpty(_name.text)) {
            PopupController.instance.ShowPopupMessage("Digite um nome.");
        } else if (string.IsNullOrEmpty(_email.text)) {
            PopupController.instance.ShowPopupMessage("Digite um email.");
        } else if (!ValidadeInfo.ValidadeEmail(_email.text)) {
            PopupController.instance.ShowPopupMessage("Email invalido.");
        } else if (string.IsNullOrEmpty(_birthDate.text)) {
            PopupController.instance.ShowPopupMessage("Digite uma data de nascimento.");
        } else if (!ValidadeInfo.ValidadeBirthDate(_birthDate.text)) {
            PopupController.instance.ShowPopupMessage("Data de nascimento invalida.");
        } else {
            PopupController.instance.ShowPopupJustText("Carregando");
            //ApiServerToolBox.instance.SubmitForm("Rodrigo", "Rodrigo Fernando da Silva", "Batata@hotmail.com", "09/10/1998", SubmitCallBack);
            ApiServerToolBox.instance.SubmitForm(_name.text.Split(' ')[0].Trim().ToLower(), _name.text.Trim(), _email.text.Trim(), _birthDate.text, SubmitCallBack);
        }
    }

    public void SubmitCallBack(string strValue, ApiException apiEx) {
        if (apiEx == null) {
            FormReturn formReturn = JsonUtility.FromJson<FormReturn>(strValue);

            if (formReturn.success) {
                PopupController.instance.ShowPopupMessage(formReturn.data.message);
            } else {
                switch ((int)ApiServerToolBox.apiNoSucessReturn[formReturn.status]) {
                    case 0: //nome completo vazaio.
                        PopupController.instance.ShowPopupMessage("Nome não digitado.");
                        break;
                    case 1: //Email vazio.
                        PopupController.instance.ShowPopupMessage("Email não digitado.");
                        break;
                    case 2: //Data de nascimento vazia.
                        PopupController.instance.ShowPopupMessage("Data de nascimento não digitada.");
                        break;
                    default:
                        PopupController.instance.ShowPopupMessage("Erro, tente novamente mais tarde.");
                        break;
                }
            }
        } else {
            Debug.LogError("ErrorCode: " + apiEx.ErrorCode + ", " + apiEx.Message);
        }
    }
}

[System.Serializable]
public class FormReturn {

    public bool success;
    public string status;
    public DataReturn data;
}

[System.Serializable]
public class DataReturn {

    public string message;
}
