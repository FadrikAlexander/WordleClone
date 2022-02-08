using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDataStore : MonoBehaviour
{
    [SerializeField] Color wrongLetterColor;
    [SerializeField] Color letterInWordColor;
    [SerializeField] Color letterInRightPlaceColor;

    static Color _wrongLetterColor;
    static Color _letterInWordColor;
    static Color _letterInRightPlaceColor;

    private void Awake()
    {
        _wrongLetterColor = wrongLetterColor;
        _letterInWordColor = letterInWordColor;
        _letterInRightPlaceColor = letterInRightPlaceColor;
    }

    public static Color GetWrongLetterColor() { return _wrongLetterColor; }
    public static Color GetLetterInWordColor() { return _letterInWordColor; }
    public static Color GetLetterInRightPlaceColor() { return _letterInRightPlaceColor; }
}
