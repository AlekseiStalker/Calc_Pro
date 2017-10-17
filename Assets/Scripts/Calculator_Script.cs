using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator_Script : MonoBehaviour
{
    public delegate void MyDel(float a, float b);
    private MyDel AllMetod = null;

    public Text outPut;
    public Text currOper;

    private float value1, value2;
    //узнать почему пропскает вторую опереацию. Напр 1+1 + (пропускает)
    public void ButtonClick(int symb)
    {
        if (symb >= 0 && symb <= 9)
        {
            outPut.text += symb;
            return;
        }
        else if (symb == 10)
        { goto LOL; }

        if (AllMetod != null)
        {
            value2 = float.Parse(outPut.text);
            currOper.text = "";
            AllMetod(value1,value2);
            AllMetod = null;
            if (10 < symb && symb < 15)
            {
                outPut.text = "";
                goto LOL;
            }
            return;
        }
        value1 = float.Parse(outPut.text);
        outPut.text = "";

        LOL:
        switch (symb)
        {
            case 10:
                outPut.text += '.';
                return;
            case 11:
                currOper.text = "*";
                AllMetod = Multy;
                return;
            case 12:
                currOper.text += "/";
                AllMetod = Div;
                return;
            case 13:
                currOper.text += "+";
                AllMetod = Add;
                return;
            case 14:
                currOper.text = "-";
                AllMetod = Deduct;
                return;
            case 15:
                currOper.text = "";
                outPut.text = value1.ToString();
                return;
            default: Debug.Log("Что-то пошло не так.");
                return;
        }
    }
    private void Add(float a, float b)
    {
        value1 = a + b;
        outPut.text = value1.ToString();
    }
    private void Deduct(float a, float b)
    {
        value1 = a - b;
        outPut.text = value1.ToString();
    }
    private void Multy(float a, float b)
    {
        value1 = a * b;
        outPut.text = value1.ToString();
    }
    private void Div(float a, float b)
    {
        value1 = a / b;
        outPut.text = value1.ToString();
    }
    public void Clear()
    {
        value1 = 0;
        value2 = 0;
        outPut.text = "";
        currOper.text = "";
    }

} 

