using System.Collections.Generic;
using UnityEngine;

//This Class is to read the Words from the Txt files
public class WordsManager : MonoBehaviour
{
    public static WordsManager Instance;
    [SerializeField] TextAsset validWordsTextAsset;
    [SerializeField] TextAsset correctGuessWordsTextAsset;

    List<string> validWords;
    List<string> correctGuessWords;

    void Awake()
    {
        Instance = this;
        LoadFiles();
    }

    void LoadFiles()
    {
        validWords = TXTFileReader.GetStrings(validWordsTextAsset);
        correctGuessWords = TXTFileReader.GetStrings(correctGuessWordsTextAsset);
    }

    //Check if the word is in the dictionary
    public bool CheckIsWordValid(string word)
    {
        return validWords.Contains(word) || correctGuessWords.Contains(word);
    }

    //Get a random word for the game
    public string GetRandomWord()
    {
        return correctGuessWords[Random.Range(0, correctGuessWords.Count)];
    }
}
