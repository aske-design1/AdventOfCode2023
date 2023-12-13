using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

public class Constant
{
    public const int maxValue = 30;
}

public class Record
{
    public int number;
    public int y;
}

public class Advent3
{

    public int lineAmount;
    public Record[] recordNum = new Record[Constant.maxValue];
    public int curNumInRecord;
    public int sum;
    public int charAmount;

    static int Main()
    {
        int sum;

        Advent3 instance = new Advent3();

        sum = instance.FindAnswer();

        Console.WriteLine("The total sum is: {0}", sum);
        return 0;
    }


    public int FindAnswer()
    {
        string file = @"C:\Users\Aske\source\repos\adventOfCode\advent3\input.txt";
        if (!File.Exists(file))
        {
            Console.WriteLine("File does not exist :{0} ", file);
        }

        string[] fullString = File.ReadAllLines(file);

        //Defined variables used in the program
        for (int i = 0; i < Constant.maxValue; i++)
        {
            recordNum[i] = new Record();
        }

        charAmount = fullString[0].Length;
        lineAmount = fullString.Length;
        int curLine = 0;
        curNumInRecord = 0;

        foreach (string line in fullString)
        {
            FindSpecialChar(line, fullString, curLine);
            curLine++;
        }

        return sum;
    }


    void FindSpecialChar(string line, string[] fullString, int currentLine)
    {
        int charAmount = 0;
        foreach (char character in line)
        {
            if (character == '*' || character == '/' || character == '#' ||
                    character == '@' || character == '$' || character == '%' ||
                    character == '&' || character == '+' || character == '=' )
            {

                sum += FindNumber2(character, currentLine, fullString);

            }
            charAmount++;
        }

    }

    void FindNumber(string line, string[] fullString, int curChar, int currentLine)
    {
        int digitCheck = 0;
        Record secNum = new Record();

        int k = Constant.maxValue - 1;
        if (recordNum[Constant.maxValue - 1].number == 0)
        {
            k = curNumInRecord;
        }
        
        if (currentLine == 0 || currentLine == lineAmount)
        {
            return;
        }
        else
        {

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    
                    
                    /*f (char.IsDigit(fullString[i + currentLine][j + curChar]) && digitCheck == 0)
                    {
                        recordNum[curNumInRecord].number = FindFullNumber(fullString[i + currentLine], curChar + j);
                        recordNum[curNumInRecord].y = i + currentLine;
                        digitCheck++;

                        sum += recordNum[curNumInRecord].number;
                        curNumInRecord = (curNumInRecord + 1) % Constant.maxValue;

                    }
                    else if (char.IsDigit(fullString[i + currentLine][j + curChar]) && digitCheck != 0)
                    {
                        secNum.number = FindFullNumber(fullString[i + currentLine], curChar + j);
                        secNum.y = i + currentLine;

                        while (k > 0)
                        {
                            if ((secNum.number != recordNum[k].number) && (secNum.y != recordNum[k].y))
                            {
                                curNumInRecord = (curNumInRecord + 1) % Constant.maxValue;

                                recordNum[curNumInRecord].number = secNum.number;
                                recordNum[curNumInRecord].y = secNum.y;

                                curNumInRecord = (curNumInRecord + 1) % Constant.maxValue;


                                sum += secNum.number;
                                break;
                                
                            }
                            k--;
                        }
                    }*/
                }
            }
        }

        int FindNumber2(char curChar, string curLine, string[] fullString)
        {
            if (char.IsDigit(fullString[currentLine - 1][curChar]))
            {

            }


        }

        int FindFullNumber(string line, int curChar)
        {
            int[] numArray = new int[3];
            int number = 0;
            int tempPlus = 0;
            int j = 0;


            while ((char.IsDigit(line[curChar + j])) && (j + curChar > 0))
            {
                j--;
            }
            j++;
            Console.WriteLine("ch after j is: {0}", line[curChar + j]);

            for (int i = 0; i < 4; i++)
            {
                if (curChar + i + j >= charAmount)
                {
                    break;
                }
                else if (char.IsDigit(line[curChar + i + j]))
                {
                    numArray[tempPlus] = line[curChar + i + j] - '0';

                    tempPlus++;
                }
            }

            if (tempPlus == 2)
            {
                number += numArray[0] * 10;
                number += numArray[1];

                Console.WriteLine("Number is: {0}", number);
                return number;
            }
            else if (tempPlus == 1)
            {
                Console.WriteLine("Number is: {0}", number);
                return numArray[0];
            }
            else if (tempPlus == 3)
            {
                number += numArray[0] * 100;
                number += numArray[1] * 10;
                number += numArray[2];

                Console.WriteLine("Number is: {0}", number);
                return number;
            }
            else if (tempPlus == 4) 
            {
                number += numArray[0] * 1000;
                number += numArray[1] * 100;
                number += numArray[2] * 10;
                number += numArray[3];

                Console.WriteLine("Number is: {0}", number);
                return number; 
            }
            else
            {
                Console.WriteLine("not a number being read \n");
                return 0;
            }
        }
    }
}
