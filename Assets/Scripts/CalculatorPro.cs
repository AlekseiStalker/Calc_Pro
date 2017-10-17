using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorPro : MonoBehaviour
{
    public InputField inPut;
    public Text polish;
    public Text answer;

    public void AnswerClick()
    {
        PolishNotation ob = new PolishNotation();
        string polska = ob.Transform(inPut.text);
        polish.text = polska;

        Calculator ob2 = new Calculator();
        int res = ob2.Result(polska);
        answer.text = res.ToString();
    }
    class PolishNotation
    {
        Stack<char> stack;
        string input;
        string output;

        int OldPrior = 0;
        public PolishNotation()
        {
            stack = new Stack<char>();
            input = "";
            output = "";
        }

        public string Transform(string str)//2+(5+4)*2 перед этим добавить switch и сразу записывать в стек
        {
            input = str;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                    case '-':
                        GetPriority(input[i], 1);
                        break;
                    case '*':
                    case '/':
                        GetPriority(input[i], 2);
                        break;
                    case '(':
                        orderStack(input[i]);
                        break;
                    case ')':
                        orderStack(input[i]);
                        break;
                    default:
                        output += input[i];
                        break;
                }
            }
            while (stack.Count != 0)
            {
                output += stack.Pop();
            }
            return output;
        }
        private void orderStack(char symb)
        {
            if (symb == '(') stack.Push(symb);
            else
            {
                char s;
                do
                {
                    s = stack.Pop();
                    if (s != '(')
                        output += s;
                } while (s != '(');
            }
        }
        private void GetPriority(char symb, int prior)
        {
            if (OldPrior >= prior && stack.Count != 0)
            {
                char buf = stack.Pop();
                if (buf == '(')
                {
                    stack.Push('(');
                    stack.Push(symb);
                    OldPrior = prior;
                }
                else
                {
                    output += buf;
                    if (prior == 1)
                    {
                        if (LastSymb(output[output.Length -1]))
                        {
                            output += stack.Pop();
                        } 
                    }
                    stack.Push(symb);
                    OldPrior = prior;
                }
            }
            else
            {
                stack.Push(symb);
                OldPrior = prior;
            }
        }
        bool LastSymb(char symb)
        {
            if (symb >= 42 && symb <= 47) 
                return false; 
            else
                return true;
        }
    }
    class Calculator
    {
        Stack<int> stack;
        string input;
        string output;

        public Calculator()
        {
            stack = new Stack<int>();
            input = "";
            output = "";
        }

        public int Result(string str)//3+3*(2-1)+12/(2-2*2)
        {
            input = str;
            int num1;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case '-':
                        num1 = stack.Pop();
                        stack.Push(stack.Pop() - num1);
                        break;
                    case '*':
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case '/':
                        num1 = stack.Pop();
                        stack.Push(stack.Pop() / num1);
                        break;
                    default:
                        stack.Push((int)(input[i] - '0'));
                        break;
                }
            }
            return stack.Pop();
        }
    }
}
