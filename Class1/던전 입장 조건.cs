﻿using System;
class Program
{
    static void Main(string[] args)
    {
        //던전 입장 프로그램 구현
        //1. 두 개의 조건을 다 만족하는 입장 조건 A $$ B
        //2. 두개의 조건 중 하나라도 만족하는 조건 A || B
        Console.WriteLine("레벨을 입력하세요.");
        int Level = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("보유한 열쇠 개수를 입력하세요.");
        int key = Convert.ToInt32(Console.ReadLine());
        if (Level >= 30 && key >= 2)
        {
            Console.Write("던전에 입장하였습니다.");
        }
        else if (Level >= 30 || key <= 1)
        {
            Console.Write("열쇠가 부족합니다.");
        }
        else if (Level <= 29 || key >= 2)
        {
            Console.Write("레벨이 부족합니다.");
        }
    }
}

 