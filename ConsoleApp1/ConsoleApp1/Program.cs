// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        int totalScore = MainFunction(2);        
    }
    public static List<List<int>> CreateRandomNumbers(int throwValue)
    {
        var randomClass = new Random();
        var randomNumbers = new List<int>();
        throwValue = throwValue * 5;
        var listOfSubList = new List<List<int>>();
        for (int i = 0; i < throwValue; i++)
        {
            randomNumbers.Add(randomClass.Next(1, 7));
            if((i + 1) % 5 == 0)
            {
                var subList = randomNumbers.Skip(i - 4).Take(5).ToList();
                listOfSubList.Add(subList);

            }
        }
        return listOfSubList;
    }
    public static int MainFunction(int throwValue)
    {
        var listOfNumbers = CreateRandomNumbers(throwValue);
        var results = new List<(string, int)>();
        int totalScore = 0;
        foreach(var subList in listOfNumbers)
        {
            Console.WriteLine("Sous-liste : [" + string.Join(", ", subList) + "]");
            var countSameNumbers = new Dictionary<int, int>();
            foreach(var number in subList)
            {
                if (countSameNumbers.ContainsKey(number))
                {
                    countSameNumbers[number]++;
                }
                else
                {
                    countSameNumbers[number] = 1;
                }
            }

            int score = 0;
            string name = "";
            if (countSameNumbers.Values.Contains(5))
            {
                score += 50;
                name = "yams";
            }
            else if (subList[0] == 1 && 
                subList[1] == 2 && 
                subList[2] == 3 &&
                subList[3] == 4 &&
                subList[4] == 5)
            {
                score += 40;
                name = "suite";
            }
            else if (subList[0] == 2 &&
                subList[1] == 3 &&
                subList[2] == 4 &&
                subList[3] == 5 &&
                subList[4] == 6)
            {
                score += 40;
                name = "suite";
            }
            else if (countSameNumbers.Values.Count(v => v == 3) == 1 && countSameNumbers.Values.Count(v => v ==2) == 1)
            {
                score += 30;
                name = "full";
            }
            else
            {
                foreach(var item in countSameNumbers) 
                {
                    if(item.Value == 3) 
                    {
                        score += 28;
                        name = "brelan";
                    }
                    else if(item.Value == 4)
                    {
                        score += 35;
                        name = "carré";
                    }
                }
                if(score == 0)
                {
                    score = subList.Sum();
                    name = "Chance";
                }
            }
            results.Add((name, score));
            totalScore += score;
            
        }
        return totalScore;
    }
}