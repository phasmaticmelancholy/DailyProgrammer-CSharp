//https://old.reddit.com/r/dailyprogrammer/comments/13m4bz1/20230519_challenge_400_intermediate_practical/
class PracticalNumbers 
{
    int theNumber;
    bool thePracticalFlag;

    PracticalNumbers(int aNumber)
    {
        theNumber = aNumber;
        thePracticalFlag = CheckPracticality();
    }

    private bool CheckPracticality()
    {
        bool theResult;

        if(theNumber == 1 || theNumber == 2)
        {
            theResult = true;
        }
        else if(theNumber%2 != 0)
        {
            theResult = false;
        }
        else
        {
            theResult = true;
            int[] divisors = GetDivisors(theNumber);
            for(int i=3; theResult && i<theNumber; i++)
            {
                theResult = sum(i, divisors, divisors.Length-1);
            }
        }

        return theResult;
    }

    private bool sum(int totNum, int[] divisors, int startIndex)
    {
        bool result = false;

        for(int i=startIndex; !result && i>-1; i--)
        {
            if(totNum == divisors[i] || totNum == 0)
            {
                result = true;
            }
            else if(totNum > divisors[i])
            {
                result = sum(totNum-divisors[i], divisors, i-1);
            }
        }
        
        return result;
    }

    private int[] GetDivisors(int aNumber)
    {
        int[] divisors = new int[]{1};

        for(int i=2; i < aNumber; i++)
        {
            if(aNumber%i == 0)
            {
                divisors = divisors.Concat(new int[]{i}).ToArray();
            }
        }

        return divisors;
    }

    public bool IsPractical()
    {
        return thePracticalFlag;
    }

    public void PrintResult()
    {
        string result = thePracticalFlag ? "is" : "is not";
        Console.WriteLine($"Number {theNumber} {result} a practical number.");
    }

    public static void Main(String[] args)
    {
        int total = 0;
        for(int i=1; i<10001; i++)
        {
            PracticalNumbers practicalNumber = new PracticalNumbers(i);
            if(practicalNumber.IsPractical())
            {
                total+=i;
            }
        }

        Console.WriteLine("Total summation of practical numbers up to 10000 inclusive: " + total);
    }
}
