class Quiz {
    private class Question
    {
        public readonly string question;
        public readonly string[] options;
        public readonly int correctOptionIndex;
        public readonly string explainer;

        public Question(string question, string[] options, int correctOptionIndex, string explainer)
        {
            this.question = question;
            this.options = options;
            this.correctOptionIndex = correctOptionIndex;
            this.explainer = explainer;
        }
    }

    private static readonly Question[] questions = new Question[]
    {
        new Question(
            "Du opdager en brand under evakueringen. Hvad bør du gøre?",
            new string[]
            {
                "Forsøge at slukke branden uanset størrelsen",
                "Prioritere sikker evakuering og kun forsøge slukning, hvis det er sikkert og du er instrueret i det",
                "Åbne vinduerne for at fjerne røgen"
            },
            1,
            "Under en brand bør du altid prioritere sikker evakuering. Er du instrueret kan du forsøge at slukke branden hvis du vurderer det til at være sikkert."
        ),
        new Question(
            "Du opdager et kemikalieudslip i laboratoriet. Hvad gør du?",
            new string[]
            {
                "Forsøger at tørre kemikaliet op",
                "Undersøger kemikaliet ved at lugte til det",
                "Holder afstand, advarer andre og følger evakueringsproceduren"
            },
            2,
            "Du bør holde afstand, advare andre og følge evakueringsproceduren."
        ),
        new Question(
            "Du kommer til skade og begynder at bløde kraftigt. Hvad bør du gøre?",
            new string[]
            {
                "Lægge direkte tryk på såret og tilkalde hjælp",
                "Vente på, at blødningen stopper af sig selv",
                "Skylle såret og fortsætte arbejdet"
            },
            0,
            "Du bør lægge tryk på såret for at formindske blødningen så vidt som muligt og tilkalde hjælp."
        ),
        new Question(
            "En gang er blokeret efter en eksplosion. Hvad er den sikreste handling?",
            new string[]
            {
                "Forsøge at flytte tunge genstande med magt",
                "Finde en anden sikker flugtvej",
                "Kravle gennem det beskadigede område"
            },
            1,
            "Den sikreste handling er at finde en anden, sikker flugtvej."
        ),
        new Question(
            "Du er nået ud af bygningen. Hvad skal du gøre nu?",
            new string[]
            {
                "Gå hjem uden at fortælle nogen det",
                "Gå tilbage for at hente personlige ejendele",
                "Gå til samlingspunktet og melde dig til den ansvarlige"
            },
            2,
            "Er du nået ud af bygningen skal du gå til samlingspunktet og melde dig til den ansvarlige."
        )
    };

    public static void StartQuiz() {
        Typewriter.WriteLineColor("darkgray", "[Du svarer på spørgsmål ved at skrive korresponderende tal til svarmulighed.]");

        int correctAnswers = 0;

        for (int i = 0; i < questions.Length; i++) {
            Typewriter.WriteLine(questions[i].question);
            // Printer svarmulighederne til spørgsmålene
            for (int j = 0; j < questions[i].options.Length; j++) {
                Typewriter.WriteLineColor("yellow", $"[{j+1}] {questions[i].options[j]}");
            }

            Console.Write("> ");
            string? input = Console.ReadLine();
   
            // Checker om brugeren har skrevet valid input og skriver en besked hvis ikke
            while (input is not ("1" or "2" or "3")) {
                Typewriter.WriteLineColor("red", "Du skrev ikke et tal [1-3], prøv igen...");
                Console.Write("> ");
                input = Console.ReadLine();
            }

            if (int.Parse(input)-1 == questions[i].correctOptionIndex) {
                Typewriter.WriteLineColor("green", "Korrekt!");
                correctAnswers++;
            } else {
                Typewriter.WriteLineColor("red", "Det er desværre forkert. " + questions[i].explainer);
            }
        }

        Typewriter.WriteLine($"Du svaret rigtigt på {correctAnswers} ud af {questions.Length} spørgsmål.");
        if (correctAnswers == questions.Length) {
            Typewriter.WriteLine("Flot klaret! Du har vist, at du forstår de vigtigste sikkerhedsprocedurer ved brand," +
                                 " kemikalieudslip og evakuering. Husk, at din egen og andres sikkerhed altid kommer først.");
        }
    }
}





