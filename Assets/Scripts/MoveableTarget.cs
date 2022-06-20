using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class MoveableTarget : MonoBehaviour
{

    public TextMeshPro TargetBridgeLocText = null;
    public TextMeshPro TargetTrolleyLocText = null;
    public TextMeshPro TargetHoistLocText = null;

    private void Update()
    {
        TargetBridgeLocText.text = (Math.Round(this.gameObject.transform.localPosition.x + 11487)).ToString();
        TargetTrolleyLocText.text = (Math.Round(this.gameObject.transform.localPosition.z + 10679)).ToString();
        TargetHoistLocText.text = (Math.Round(this.gameObject.transform.localPosition.y - 2127)).ToString();
    }

    public void UpdateTargetLocationInDTDoc()
    {
        // Update target location in Json data node
        GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["bridge"] = Math.Round(this.gameObject.transform.localPosition.x + 11487);
        GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["trolley"] = Math.Round(this.gameObject.transform.localPosition.z + 10679);
        GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["hoist"] = Math.Round(this.gameObject.transform.localPosition.y - 2127);

        GameObject.Find("DTDashboard").GetComponent<DTDashboard>().ShowDT();
    }

    public void UpdateTargetLocationbyDTDoc()
    {
        var x = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["bridge"] - 11487;
        var z = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["trolley"] - 10679;
        var y = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["targetLocation"]["hoist"] + 2127;
        transform.localPosition = new Vector3(x, y, z);
    }

}
