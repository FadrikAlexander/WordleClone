using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //added [SerializeField] to be able to see the word in the inspector
    [SerializeField] string winningWord;
    string currentWord = "";

    bool isGameEnded = false;
    int tries = 6;

    WordsManager wordsManager;
    GameUIManager gameUIManager;
    ContainersManager containersManager;

    #region Game Controls
    private void Start()
    {
        Instance = this;

        wordsManager = FindObjectOfType<WordsManager>();
        gameUIManager = FindObjectOfType<GameUIManager>();
        containersManager = FindObjectOfType<ContainersManager>();

        StartGame();
    }

    void StartGame()
    {
        isGameEnded = false;

        winningWord = wordsManager.GetRandomWord();
        containersManager.ClearContainers();

        tries = 6;
        currentWord = "";
        isGameEnded = false;
    }

    public void ResetGame()
    {
        if (isGameEnded)
            StartGame();
    }

    void MoveToNextTry()
    {
        containersManager.MoveToNextTry();

        for (int i = 0; i < 5; i++)
        {
            if (IsLetterInRightPlace(i))
                containersManager.SetLetterContainerInRightPlaceColor(i);
            else
            if (IsLetterInWord(i))
                containersManager.SetLetterContainerInWordColor(i);
        }

        currentWord = "";
        tries--; //Move to the next Try
        if (tries == 0)
            GameLost();
    }

    //Called when the game is won
    void GameWon()
    {
        isGameEnded = true;
        gameUIManager.ShowGameWonUIobject();
        containersManager.SetLetterContainersInRightPlaceColor();
    }

    //Called when the game is lost and all tries are depleted
    void GameLost()
    {
        isGameEnded = true;
        gameUIManager.ShowGameLostUIobject(winningWord);
    }
    #endregion

    #region Word Manipulation
    public void DeleteLetter()
    {
        if (isGameEnded) return;

        if (currentWord.Length > 0)
        {
            currentWord = currentWord.Remove(currentWord.Length - 1);
            containersManager.DeleteLastLetterContainer();
        }
    }

    public void SubmitWord()
    {
        if (isGameEnded) return;

        //Word is less than 5 letters
        if (currentWord.Length < 5)
        {
            gameUIManager.ShowNotEnoughLettersUIobject();
            return;
        }

        //Word is not valid
        if (!wordsManager.CheckIsWordValid(currentWord))
        {
            gameUIManager.ShowNotInListUIobject();
            return;
        }

        if (currentWord == winningWord)
            GameWon();
        else
            MoveToNextTry();
    }

    public void AddLetter(string letter)
    {
        if (isGameEnded) return;

        if (currentWord.Length < 5)
        {
            letter = letter.ToLower();
            currentWord += letter;
            containersManager.AddContainerLetter(letter);
        }
    }
    public bool IsLetterInRightPlace(int index)
    {
        return currentWord[index] == winningWord[index];
    }
    public bool IsLetterInWord(int index)
    {
        return winningWord.Contains(currentWord[index].ToString());
    }
    #endregion
}
