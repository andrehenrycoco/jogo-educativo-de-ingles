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


var score = 0;
var list = new List<string>() { "how many children do you have ?", "" };
Console.WriteLine(list[0]);


