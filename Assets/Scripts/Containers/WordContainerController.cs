using System.Collections.Generic;
using UnityEngine;

//This class to control the word container in each row
public class WordContainerController : MonoBehaviour
{
    [SerializeField] List<LetterContainerController> lettersList;

    void Awake() => ClearContainer();

    public void SetLetterContainerColor(int containerId, Color color)
    {
        lettersList[containerId].SetContainerColor(color);
    }
    public void SetLetterContainerText(int containerId, string letter)
    {
        lettersList[containerId].SetContainerText(letter);
    }
    public void ClearContainer()
    {
        foreach (var v in lettersList)
            v.ClearContainer();
    }
}
