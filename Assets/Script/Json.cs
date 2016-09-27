using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JsonSerialize_DESerialize
{

public  class Json 
{
	private static string  _serializedString;
	private static JSONObject _serializedObject;

	private static List<string> _list;
	private static string[]     _array;
	private static Dictionary<string,int> _dictionaryStrInt;



	public static string SerializeList(List<string> LST)
{
		_serializedObject = new JSONObject (JSONObject.Type.ARRAY);
		foreach (string s in LST)
		{
			_serializedObject.Add(s);
		
		}
		return _serializedObject.ToString ();


}

	public static string SerializeStringIndDictionary(Dictionary <string, string> DICT )

	{
		_serializedObject = new JSONObject (JSONObject.Type.OBJECT);
		foreach (string Key in DICT.Keys) 
		{
		_serializedObject.AddField(Key.ToString(),DICT[Key].ToString());		
		}
		return _serializedObject.ToString ();
	}






	public static List<string> DeSerializeStringList(string JSON )
		
	{
		
		_serializedObject = new JSONObject (JSON);
		_list = new List<string> () {};

		if (_serializedObject.type != JSONObject.Type.NULL) 
		{
		foreach (JSONObject s in _serializedObject.list) 
			{
				_list.Add (s.str);
			}
		}

		return _list;
	}




	public static Dictionary <string,int> DeSearializeStringIntDict (string JSON)
	{
		_dictionaryStrInt = new Dictionary<string, int> ();

		JSONObject jsonCharInfo = new JSONObject (JSON);
		for(int i=0; i< jsonCharInfo.list.Count; i++)
		{
		string key = (string) jsonCharInfo.keys[i];
		JSONObject j = (JSONObject)jsonCharInfo.list[i];
		int sValue = int.Parse(j.str);
		_dictionaryStrInt[key] = sValue;
		}
		return _dictionaryStrInt;
	 }


}

}
























