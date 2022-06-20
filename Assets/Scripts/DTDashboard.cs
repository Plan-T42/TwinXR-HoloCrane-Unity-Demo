using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DTDashboard : MonoBehaviour
{
    public TMP_Text nameTXT;
    public TMP_Text descriptionTXT;
    public TMP_Text ownerTXT;
    public TMP_Text locationTXT;
    public TMP_Text targetTXT;

    public void ShowDT()
    {
        Debug.Log("Show DT doc Data in the dashboard");

        nameTXT.text = "Name: " + GlobalInstance.Instance.jsonData["name"];
        Debug.Log("name: " + GlobalInstance.Instance.jsonData["name"]);

        descriptionTXT.text = "Desciption: " + GlobalInstance.Instance.jsonData["description"];
        Debug.Log("desciption: " + GlobalInstance.Instance.jsonData["description"]);

        ownerTXT.text = "Owner: " + GlobalInstance.Instance.jsonData["owner"]["name"];
        Debug.Log("owner name: " + GlobalInstance.Instance.jsonData["owner"]["name"]);

        locationTXT.text = "Location: " + GlobalInstance.Instance.jsonData["location"]["streetAddress"];
        Debug.Log("location: " + GlobalInstance.Instance.jsonData["location"]["streetAddress"]);

        targetTXT.text = "Target location: " + "( "
            + GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["bridge"] 
            + ", " + GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["trolley"] 
            + ", " + GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["hoist"] + " )";
    }
}


