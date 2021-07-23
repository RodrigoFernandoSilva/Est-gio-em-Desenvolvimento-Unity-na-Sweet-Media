using System;
using System.Collections;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class ApiServerToolBox : MonoBehaviour {

    public static ApiServerToolBox instance;

    private const string _FIRST_NAME_STR = "SEU_PRIMEIRO_NOME";
    private const string _FULL_NAME_STR = "NOME_COMPLETO_DO_FORMULARIO";
    private const string _EMAIL_STR = "EMAIL_DO_FORMULARIO";
    private const string _BIRTH_DATE_STR = "DATA_NASCIMENTO_DO_FORMULARIO";
    protected const string _BASE_PATH = "https://sweetbonus.com.br/sweet-juice/trainee-test/submit?candidate={SEU_PRIMEIRO_NOME}&fullname={NOME_COMPLETO_DO_FORMULARIO}&email={EMAIL_DO_FORMULARIO}&birthdate={DATA_NASCIMENTO_DO_FORMULARIO}";

    public static readonly JObject apiNoSucessReturn = new JObject {
        {"empty_fullname", 0 },
        {"empty_email", 1 },
        {"empty_birthdate", 2 }
    };

    private void Awake() {
        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitForm(string firstName, string fullName, string email, string birthDate, Action<string, ApiException> callBAck) {
        string requestPath = _BASE_PATH;

        requestPath.Replace(_FIRST_NAME_STR, firstName.ToLower());
        requestPath.Replace(_FULL_NAME_STR, fullName);
        requestPath.Replace(_EMAIL_STR, email);
        requestPath.Replace(_BIRTH_DATE_STR, birthDate);

        StartCoroutine(RequestForm2Server(requestPath, callBAck));
    }

    public IEnumerator RequestForm2Server (string requestPath, Action<string, ApiException> callBack) {
        UnityWebRequest www;
        www = UnityWebRequest.Get(requestPath);
        yield return www.SendWebRequest();

        try {
            if (www.isNetworkError) {
                throw new ApiException(1, "Internet problem");
            } else if (www.isHttpError) {
                throw new ApiException(404, "Not Found");
            }

            callBack(www.downloadHandler.text, null);
        } catch (ApiException apiEx) {
            callBack(www.downloadHandler.text, apiEx);
        }
    }
}
