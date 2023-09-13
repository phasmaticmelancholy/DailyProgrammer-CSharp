//https://old.reddit.com/r/dailyprogrammer/comments/onfehl/20210719_challenge_399_easy_letter_value_sum/
string alphabet = "abcdefghijklmnopqrstuvwxyz";
string[] words = File.ReadAllLines("../../../enable1.txt");

WordToNumber("");
WordToNumber("a");
WordToNumber("z");
WordToNumber("cab");
WordToNumber("excellent");
WordToNumber("microspectrophotometries");
Bonus1();

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
