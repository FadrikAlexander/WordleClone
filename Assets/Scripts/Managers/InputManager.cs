using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    private List<KeyCode> validkeyCodes = new List<KeyCode>
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
    };

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
                DeleteLetter();
            else
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                SubmitWord();
            else
            if (Input.GetKeyDown(KeyCode.Space))
                ResetGame();
            else
                foreach (KeyCode keyCode in validkeyCodes)
                    if (Input.GetKeyDown(keyCode))
                    {
                        AddLetter(keyCode.ToString());
                        break;
                    }
        }
    }

    void DeleteLetter() => GameManager.Instance.DeleteLetter();
    void ResetGame() => GameManager.Instance.ResetGame();
    void SubmitWord() => GameManager.Instance.SubmitWord();
    void AddLetter(string letter) => GameManager.Instance.AddLetter(letter);
}
