using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyZone : MonoBehaviour
{

    public void UpdatesafetyZonebyDTDoc()
    {
        var x = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["bridge"][1]
            - GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["bridge"][0];
        var z = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["trolley"][1]
            - GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["trolley"][0];
        var y = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["hoist"][1]
            - GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["hoist"][0];
        transform.localScale = new Vector3(x, y, z);

        var x_ = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["bridge"][0] - 6789;
        var z_ = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["trolley"][0] - 5817;
        var y_ = GlobalInstance.Instance.jsonData["features"][6]["parameters"]["controlParameters"]["safetyZone"]["hoist"][0] + 4157;
        transform.localPosition = new Vector3(x_, y_, z_);
    }
}
