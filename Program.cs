//https://old.reddit.com/r/dailyprogrammer/comments/onfehl/20210719_challenge_399_easy_letter_value_sum/

//Initialize alphabet and test data
using System.Collections.Immutable;
using System.Data;

string alphabet = "abcdefghijklmnopqrstuvwxyz";
Dictionary<char, int> letterToNumber = new Dictionary<char, int>{
    {'a', 1}, 
    {'b', 2},
    {'c', 3},
    {'d', 4},
    {'e', 5},
    {'f', 6},
    {'g', 7},
    {'h', 8},
    {'i', 9},
    {'j', 10},
    {'k', 11},
    {'l', 12},
    {'m', 13},
    {'n', 14},
    {'o', 15},
    {'p', 16},
    {'q', 17},
    {'r', 18},
    {'s', 19},
    {'t', 20},
    {'u', 21},
    {'v', 22},
    {'w', 23},
    {'x', 24},
    {'y', 25},
    {'z', 26}};
string[] words = File.ReadAllLines("../../../enable1.txt");

//0
WordToNumber("");
//1 
WordToNumber("a");
//26
WordToNumber("z");
//6
WordToNumber("cab");
//100
WordToNumber("excellent");
//317
WordToNumber("microspectrophotometries");
Bonus1();
Bonus2();
Bonus3();
Bonus4();
Bonus5();

//Convert a provided String to a number that comes from the sum of all of the letters in that String, assuming each
//letter has a value that corresponds to its position in the alphabet
int WordToNumber(string aWord, bool print=true)
{
    int total = 0;
    foreach(char letter in aWord.ToCharArray())
    {
        total += letter - 96;
    }

    if(print)
    {
        Console.WriteLine($"'{aWord}' => {total}");
    }

    return total;
}

// Which word from the provided word list defined in enable1.txt has a total of 319? (There's only one.)
void Bonus1()
{
    foreach(string word in words)
    {
        if(WordToNumber(word, false) == 319)
        {
            Console.WriteLine($"'{word}' => 319");
            break;
        }
    }
}

// How many words that sum to an odd number are there?
void Bonus2()
{
    int total = 0;
    foreach(string word in words)
    {
        if(WordToNumber(word, false)%2 != 0) total++;
    }
}

// There are 1921 words with a letter sum of 100, making it the second most common letter sum.
// What letter sum is most common, and how many words have it?
void Bonus3()
{
    Dictionary<int, int> sumCounts = new Dictionary<int, int>();
    foreach(string word in words)
    {
        int letterSum = WordToNumber(word, false);

        if(letterSum != 100)
        {
            int count;
            if(sumCounts.TryGetValue(letterSum, out count))
            {
                sumCounts[letterSum] = count + 1;
            }
            else
            {
                sumCounts[letterSum] = 1;
            }
        }
    }

    var sortedList = sumCounts.ToList();
    sortedList.Sort((letterSum,secondLetterSum) => letterSum.Value.CompareTo(secondLetterSum.Value));

    Console.WriteLine($"Most common letter sum is {sortedList[sortedList.Count-1].Key} for a total of {sortedList[sortedList.Count-1].Value} words");
} 

void Bonus4()
{
    for(int i=0; i<words.Length; i++)
    {
        int letterSum = WordToNumber(words[i], false);
        int length = words[i].Length;
        for(int j=i+1; j<words.Length; j++)
        {
            if(Math.Abs(length - words[j].Length) != 11) continue;

            if(letterSum == WordToNumber(words[j], false))
            {
                Console.WriteLine($"{words[i]} has the same letter sum as {words[j]}");
                return;
            }
        }
    }
}

void Bonus5()
{
    int matchCount = 0;
    for(int i=0; i<words.Length; i++)
    {
        if(matchCount == 2) break;
        int letterSum = WordToNumber(words[i], false);
        
        for(int j=i+1; letterSum > 188 && j<words.Length; j++)
        {
            if(matchCount == 2) break;
            if(letterSum == WordToNumber(words[j], false))
            {
                int k=0;

                foreach(char letterI in words[i].ToCharArray())
                {
                    if(words[j].Contains(letterI)) break;
                    k++;
                }

                if(k == words[i].Length)
                {
                    matchCount++;
                    Console.WriteLine($"{words[i]} has the same letter sum as {words[j]} and no common letters");
                }
            }
        }     
    }
}

void Bonus6()
{
    //TODO
}