using System;
using System.Collections.Generic;

namespace Basic_calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      string s = "(1+(4+5+2)-3)+(6+8)";
      Console.WriteLine(p.Calculate(s));
    }
    public int Calculate(string s)
    {
      Stack<int> stack = new Stack<int>();
      int result = 0;
      int number = 0;
      int sign = 1;
      for (int i = 0; i < s.Length; i++)
      {
        char c = s[i];
        if (char.IsDigit(c))
        {
          number = 10 * number + (c - '0');
        }
        else if (c == '+')
        {
          result += sign * number;
          number = 0;
          sign = 1;
        }
        else if (c == '-')
        {
          result += sign * number;
          number = 0;
          sign = -1;
        }
        else if (c == '(')
        {
          //we push the result first, then sign;
          stack.Push(result);
          stack.Push(sign);
          //reset the sign and result for the value in the parenthesis
          sign = 1;
          result = 0;
        }
        else if (c == ')')
        {
          result += sign * number;
          number = 0;
          result *= stack.Pop();    //stack.pop() is the sign before the parenthesis
          result += stack.Pop();   //stack.pop() now is the result calculated before the parenthesis

        }
      }
      if (number != 0) result += sign * number;
      return result;
    }
  }
}
