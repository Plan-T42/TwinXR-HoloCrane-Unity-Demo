using System;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GlobalInstance : MonoBehaviour
{
    public static GlobalInstance Instance;

    public string dt_id;

    public JSONNode jsonData;

    //public HoloCraneDTJson DTJson;
    
    private void Awake()
    {
        // If Instance is not null (any time after the first time)
        // AND
        // If Instance is not 'this' (after the first time)
        if (Instance != null && Instance != this)
        {
            // ...then destroy the game object this script component is attached to.
            Destroy(gameObject);
        }
        else
        {
            // Tell Unity not to destory the GameObject this
            //  is attached to between scenes.
            DontDestroyOnLoad(gameObject);
            // Save an internal reference to the first instance of this class
            Instance = this;
        }

        //dt_id = "https://dtid.org/9239c7e4-8f96-449a-8f34-3e2d84cea4ff"; // MOVE TO QRCodesVisualizer.cs
        //dt_id = "https://dtid.org/d5657f92-ee00-4ca6-b124-f7b4261d87d4";
        //GameObject.Find("ReadfromServer").GetComponent<JsonReader>().GetJson(); // MOVE TO QRCodesVisualizer.cs

    }
}