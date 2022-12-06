using System;
using System.Collections.Generic;

namespace Basic_calculator
{
  // https://www.youtube.com/watch?v=HUfUzA9Ekgo
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      string s = "-312+-1-(-3+1+(+8--1)-1)+-2"; // -312-(-1)-(-3+1+(-8-(-1))-1)-(-2) valid inout based on leetcode
      Console.WriteLine(p.Calculate(s));
    }
    public int Calculate(string s)
    {
      Stack<int> stack = new Stack<int>();
      int sum = 0;
      int sign = 1;
      for (int i = 0; i < s.Length; i++)
      {
        char c = s[i];
        if (char.IsDigit(c))
        {
          int number = 0;
          while(i < s.Length && char.IsDigit(s[i]))
          {
            number = 10 * number + (s[i] - '0');
            i++;
          }
          i--;
          number = number * sign;
          sign = 1;
          sum += number;
        }
        else if (c == '-')
        {
          sign *= -1;
        }
        else if (c == '(')
        {
          //we push the result first, then sign;
          stack.Push(sum);
          stack.Push(sign);
          //reset the sign and result for the value in the parenthesis
          sign = 1;
          sum = 0;
        }
        else if (c == ')')
        {
          sum *= stack.Pop();    //stack.pop() is the sign before the parenthesis
          sum += stack.Pop();   //stack.pop() now is the result calculated before the parenthesis
        }
      }
      return sum;
    }
  }
}
