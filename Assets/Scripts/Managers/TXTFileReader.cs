using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TXTFileReader
{
    public static List<string> GetStrings(TextAsset textAsset)
    {
        return textAsset.text.Split('\n').ToList();
    }
}
