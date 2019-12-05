using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;


[Serializable]
public class DBEntry
{
    public int tecnicaDeNavegacao;
    public bool jaJogouJogosParecidosAntes;
    public int satisfacao;
    public int jogoPrecisaDeMaisInstrucoes;
    public int jogoPrecisaDeMenosInstrucoes;
}

public class WebServerConnection
{

    IEnumerator UploadToDatabase(DBEntry entry){
        string json = JsonUtility.ToJson(entry);

        UnityWebRequest www = UnityWebRequest.Put("https://us-central1-projetofinalihc.cloudfunctions.net/uploadToDatabase", json);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
