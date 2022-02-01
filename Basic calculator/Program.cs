using System;
using System.Collections.Generic;

namespace Basic_calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      string s = "3*2*2";
      Console.WriteLine(p.Calculate(s));
    }
    public int Calculate(string s)
    {
      int currentNumber = 0;
      char opert = '+';
      Stack<int> stack = new Stack<int>();
      var charArray = s.ToCharArray();
      for (int i = 0; i < charArray.Length; i++)
      {
        char c = charArray[i];
        if (char.IsDigit(c))
        {
          currentNumber = 10 * currentNumber + c - '0';
        }

        if ((!char.IsDigit(c) && c != ' ') || i == charArray.Length - 1)
        {

          if (opert == '+')
            stack.Push(currentNumber);
          else if (opert == '-')
            stack.Push(-currentNumber);
          else if (opert == '*')
            stack.Push(stack.Pop()*currentNumber);
          else if (opert == '/')
            stack.Push(stack.Pop() / currentNumber);
          opert = c;
          currentNumber = 0;
        }
      }

      int sum = 0;
      while (stack.Count > 0)
      {
        sum += stack.Pop();
      }

      return sum;
    }
  }
}
