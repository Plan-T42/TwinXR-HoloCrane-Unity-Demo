using System.Collections;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;


public class JsonReader : MonoBehaviour
{
    // public HoloCraneDTJson jsonObj;

    public void GetJson()
    {
        //string dt_id = GlobalInstance.Instance.dt_id;         
        Debug.Log("DT id: " + GlobalInstance.Instance.dt_id);

        string dt_url = GlobalInstance.Instance.dt_id + "-json";
        Debug.Log("DT url: " + dt_url);

        Debug.Log("get JSON Data!");
        StartCoroutine(GetRequest(dt_url));
    }

    IEnumerator GetRequest(string dt_url)
    {
        using (UnityWebRequest webData = UnityWebRequest.Get(dt_url))
        {

            yield return webData.SendWebRequest();
            Debug.Log("response Code: " + webData.responseCode);

            if (webData.result == UnityWebRequest.Result.ConnectionError || webData.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("ERROR: " + webData.error);
                //webData_id.redirectLimit = 0;
                //Debug.Log("response Code: " + webData_id.responseCode);
                //Debug.Log("redirect limit: " + webData_id.redirectLimit);
            }
            else
            {
                if (webData.isDone)
                {
                    string jsonString = System.Text.Encoding.UTF8.GetString(webData.downloadHandler.data);

                    //deserialize Json string
                    GlobalInstance.Instance.jsonData = JSON.Parse(jsonString);
                    // GlobalInstance.Instance.DTJson = JsonUtility.FromJson<HoloCraneDTJson>(jsonString);


                    if (GlobalInstance.Instance.jsonData == null)
                    {
                        Debug.Log("NO DATA");
                    }
                    else
                    {
                        Debug.Log("Got DATA");
                        //Debug.Log("jsonData.Count:" + jsonData.Count);
                        GameObject.Find("DTDashboard").GetComponent<DTDashboard>().ShowDT();
                        GameObject.Find("MovableTarget").GetComponent<MoveableTarget>().UpdateTargetLocationbyDTDoc();
                        GameObject.Find("SafetyZone").GetComponent<SafetyZone>().UpdatesafetyZonebyDTDoc();

                    }
                }
            }
            
        }
    }
}
