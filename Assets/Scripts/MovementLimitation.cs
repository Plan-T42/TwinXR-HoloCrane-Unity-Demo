using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLimitation: MonoBehaviour
{
 
	public float minX =0;
	public float maxX = 0;
	public float minY = 0;
	public float maxY = 0;
	public float minZ = 0;
	public float maxZ = 0;

	void Update()
	{
		transform.localPosition = new Vector3(Mathf.Clamp(gameObject.transform.localPosition.x, minX, maxX),
										 	  Mathf.Clamp(gameObject.transform.localPosition.y, minY, maxY),
										 	  Mathf.Clamp(gameObject.transform.localPosition.z, minZ, maxZ));

	}

}
