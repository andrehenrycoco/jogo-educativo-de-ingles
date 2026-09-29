namespace InitialProject.EnglishStudies;

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
    private const int MAX_TRIES = 3;
    public void Execute()
    {

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

        var startGame = true;

        while (true)
        {
            if (!startGame)
            {
                break;
            }

            while (startGame)
            {
                var score = 0.0;

                for (int i = 0; i < list.Count; i++)
                {
                    var words = list[i].Split(" ");
                    Random.Shared.Shuffle(words);

                    var wordsScrambled = string.Join(" / ", words);
                    Console.WriteLine(wordsScrambled);

                    var originalWords = list[i].Split(' ');
                    var tipWords = new string[originalWords.Length];

                    for (int j = 0; j < originalWords.Length; j++)
                    {
                        tipWords[j] = "-";
                    }

                    var myTry = 0;

                    while (myTry < MAX_TRIES)
                    {
                        var tipsCount = 0;

                        while (true)
                        {
                            Console.Write("Quer uma dica? (T/F)");
                            var tip = Console.ReadLine();

                            if (tip == null || !tip.Trim().Equals("T", StringComparison.CurrentCultureIgnoreCase))
                            {
                                break;
                            }

                            if (tipsCount == words.Length - 1)
                            {
                                Console.WriteLine("Consumiu todas as dicas");
                                break;
                            }

                            var random = new Random();
                            var item = random.Next(0, words.Length - 1);

                            var trueWord = originalWords[item];

                            tipWords[item] = trueWord;

                            Console.WriteLine("Dica: " + string.Join(" ", tipWords));

                            score = score - SCORE_REDUCTION_FACTOR;
                            Console.WriteLine("Sua nota atual é: " + Math.Round(score, 2));

                            tipsCount++;
                        }

                        Console.WriteLine("Tente advinhar: " + string.Join(" ", tipWords));
                        Console.WriteLine("What is the correct form?");
                        Console.Write("");

                        var userResponse = Console.ReadLine();

                        var responseFormatted = userResponse != null ? userResponse.Replace(" ", "").ToLower() : "";
                        var correctFormatted = list[i].Replace(" ", "").ToLower();

                        if (responseFormatted == correctFormatted)
                        {
                            Console.WriteLine("Está certo, parabéns");
                            score = score + SCORE_ADD;
                            Console.WriteLine("Sua nota é:" + Math.Round(score, 2));
                            break;
                        }

                        Console.WriteLine("Errou");

                        if (myTry == MAX_TRIES)
                        {
                            startGame = true;

                            Console.WriteLine("Game over!");

                            Console.Write("\nDeseja jogar novamente? (T/F): ");
                            var answerPlayAgain = Console.ReadLine();

                            if (answerPlayAgain == null || !answerPlayAgain.Trim().Equals("T", StringComparison.CurrentCultureIgnoreCase))
                            {
                                startGame = GetFinalScore(score);
                            }

                            break;
                        }

                        myTry++;
                    }
                }

                Console.Write("\nDeseja jogar novamente? (T/F): ");
                var finalAnswer = Console.ReadLine();

                if (finalAnswer == null || !finalAnswer.Trim().Equals("T", StringComparison.CurrentCultureIgnoreCase))
                {
                    startGame = GetFinalScore(score);
                    break;
                }
            }
        }
    }

    private static bool GetFinalScore(double score)
    {
        Console.WriteLine("Obrigado por jogar!");
        Console.WriteLine($"Sua pontuação final foi: {score} de 10 pontos.");

        return false;
    }
}
