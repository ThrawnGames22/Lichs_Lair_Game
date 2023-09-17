using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTexts : MonoBehaviour
{

    public GameObject[] LoadingTextObjects;

    public GameObject ChosenText;
    // Start is called before the first frame update
    void Start()
    {
        ChosenText = LoadingTextObjects[Random.Range(0, LoadingTextObjects.Length)];
        ChosenText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
