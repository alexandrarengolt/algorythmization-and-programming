using System;
using System.IO;
namespace lab
{
    class Program
    {
        static void Main()
        {
            string inputPath = "C:\\Users\\Александра\\Desktop\\АиП\\input_lab.txt";
            string outputPath = "C:\\Users\\Александра\\Desktop\\АиП\\output_lab.txt";

            FileInfo fileInfo = new FileInfo(inputPath);
            StreamReader readerStream = fileInfo.OpenText();
            string line;
            int totalLines = 0;
            int currentLineNumber = 0;
            string numberString = "";
            bool isNumberCollected = false;

            TextReader countingReader = new StreamReader(inputPath);
            while ((line = countingReader.ReadLine()) != null)
            {
                totalLines++;
            }
            countingReader.Close();
          
            for (var i = 0; i < totalLines; i++)
            {
                line = readerStream.ReadLine();
                Console.WriteLine(line);
                foreach (var symbol in line)
                {
                    if (char.IsDigit(symbol))
                    {
                        numberString += symbol;
                        currentLineNumber = Convert.ToInt32(numberString);
                        isNumberCollected = true;
                    }
                    else if (char.IsLetter(symbol))
                    {
                        if (isNumberCollected)
                        {
                            if (currentLineNumber % 2 == 0)
                            {
                                File.AppendAllText(outputPath, line + Environment.NewLine);
                            }
                            numberString = "";
                            currentLineNumber = 0;
                            isNumberCollected = false;
                        }
                    }
                }
                if (isNumberCollected)
                {
                    currentLineNumber = Convert.ToInt32(numberString);
                    if (currentLineNumber % 2 == 0)
                    {
                        File.AppendAllText(outputPath, line + Environment.NewLine);
                    }
                    numberString = "";
                    currentLineNumber = 0;
                    isNumberCollected = false;
                }
                Console.WriteLine(numberString);
                numberString = "";
            }
            readerStream.Close();
        }
    }
}
