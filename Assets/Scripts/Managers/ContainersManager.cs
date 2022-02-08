using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainersManager : MonoBehaviour
{
    [SerializeField] List<WordContainerController> wordContainersList;
    int currentContainerIndex = 0;
    int currentLetterIndex = 0;

    public void MoveToNextTry()
    {
        currentLetterIndex = 0;
        currentContainerIndex++;
    }

    public void ClearContainers()
    {
        currentContainerIndex = 0;
        currentLetterIndex = 0;

        foreach (var v in wordContainersList)
            v.ClearContainer();
    }

    public void SetLetterContainersInRightPlaceColor()
    {
        for (int i = 0; i < 5; i++)
        {
            SetLetterContainerInRightPlaceColor(i);
        }
    }

    public void AddContainerLetter(string letter)
    {
        wordContainersList[currentContainerIndex].SetLetterContainerText(currentLetterIndex, letter.ToUpper());
        currentLetterIndex++;
    }
    public void DeleteLastLetterContainer()
    {
        currentLetterIndex--;
        wordContainersList[currentContainerIndex].SetLetterContainerText(currentLetterIndex, "");
    }

    public void SetLetterContainerInRightPlaceColor(int index)
    {
        wordContainersList[currentContainerIndex].SetLetterContainerColor(index, ColorDataStore.GetLetterInRightPlaceColor());
    }
    public void SetLetterContainerInWordColor(int index)
    {
        wordContainersList[currentContainerIndex].SetLetterContainerColor(index, ColorDataStore.GetLetterInWordColor());
    }
}
