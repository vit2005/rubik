using UnityEngine;
using System.Collections.Generic;

public class StartGame : MonoBehaviour 
{
		private  Vector3      i;               // Настройки экрана и позиций 
		private  float        center;
		private  float        up;

		public Texture2D[] text;

		public List<float> English;
		public List<float> Russian;
		public List<float> Ukrainian;


		void Awake () 
		{
				center   = Screen.width  / (Screen.height / 720.0f)/2;
				up       = Screen.height / (Screen.height / 720.0f)/2;
				i.x      = Screen.height / 720.0f;
				i.y      = Screen.height / 720.0f;
				i.z      = 1;

				if(PlayerPrefs.GetString ("languages")!="")
				{
						Application.LoadLevel("log_In");
				}
				English = new List<float>(){ 96, 308, 192, 192 };
				Russian = new List<float>(){ 96, 96, 192, 192 };
				Ukrainian = new List<float>(){ -96, -116, 192, 192 };
		}

		void OnGUI()
		{
				GUI.matrix             = Matrix4x4.Scale(i);
				GUIStyle style         = GUI.skin.GetStyle ("button");

				style.normal.background = text [0];
				style.hover .background = text [0];
				style.active.background = text [0];

				if(GUI.Button(new Rect(center-English[0],up-English[1],English[2],English[3]),""))
				{	
						PlayerPrefs.SetString ("languages","English");
						Application.LoadLevel("log_In");		
				}

				style.normal.background = text [1];
				style.hover .background = text [1];
				style.active.background = text [1];

				if(GUI.Button(new Rect(center-Russian[0],up-Russian[1],Russian[2],Russian[3]),""))
				{	
						PlayerPrefs.SetString ("languages","Russian");			
						Application.LoadLevel("log_In");		
				}

				style.normal.background = text [2];
				style.hover .background = text [2];
				style.active.background = text [2];

				if(GUI.Button(new Rect(center+Ukrainian[0],up-Ukrainian[1],Ukrainian[2],Ukrainian[3]),""))
				{	
						PlayerPrefs.SetString ("languages","Ukrainian");			
						Application.LoadLevel("log_In");		
				}




		}


}
