using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class JsonWriter : MonoBehaviour
{
    public void UploadJson()
    {

        //serialization Json data into Json string
        string updatedJson = GlobalInstance.Instance.jsonData.ToString();

        //Todo: convert Json into YAML then upload OR do Git push operation
        //StartCoroutine(Upload(GlobalInstance.Instance.dt_id + "-json", updatedJson));
    }

    IEnumerator Upload(string dt_url, string newJson)
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(newJson);
        using (UnityWebRequest www = UnityWebRequest.Put(dt_url, myData))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
            }
        }
    }
}