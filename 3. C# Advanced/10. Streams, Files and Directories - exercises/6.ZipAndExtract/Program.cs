﻿using System;
using System.IO.Compression;

namespace _6.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\ZipFileDemo1", 
                @"D:\ZipFileDemo2\myZipFile.zip");
        }
    }
}
