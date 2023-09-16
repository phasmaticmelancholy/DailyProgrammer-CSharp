//https://old.reddit.com/r/dailyprogrammer/comments/onfehl/20210719_challenge_399_easy_letter_value_sum/
using System.ComponentModel;
using System.Data;

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
//Bonus4();
Bonus5();
Bonus6();

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
        if(words[i].Equals("biodegradabilities ")) continue;

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

//Sorts strings longest to shortest
int CompareLengths(string word1, string word2)
{
    return word1.Length - word2.Length;
}

//TODO - this is both wrong and very inefficient, but the bones are there for something better
void Bonus6()
{
    List<string> results = new(); 
    Array.Sort(words, CompareLengths);

    //TODO Need to nest this different, currently each word only gets one chain
    for(int i=words.Length-1; i>=0; i--)
    {
        List<string> activeResults = new(); 
        int previousLetterSum = WordToNumber(words[i], false);
        int previousLength = words[i].Length;

        activeResults.Add(words[i]);
        for(int j=i-1; j>=0; j--)
        {
            if(previousLength == words[j].Length) continue;

            int letterSum = WordToNumber(words[j], false);

            if(previousLetterSum < letterSum)
            {
                activeResults.Add(words[j]);
                previousLetterSum = letterSum;
                previousLength = words[j].Length;
            }
        }    

        if(activeResults.Count > results.Count)
        {
            results = new(activeResults);
            Console.WriteLine("New longest list: [" + String.Join(",", results) + "]");
        } 
    }

    Console.WriteLine($"The longest list of reverse length ordered words with increasing letter sums found had {results.Count} words.");
}