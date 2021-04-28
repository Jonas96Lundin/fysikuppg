using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class studsYta : MonoBehaviour
{
    public float studskoefficient = 1;
    public float friktionskoefficient = 1;

    [SerializeField]
    string type;
    [SerializeField]
    Text friktionskoefficientText;
    [SerializeField]
    Text studskoefficientText;
    private void Start()
    {
        friktionskoefficientText.text += "\n" + type + " Friktionskoefficient " + friktionskoefficient;
        studskoefficientText.text += "\n" + type + " Studskoefficient " + studskoefficient;
    }
}
