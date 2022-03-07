using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemBnew
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words_to_numbers = new Dictionary<string, int>();
            string input = string.Empty;
            int number;
            List<int> numbers = new List<int>();
            int noInputCount = 0;
            Console.WriteLine("Please write a command!");
            while (true)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    var inputs = input.Split(" ");
                    if (input.Contains("clear"))
                    {
                        words_to_numbers.Clear();
                    }
                    else
                    {
                        if (input.Contains("def"))
                        {
                            number = int.Parse(inputs[2]);
                            if (!words_to_numbers.ContainsKey(inputs[1]))
                            {
                                words_to_numbers.Add(inputs[1], number);
                            }
                            else
                            {
                                words_to_numbers[inputs[1]] = number;
                            }
                        }

                        else
                        {
                            if (inputs[0] == "calc")
                            {
                                var unsplit = input.Substring(5, input.Length - 5);
                                var expression = input.Substring(5, input.Length - 7).Split(' ');
                                var sum = 0;

                                for (var i = 0; i < expression.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        if (!words_to_numbers.ContainsKey(expression[i]))
                                        {
                                            sum = int.MinValue;
                                        }
                                        else
                                        {
                                            sum += words_to_numbers[expression[i]];
                                        }
                                    }

                                    if (sum != int.MinValue)
                                    {
                                        if (expression[i] == "+")
                                            if (!words_to_numbers.ContainsKey(expression[i + 1]))
                                            {
                                                sum = int.MinValue;
                                            }
                                            else
                                            {
                                                sum += words_to_numbers[expression[i + 1]];
                                                i++;
                                            }

                                        else
                                          if (expression[i] == "-")
                                            if (!words_to_numbers.ContainsKey(expression[i + 1]))
                                            {
                                                sum = int.MinValue;
                                            }
                                            else
                                            {
                                                sum -= words_to_numbers[expression[i + 1]];
                                                i++;
                                            }
                                    }
                                }


                                if (words_to_numbers.ContainsValue(sum))
                                {
                                    Console.WriteLine(unsplit + " " + words_to_numbers.FirstOrDefault(w => w.Value == sum).Key);
                                }
                                else
                                {
                                    Console.WriteLine(unsplit + " " + "unknown");
                                }

                            }

                            else
                            {
                                Console.WriteLine("Your input is not valid, please check your command again.");

                            }

                        }
                    }
                }
                else
                {
                    noInputCount++;
                    Console.WriteLine($"No Input! count {noInputCount}");
                    if (noInputCount > 2)
                    {
                        Environment.Exit(0);
                    }
                }
            }

            Console.ReadLine();

        }

    }


}
