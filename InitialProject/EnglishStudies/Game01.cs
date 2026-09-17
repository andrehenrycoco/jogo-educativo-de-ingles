namespace InitialProject.EnglishStudies;

// 1. Somente checar a ordem das palavras sem levar em conta os espaços. 
// 2. Mostrar uma palavra aleatória (tipo jogo da forca) -> "_ _ _ many _ _ _ " -> Posso pedir quantas dicas eu quiser até restar uma palavra para adivinhar.
// 3. A comparação de strings seja "case insensitive"
// 4. Quando der GameOver, pergunte para o usuário se ele quer começar um novo jogo.

public class Program
{
    public static void Main()
    {
        var game01 = new Game01();
        game01.Execute();
    }
}

public class Game01
{
    public void Execute()
    {
        var score = 0.0;

      Console.WriteLine("hellou, mundo");

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
                Console.Write("");
                string? userResponse = Console.ReadLine();

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
                        string? hit = Console.ReadLine();

                        if (hit != null && hit.ToLower() == "true")
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
    }

}

public class MyGames
{
    public MyGames()
    {
        var game01 = new Game01();
        game01.Execute();
    }
}