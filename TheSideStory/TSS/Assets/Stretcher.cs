using UnityEngine;
using System.Collections;

public class Stretcher : MonoBehaviour {

	// GUI Position and SIZE by PERCENT!
	public float X,Y,WidthScale,HeightScale;
	public bool centered = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float sW = Screen.width;
		float sH = Screen.height;
		float x = X*sW;
		float y = Y*sH;

		x = (centered)? -(WidthScale*sW/2) + x: x;
		y = (centered)?-(HeightScale*sH/2) + y: y;
		guiTexture.pixelInset = new Rect(x, y, sW*WidthScale, sH*HeightScale);
	}
}
