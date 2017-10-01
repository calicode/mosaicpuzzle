using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class PuzzlePiece : MonoBehaviour
{

    static List<Color> colorList = new List<Color>();

    static bool colorListGenerated = false;
    static string[] hexColors = new string[] { "F9A369", "BF1F44", "F57D27", "772954", "EB5260", "EF4023" };


    public static void GenerateColorList()
    {
        foreach (string hexColor in hexColors)
        {

            colorList.Add(ConvertHexCodeToColor32(hexColor));
        }

        colorListGenerated = true;


    }



    public static Color32 ConvertHexCodeToColor32(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);

    }


    Color PickRandomColor()
    {

        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);



    }


    // Use this for initialization
    void Start()
    {
        if (!PuzzlePiece.colorListGenerated)
        {
            PuzzlePiece.GenerateColorList();
        }
        GetComponent<SpriteRenderer>().color = colorList[Random.Range(0, colorList.Count)];

    }

    // Update is called once per frame
    void Update()
    {

    }




    // 


}
