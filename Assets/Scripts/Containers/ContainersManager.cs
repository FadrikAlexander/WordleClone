using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainersManager : MonoBehaviour
{
    [SerializeField] List<WordContainerController> wordContainersList;
    int currentWordIndex = 0;
    int currentLetterIndex = 0;

    public void MoveToNextContainer()
    {
        currentLetterIndex = 0;
        currentWordIndex++;
    }

    public void ClearContainers()
    {
        currentWordIndex = 0;
        currentLetterIndex = 0;

        foreach (var v in wordContainersList)
            v.ClearContainer();
    }

    public void SetLetterContainersInRightPlaceColor()
    {
        for (int i = 0; i < 5; i++)
            SetLetterContainerColor(i, ColorDataStore.GetLetterInRightPlaceColor());
    }

    public void AddContainerLetter(string letter)
    {
        wordContainersList[currentWordIndex].SetLetterContainerText(currentLetterIndex, letter.ToUpper());
        currentLetterIndex++;
    }
    public void DeleteLastLetterContainer()
    {
        currentLetterIndex--;
        wordContainersList[currentWordIndex].SetLetterContainerText(currentLetterIndex, "");
    }

    public void SetLetterContainerColor(int index, Color color)
    {
        wordContainersList[currentWordIndex].SetLetterContainerColor(index, color);
    }
}
