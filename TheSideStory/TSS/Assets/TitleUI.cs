using UnityEngine;
using System.Collections;

public class TitleUI : MonoBehaviour {
	void OnGUI () {
		float WidthScale = 0.5f, HeightScale = 0.5F;
		float X = 0.5f, Y = 0.5f;
		float sW = Screen.width;
		float sH = Screen.height;
		float x = X*sW;
		float y = Y*sH;
		float displayW = sW*WidthScale, displayH = sH*HeightScale;
		Rect titleRect = new Rect(x-displayW/2, y-displayH/2, displayW, displayH); 
		// Make a background box
		GUI.Box(titleRect , "THE SIDE STORY");


		WidthScale = 0.5f;
		HeightScale = 0.5f;
		X = 0.5f;
		Y = 0.5f;
		sW = Screen.width;
		sH = Screen.height;
		x = X*sW;
		y = Y*sH;
		displayW = sW*WidthScale;
		displayH = sH*HeightScale;
		Rect playBtnRect = new Rect(x-displayW/2, y-displayH/2, displayW, displayH);
		// Make the second button.
		if(GUI.Button(playBtnRect, ""/*PlayBtn*/, GUIStyle.none)) {
			Application.LoadLevel("core");
		}
	}
}