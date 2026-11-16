class Quiz {
    
    private static readonly string[] questions = {
        "Hvad er 1+1?",
        "Hvad er 2+2?",
        "Hvad er 3+3?"
    };
    // Svar er første element, så svar på spg 1 er array[0][0], spg 2 er array[1][0] osv.
    private static readonly string[][] answers = {
        new string[]{"2", "1", "3", "4"},
        new string[]{"4", "1", "2", "3"},
        new string[]{"6", "1", "2", "3"}
    };

    public static void StartQuiz()
    {
        foreach (string question in questions)
        {
            Typewriter.WriteLine(question);
            string answer = Console.ReadLine();
            if (answer == answers[Array.IndexOf(questions, question)][0])
            {
                Typewriter.WriteLine("Korrekt!");
            }
            else
            {
                Typewriter.WriteLine("Desværre, det er forkert.");
            }
        }
    }
}