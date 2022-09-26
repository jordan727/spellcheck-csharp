// Spell-Check by Jordan Antonio

#nullable disable

using System.Text.RegularExpressions;

// Load data files into arrays
String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
String[] aliceWords = Regex.Split(aliceText, @"\s+");

// Print first 50 values of each list to verify contents
Console.WriteLine("***DICTIONARY***");
printStringArray(dictionary, 0, 50);

Console.WriteLine("***ALICE WORDS***");
printStringArray(aliceWords, 0, 50);

void printStringArray(String[] array, int start, int stop) {
    // Print out array elements at index values from start to stop 
    for (int i = start; i < stop; i++) {
      Console.WriteLine(array[i]);
    }
}

// Loop
bool loop = true;

// Main Loop
while (loop) {
    Console.WriteLine($"\nMAIN MENU");
    Console.WriteLine("1. Spell Check a Word (Linear Search)");
    Console.WriteLine("2. Spell Check a Word (Binary Search)");
    Console.WriteLine("3. Spell Check Alice in Wonderland (Linear Search)");
    Console.WriteLine("4. Spell Check Alice in Wonderland (Binary Search)");
    Console.WriteLine("5. Exit");
    Console.Write("Enter menu selectrion (1-5): ");
    string option = Console.ReadLine();

    // DICTIONARY LINEAR
    if (option == "1") {
        Console.Write("Please enter a word: ");
        string search = Console.ReadLine();
        Console.WriteLine("\nLinear Search starting...");
        double startTime = DateTime.Now.Ticks;
        int indexOfWord = linearSearchString(dictionary, search);
        double endTime = DateTime.Now.Ticks;
        double timeElapsed = (endTime - startTime)/10000000;
        if (indexOfWord > -1) {
            Console.WriteLine($"{search} is IN the dictionary at position {indexOfWord}. ({timeElapsed} seconds)");
        } else if (indexOfWord == -1) {
            Console.WriteLine($"{search} is NOT in the dictionary. ({timeElapsed} seconds)");
        }
    // DICTIONARY BINARY
    } else if (option == "2") {
        Console.Write("Please enter a word: ");
        string search = Console.ReadLine();
        Console.WriteLine("\nBinary Search starting...");
        double startTime = DateTime.Now.Ticks;
        int indexOfWord = binarySearchString(dictionary, search);
        double endTime = DateTime.Now.Ticks;
        double timeElapsed = (endTime - startTime)/10000000;
        if (indexOfWord > -1) {
            Console.WriteLine($"{search} is IN the dictionary at position {indexOfWord}. ({timeElapsed} seconds)");
        } else if (indexOfWord == -1) {
            Console.WriteLine($"{search} is NOT in the dictionary. ({timeElapsed} seconds)");
        }
    // ALICE IN WONDERLAND LINEAR
    } else if (option == "3") {
        Console.WriteLine("\nLinear Search starting...");
        double startTime = DateTime.Now.Ticks;
        int notFound = 0;
        for (int n = 0; n < aliceWords.Length; n++) {
            if (linearSearchString(dictionary, aliceWords[n]) == -1) {
                notFound++;
            }
        }
        double endTime = DateTime.Now.Ticks;
        double timeElapsed = (endTime - startTime)/10000000;
        Console.WriteLine($"Number of words not found in dictionary: {notFound} ({timeElapsed} seconds)");
    // ALICE IN WONDERLAND BINARY
    } else if (option == "4") {
        Console.WriteLine("\nBinary Search starting...");
        double startTime = DateTime.Now.Ticks;
        int notFound = 0;
        for (int n = 0; n < aliceWords.Length; n++) {
            if (binarySearchString(dictionary, aliceWords[n]) == -1) {
                notFound++;
            }
        }
        double endTime = DateTime.Now.Ticks;
        double timeElapsed = (endTime - startTime)/10000000;
        Console.WriteLine($"Number of words not found in dictionary: {notFound} ({timeElapsed} seconds)");
    // EXIT
    } else if (option == "5") {
      loop = false;
    } else {
      Console.WriteLine("Invalid Answer");
    }
}

int linearSearchString(string[] anArray, string item) {
    for (int n = 0; n < anArray.Length; n++) {
        if (anArray[n].ToLower() == item.ToLower()) {
            return n;
        }
    }
    return -1;
}

int binarySearchString(string[] anArray, string item) {
    int lowerIndex = 0;
    int upperIndex = anArray.Length;
    for (int n = 0; n < anArray.Length; n++) {
        double middle = (lowerIndex + upperIndex)/2;
        int middleIndex = Convert.ToInt32(Math.Floor(middle));
        if (anArray[middleIndex].ToLower() == item.ToLower()) {
            return middleIndex;
        } else if (string.Compare(anArray[middleIndex].ToLower(), item.ToLower(), true) > 0) {
            upperIndex = middleIndex - 1;
        } else {
            lowerIndex = middleIndex + 1;
        }
    }
    return -1;
}

