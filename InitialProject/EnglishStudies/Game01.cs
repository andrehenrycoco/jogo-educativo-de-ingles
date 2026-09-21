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
    private const double SCORE_REDUCTION_FACTOR = 0.10;
    private const int SCORE_ADD = 1;
    private const int MAX_TRIES = 1;
    public void Execute()
    {
        bool playAgain = true;
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

            string[] originalWords = list[i].Split(' ');
            string[] tipWords = new string[originalWords.Length];

            for (int j = 0; j < originalWords.Length; j++)
            {
                tipWords[j] = "-";
            }
            while (playAgain)
            {
                bool askTip = true;
                while (!correct && myTry < 3)
                {
                    while (askTip)
                    {
                        List<int> wordIndices = new List<int>();
                        Console.Write("Quer uma dica? (true/false)");
                        string? tip = Console.ReadLine();

                        if (tip == null || tip.Trim().ToLower() != "true")
                        {
                            askTip = false;
                            continue;
                        }
                        if (wordIndices.Count > 1)
                        {
                            Console.WriteLine("Consumiu todas as dicas");
                            askTip = false;
                            continue;
                        }
                        for (int w = 0; w < tipWords.Length; w++)
                        {
                            if (tipWords[w] == "-")
                            {
                                wordIndices.Add(w);
                            }
                        }
                        var randomIndex = Random.Shared.Next(0, wordIndices.Count);
                        int wordToReveal = wordIndices[randomIndex];

                        tipWords[wordToReveal] = originalWords[wordToReveal];
                        score = score - SCORE_REDUCTION_FACTOR;

                        Console.WriteLine("Dica: " + string.Join(" ", tipWords));
                        Console.WriteLine("Sua nota atual é: " + Math.Round(score, 2));
                    }
                    Console.WriteLine("Dica: " + string.Join(" ", tipWords));
                    Console.WriteLine("What is the correct form?");
                    Console.Write("");
                    string? userResponse = Console.ReadLine();

                    string responseFormatted = userResponse != null ? userResponse.Replace(" ", "").ToLower() : "";
                    string correctFormatted = list[i].Replace(" ", "").ToLower();

                    if (responseFormatted == correctFormatted)
                    {
                        Console.WriteLine("Está certo, parabéns");
                        score = score + SCORE_ADD;
                        Console.WriteLine("Sua nota é:" + Math.Round(score, 2));
                        correct = true;
                    }
                    if (responseFormatted != correctFormatted)
                    {
                        Console.WriteLine("Errou");
                        myTry = myTry + MAX_TRIES;
                        askTip = true;
                        if (myTry == 3)
                        {
                            Console.WriteLine("Game over!");
                        }
                    }
                }
                Console.Write("\nDeseja jogar novamente? (true/false): ");
                string? respostaFim = Console.ReadLine();
                if (respostaFim == null || respostaFim.Trim().ToLower() != "true")
                {
                    playAgain = false;
                    Console.WriteLine("Obrigado por jogar!");

                    Console.WriteLine($"Sua pontuação final foi: {score} de 10 pontos.");
                }
            }
        }
    }
}