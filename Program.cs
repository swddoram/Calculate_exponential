using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;

namespace MathProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int digit = 10001; // 배열의 크기, 즉 자릿수
            int[] Result = new int[digit];
            int Number = 2000; // 항의 개수, 시그마의 n값
            for (int k = 0; k < Number; k++)
            {
                FactorialInverse(k, digit);
                Plus(Result, FactorialInverse(k, digit), Result, digit);
            }
            Write(Result);
        }

        static int[] FactorialInverse(int Num, int digit)
        {
            int[] Temp = new int[digit]; // 임시 배열
            Temp[0] = 1; // 임시 배열 값 1로 초기화
            for (int i = 1; i < Num + 1; i++)
            {
                Divide(Temp, i, Temp, digit);
            }
            return Temp;
        }

        static int Factorial(int Num, int digit)
        {
            int Num2 = 1;
            int[] Temp = new int[digit];
            Temp[0] = 1;
            int[] Result = new int[digit];
            for (int i = 1; i < Num + 1; i++)
            {
                Num2 *= i;
            }
            Divide(Temp, Num2, Result, digit);
            return Num2;
        }



        static void Write(int[] a)
        {
            foreach (int num in a)
            {
                Console.Write(num);
            }

        }


        static void Plus(int[] a, int[] b, int[] des, int digit)
        {
            int[] temp = new int[digit]; // 임시 배열

            for (int count = digit - 1; count >= 0; count--)
            {
                temp[count] += a[count] + b[count]; // a와 b의 해당 자릿수의 합을 임시 배열에 저장

                if (temp[count] > 9 && count != 0)
                {
                    temp[count] -= 10; // 두 수의 합이 10 이상인 경우 10을 빼고 다음 자릿수에 1을 더함
                    temp[count - 1]++;
                }
            }

            Array.Copy(temp, des, digit); // 결과를 복사
        }



        static void Divide(int[] array, int n, int[] dest, int digit)
        {
            int[] temp = new int[digit]; // 임시 배열
            int num = 0;

            for (int i = 0; i != digit - 1; i++)
            {
                num = num * 10 + array[i]; // 이전 숫자와 현재 숫자를 합쳐서 새로운 수를 만듦
                temp[i] = num / n; // 나눈 몫을 임시 배열에 저장
                num %= n; // 나눈 나머지를 다음 숫자로 사용
            }

            Array.Copy(temp, dest, digit); // 결과를 복사
        }

    }

}

