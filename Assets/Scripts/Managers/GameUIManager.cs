using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject NotEnoughLettersUIobject;
    [SerializeField] GameObject NotInListUIobject;
    [SerializeField] GameObject GameWonUIobject;
    [SerializeField] GameObject GameLostUIobject;
    [SerializeField] TextMeshProUGUI GameLostText;



    public void ShowNotEnoughLettersUIobject()
    {
        NotEnoughLettersUIobject.SetActive(true);
    }
    public void ShowNotInListUIobject()
    {
        NotInListUIobject.SetActive(true);
    }
    public void ShowGameWonUIobject()
    {
        GameWonUIobject.SetActive(true);
    }
    public void ShowGameLostUIobject(string word)
    {
        GameLostText.text = "Word: " + word;
        GameLostUIobject.SetActive(true);
    }

}
