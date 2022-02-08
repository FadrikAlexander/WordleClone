using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] float time = 2;
    private void OnEnable()
    {
        Invoke("Disable", time);
    }

    void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
