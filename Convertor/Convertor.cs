using System;
using System.Collections.Generic;
using System.Text;

namespace Convertor
{
    public class Convertor
    {
        // Check if a character is an operator, including '^' for exponentiation
        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        // Define operator precedence, with '^' having the highest precedence
        private int Precedence(char c)
        {
            if (c == '+' || c == '-') return 1;
            if (c == '*' || c == '/') return 2;
            if (c == '^') return 3; // Highest precedence for exponentiation
            return -1;
        }

        // Check if an operator is right-associative; only '^' is right-associative
        private bool IsRightAssociative(char c)
        {
            return c == '^';
        }

        // Convert infix expression to postfix
        public string InfixToPostfix(string expression)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder result = new StringBuilder();
            int i = 0;

            while (i < expression.Length)
            {
                char c = expression[i];

                // Handle multi-digit numbers
                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        number.Append(expression[i]);
                        i++;
                    }

                    result.Append(number + " ");
                    continue;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        result.Append(stack.Pop() + " ");
                    }

                    stack.Pop(); // Pop '('
                }
                else if (IsOperator(c))
                {
                    while (stack.Count > 0 &&
                           (Precedence(c) < Precedence(stack.Peek()) ||
                            (Precedence(c) == Precedence(stack.Peek()) && !IsRightAssociative(c))))
                    {
                        result.Append(stack.Pop() + " ");
                    }

                    stack.Push(c);
                }

                i++;
            }

            while (stack.Count > 0)
            {
                result.Append(stack.Pop() + " ");
            }

            return result.ToString().Trim();
        }

        // Convert infix expression to prefix
        public string InfixToPrefix(string expression)
        {
            string reversedInfix = Reverse(expression);
            string modifiedInfix = ReplaceBrackets(reversedInfix);
            string postfix = InfixToPostfix(modifiedInfix);
            string prefix = Reverse(postfix);

            return prefix;
        }

        // Convert postfix expression to infix
        public string PostfixToInfix(string expression)
        {
            Stack<string> stack = new Stack<string>();
            int i = 0;

            while (i < expression.Length)
            {
                char c = expression[i];

                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        number.Append(expression[i]);
                        i++;
                    }

                    stack.Push(number.ToString());
                    continue;
                }
                else if (IsOperator(c))
                {
                    try
                    {
                        string operand2 = stack.Pop();
                        string operand1 = stack.Pop();
                        string newExpr = $"({operand1} {c} {operand2})";
                        stack.Push(newExpr);
                    }
                    catch
                    {
                        /* Skip on error */
                    }
                }

                i++;
            }

            try
            {
                return stack.Pop();
            }
            catch
            {
                return "Error: Invalid Expression";
            }
        }

        // Convert prefix expression to infix
        public string PrefixToInfix(string expression)
        {
            Stack<string> stack = new Stack<string>();
            int i = expression.Length - 1;

            while (i >= 0)
            {
                char c = expression[i];

                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i >= 0 && char.IsDigit(expression[i]))
                    {
                        number.Insert(0, expression[i]);
                        i--;
                    }

                    stack.Push(number.ToString());
                    continue;
                }
                else if (IsOperator(c))
                {
                    try
                    {
                        string operand1 = stack.Pop();
                        string operand2 = stack.Pop();
                        string newExpr = $"({operand1} {c} {operand2})";
                        stack.Push(newExpr);
                    }
                    catch
                    {
                        /* Skip on error */
                    }
                }

                i--;
            }

            try
            {
                return stack.Pop();
            }
            catch
            {
                return "Error: Invalid Expression";
            }
        }

        // Evaluate infix expression by converting it to postfix and then evaluating it
        public double EvaluateInfix(string expression)
        {
            string postfix = InfixToPostfix(expression);
            return EvaluatePostfix(postfix);
        }

        // Evaluate a postfix expression
        public double EvaluatePostfix(string expression)
        {
            Stack<double> stack = new Stack<double>();
            int i = 0;

            while (i < expression.Length)
            {
                char c = expression[i];

                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        number.Append(expression[i]);
                        i++;
                    }

                    stack.Push(double.Parse(number.ToString()));
                    continue;
                }
                else if (IsOperator(c))
                {
                    try
                    {
                        double operand2 = stack.Pop();
                        double operand1 = stack.Pop();

                        switch (c)
                        {
                            case '+':
                                stack.Push(operand1 + operand2);
                                break;
                            case '-':
                                stack.Push(operand1 - operand2);
                                break;
                            case '*':
                                stack.Push(operand1 * operand2);
                                break;
                            case '/':
                                stack.Push(operand1 / operand2);
                                break;
                            case '^':
                                stack.Push(Math.Pow(operand1, operand2));
                                break; // Exponentiation
                        }
                    }
                    catch
                    {
                        throw new InvalidOperationException("Invalid Expression");
                    }
                }

                i++;
            }

            return stack.Pop();
        }

        public double EvaluatePrefix(string expression)
        {
            Stack<double> stack = new Stack<double>();
            int i = expression.Length - 1;

            while (i >= 0)
            {
                char c = expression[i];

                if (char.IsDigit(c))
                {
                    StringBuilder number = new StringBuilder();
                    while (i >= 0 && char.IsDigit(expression[i]))
                    {
                        number.Insert(0, expression[i]);
                        i--;
                    }

                    stack.Push(double.Parse(number.ToString()));
                    continue;
                }
                else if (IsOperator(c))
                {
                    try
                    {
                        double operand1 = stack.Pop();
                        double operand2 = stack.Pop();

                        switch (c)
                        {
                            case '+':
                                stack.Push(operand1 + operand2);
                                break;
                            case '-':
                                stack.Push(operand1 - operand2);
                                break;
                            case '*':
                                stack.Push(operand1 * operand2);
                                break;
                            case '/':
                                stack.Push(operand1 / operand2);
                                break;
                            case '^':
                                stack.Push(Math.Pow(operand1, operand2));
                                break; // Exponentiation
                        }
                    }
                    catch
                    {
                        throw new InvalidOperationException("Invalid Expression");
                    }
                }

                i--;
            }

            return stack.Pop();
        }

        private string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private string ReplaceBrackets(string expression)
        {
            StringBuilder modifiedExpression = new StringBuilder(expression.Length);
            foreach (char c in expression)
            {
                if (c == '(')
                    modifiedExpression.Append(')');
                else if (c == ')')
                    modifiedExpression.Append('(');
                else
                    modifiedExpression.Append(c);
            }

            return modifiedExpression.ToString();
        }
    }
}