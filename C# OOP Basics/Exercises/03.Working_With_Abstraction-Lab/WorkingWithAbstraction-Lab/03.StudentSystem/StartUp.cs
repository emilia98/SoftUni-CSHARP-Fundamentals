﻿using System;

namespace _03.StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();
            while (true)
            {
                studentSystem.ParseCommand();
            }
        }
    }
}