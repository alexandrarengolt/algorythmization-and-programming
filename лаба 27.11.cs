using System.ComponentModel.DataAnnotations;

// void ArrayPrinting(int[] arr) {
//   Console.WriteLine("--- Вывод массива ---");
//   for(int i = 0; i < arr.Length; i++) {
//       Console.WriteLine(arr[i]);
//   }
// }


// // Задание 1
// string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
// string line = Console.ReadLine().ToUpper();
// int[] charactersCount = new int[26];

// for (int i = 1; i < line.Length - 1; i++)
// {
// 	if (line[i - 1] == 'A' && line[i + 1] == 'B')
// 	{
// 		charactersCount[char.ToUpper(line[i]) - 65]++;
// 	}
// }


// int maxElement = -100;
// int maxIndex = 0;
// for (int i = 0; i < charactersCount.Length; i++)
// {
// 	if (charactersCount[i] > maxElement)
// 	{
// 		maxElement = charactersCount[i];
// 		maxIndex = i;
// 	}
// }

// Console.WriteLine("---");
// Console.WriteLine(alphabet[maxIndex]);


// Задание 2

void CheckString(string str)
{
	string fixedLine = str.ToLower();
	fixedLine = fixedLine.Replace("abc", "3");
	fixedLine = fixedLine.Replace("ab", "2");
	fixedLine = fixedLine.Replace("a", "1");

	int MaxLength = -10000; 
	int TempLength = 0;
	bool isUsed = false;
	for (int i = 0; i < fixedLine.Length; i++)
	{
		if(isUsed)
		{
			MaxLength = Math.Max(MaxLength, TempLength);
			TempLength = 0;
			isUsed = false;
		}

		switch (fixedLine[i])
		{
			case '3':
				TempLength += 3;
				break;
			case '2':
				TempLength += 2;
				isUsed = true;
				break;
			case '1':
				TempLength += 1;
				isUsed = true;
				break;
			default:
				MaxLength = Math.Max(MaxLength, TempLength);
				TempLength = 0;
				break;
		}
	}

	MaxLength = Math.Max(MaxLength, TempLength);
	Console.WriteLine(MaxLength);
}

// string line = Console.ReadLine();
// CheckString(line)

string[] line = ["ababab", "abcaba", "aababc", "abcabc", "abcabca", "abcabcab", "abcabcc", "ccaabcbcababcabc"]; // 2, 5, 3, 6, 7, 8, 6, 6
for (int i = 0; i < line.Length; i++)
{
	CheckString(line[i]);
}
