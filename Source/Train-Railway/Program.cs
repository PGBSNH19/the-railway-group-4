﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager file = new FileManager();
            file.ReadingFile(file.passengers);
        }
    }
}
