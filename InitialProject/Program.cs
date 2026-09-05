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

var ages = new List<int>() { 80, 20, 40, 50, 60 };

foreach (var age in ages) //Early return -> retorno cedo
{
    if (age > 60)
    {
        Console.WriteLine("He is old");
        continue;
    }

    if (age > 40)
    {
        Console.WriteLine("He is middle age");
    }

    if (age > 20)
    {
        Console.WriteLine("y");
    }

    if (age > 10)
    {
        Console.WriteLine("x");
        break;
    }

    if (age <= 10)
    {
        Console.WriteLine("He is young");
    }
}

public class Person 
{
    public string Name;
    public int Age;
}
//Random.Shared.Shuffle(words);


var score = 0;
var list = new List<string>() { "how many children do you have ?", "" };
Console.WriteLine(list[0]);


