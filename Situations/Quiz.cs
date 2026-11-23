class Quiz {
    
    private static readonly string[] questions = {
        "Du opdager en brand under evakueringen. Hvad bør du gøre?",
        "Du opdager et kemikalieudslip i laboratoriet. Hvad gør du?",
        "Du kommer til skade og begynder at bløde kraftigt. Hvad bør du gøre?",
        "En gang er blokeret efter en eksplosion. Hvad er den sikreste handling?",
        "Du er nået ud af bygningen. Hvad skal du gøre nu?"
    };
    // Svar er første element, så svar på spg 1 er array[0][0], spg 2 er array[1][0] osv.
    private static readonly string[][] answers = {
        new string[]{"Prioritere sikker evakuering og kun forsøge slukning, hvis det er sikkert og du er instrueret i det", 
                    "Forsøge at slukke branden uanset størrelsen", 
                    "Åbne vinduerne for at fjerne røgen"},

        new string[]{"Holder afstand, advarer andre og følger evakueringsproceduren", 
                    "Forsøger at tørre kemikaliet op", 
                    "Undersøger kemikaliet ved at lugte til det"},

        new string[]{"Lægge direkte tryk på såret og tilkalder hjælp", 
                    "Vente på, at blødningen stopper af sig selv", 
                    "Skylle såret og fortsætte arbejdet"},

        new string[]{"Finde en anden sikker flugtvej",
                    "Forsøge at flytte tunge genstande med magt",
                    "Kravle gennem det beskadigede område"},

        new string[]{"Gå til samlingspunktet og melde dig til den ansvarlige",
                    "Gå hjem uden at fortælle nogen det",
                    "Gå tilbage for at hente personlige ejendele"}
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