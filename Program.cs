//https://old.reddit.com/r/dailyprogrammer/comments/onfehl/20210719_challenge_399_easy_letter_value_sum/

//Initialize alphabet and test data
using System.Collections.Immutable;
using System.Data;

string alphabet = "abcdefghijklmnopqrstuvwxyz";
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

//Convert a provided String to a number that comes from the sum of all of the letters in that String, assuming each
//letter has a value that corresponds to its position in the alphabet
int WordToNumber(string aWord, bool print=true)
{
    int total = 0;
    foreach(char letter in aWord.ToCharArray())
    {
        total += alphabet.IndexOf(letter)+1;
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
    //TODO
}

void Bonus5()
{
    //TODO
}

void Bonus6()
{
    //TODO
}