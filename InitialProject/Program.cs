using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, Juh!");
Console.WriteLine("Hello, Deh!");

//Este é um comentário porque tem //

//Variável - camelCase
string myVariable = "";
var isValid = true;
double myNumber = 0.0;
float myNumberFloat = 0.0f;
int myNumberInt = 0;

//IEnumerable
var myList = new List<string>() { "a", "b", "c" };
myList.Add(myVariable);
var count = myList.Count;

var myArray = new[] { "a", "b", "c" };

//Iterações
foreach (var item in myList)
{
    Console.WriteLine(item);
}

for (int i = 0; i < myList.Count; i++)
{
    Console.WriteLine(myList[i]);
}

//Context

//The English department needs a small practice tool.
//The student sees the words of a sentence in the wrong order and has to type them back in the correct order.
//Your job is to build it as a C# console application.

//Objective

//Build a game that shows a scrambled sentence, reads the player's attempt,
//tells them whether it's right, and keeps score across all rounds.
//

//=== Sentence Scramble ===
//Round 1 of 10

//  live / you / where / do / ?

//Your answer: where do you live?
//Correct! (+1 point)   Score: 1

//Round 2 of 10

//  class / when / start / the / does / ?

//Your answer: when do the class start?
//Not quite. 2 attempts left.

//Your answer: hint
//Hint: the sentence starts with "When"   (-0.5 points)

//Your answer: When does the class start?
//Correct! (+0.5 points)   Score: 1.5

//Random.Shared.Shuffle(words);

//if (age > 60)
//{
//    Console.WriteLine("He is old");
//}
//else if (age > 40)
//{
//    Console.WriteLine("He is middle age");
//}
//else if (age > 20)
//{
//    Console.WriteLine("y");
//}
//else if (age > 10)
//{
//    Console.WriteLine("x");
//}
//else
//{
//    Console.WriteLine("He is young");
//}

//var ages = new List<int>() { 80, 20, 40, 50, 60 };

//foreach (var age in ages) //Early return -> retorno cedo
//{
//    if (age > 60)
//    {
//        Console.WriteLine("He is old");
//        continue;
//    }

//    if (age > 40)
//    {
//        Console.WriteLine("He is middle age");
//    }

//    if (age > 20)
//    {
//        Console.WriteLine("y");
//    }

//    if (age > 10)
//    {
//        Console.WriteLine("x");
//        break;
//    }

//    if (age <= 10)
//    {
//        Console.WriteLine("He is young");
//    }
//}

//public class Person 
//{
//    public string Name;
//    public int Age;
//}


var score = 0.0;
var list = new List<string>()
{ 
    "how many children do you have ?",
    "is your job interesting ?",
    "what color is his car ?",
    "where does your brother work ?",
    "do you work with computers ?",
    "what kind of magazines do you read ?",
    "what does he do on the weekend ?",
    "are you stressed in your job ?",
    "where does your sister live ?",
    "how do you say that in English ?"
};

for (int i = 0; i < list.Count; i++)
{
    var myTry = 0;
    bool correct = false;

    string[] words = list[i].Split(" ");
    Random.Shared.Shuffle(words);
    string wordsScrambled = string.Join(" / ", words);
    Console.WriteLine(wordsScrambled);

    while (!correct && myTry < 3)
    {

        Console.WriteLine("What is the correct form?");
        Console.Write(" ");
        string userResponse = Console.ReadLine();
        Console.WriteLine(userResponse);

        if (userResponse == list[i])
        {
            Console.WriteLine("Está certo, parabéns");
            score = score + 1;
            Console.WriteLine("Sua nota é:" + score);
            correct = true;
        }

        if (userResponse != list[i])
        {
            Console.WriteLine("Errou");
            myTry = myTry + 1;

            if (myTry < 3)
            {

                Console.Write("Quer uma dica? (true/false)");
                string hit = Console.ReadLine();

                if (hit.ToLower() == "true")
                {

                    if (myTry == 1)
                    {
                        string firstWord = list[i].Split(' ')[0];
                        Console.WriteLine("Dica: A frase começa com a palavra com " + firstWord);
                        score = score - 0.25f;
                        Console.WriteLine("Sua nota atual é:" + score);
                    }

                    if (myTry == 2)
                    {
                        string secondWord = list[i].Split(' ')[1];
                        Console.WriteLine("Dica: a segunda palavra é: " + secondWord);
                        score = score - 0.25f;
                        Console.WriteLine("Sua nota atual é:" + score);
                    }

                }
            }
        }

        if (myTry == 3)
        {
            Console.WriteLine("Game over!");
        }

    }
}
Console.WriteLine($"Sua pontuação final foi: {score} de 10 pontos.");