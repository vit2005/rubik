using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Generate
{
public class GenerateKey : MonoBehaviour 
{

static public string CreatingTrash (string generate) 
{
List<string> Trash = new List<string>();

Trash.Add("q");
Trash.Add("w");
Trash.Add("e");
Trash.Add("r");
Trash.Add("t");
Trash.Add("y");
Trash.Add("u");
Trash.Add("i");
Trash.Add("o");
Trash.Add("p");
Trash.Add("a");
Trash.Add("s");
Trash.Add("d");
Trash.Add("f");
Trash.Add("g");
Trash.Add("h");
Trash.Add("j");
Trash.Add("k");
Trash.Add("l");
Trash.Add("z");
Trash.Add("x");
Trash.Add("c");
Trash.Add("v");
Trash.Add("b");
Trash.Add("n");
Trash.Add("m");

Trash.Add("Q");
Trash.Add("W");
Trash.Add("E");
Trash.Add("R");
Trash.Add("T");
Trash.Add("Y");
Trash.Add("U");
Trash.Add("I");
Trash.Add("O");
Trash.Add("P");
Trash.Add("A");
Trash.Add("S");
Trash.Add("D");
Trash.Add("F");
Trash.Add("G");
Trash.Add("H");
Trash.Add("J");
Trash.Add("K");
Trash.Add("L");
Trash.Add("Z");
Trash.Add("X");
Trash.Add("C");
Trash.Add("V");
Trash.Add("B");
Trash.Add("N");
Trash.Add("M");

Trash.Add("1");
Trash.Add("2");
Trash.Add("3");
Trash.Add("4");
Trash.Add("5");
Trash.Add("6");
Trash.Add("7");
Trash.Add("8");
Trash.Add("9");
Trash.Add("0");
Trash.Add("=");
Trash.Add("-");

string solt1="";
string solt2="";

for(int i = 0 ; i < 3 ; i++)
{
solt1+=Trash[Random.Range(0,Trash.Count)];
}

for(int j = 0 ; j < 4 ; j++)
{
solt2+=Trash[Random.Range(0,Trash.Count)];				
}

return solt1+generate+solt2;

		
		
}

	
	
}

}
