using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Set to true of you want the Daily word to be fixed until the next day
    [SerializeField] bool isDaily = false;


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

        //Set the Random seed to today's date
        //Which means each day will have a single word
        if (isDaily) Random.InitState(System.DateTime.Today.ToString().GetHashCode());

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
        for (int i = 0; i < 5; i++)
        {
            if (IsLetterInRightPlace(i))
                containersManager.SetLetterContainerColor(i, ColorDataStore.GetLetterInRightPlaceColor());
            else
            if (IsLetterInWord(i))
                containersManager.SetLetterContainerColor(i, ColorDataStore.GetLetterInWordColor());
        }

        containersManager.MoveToNextContainer();

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
