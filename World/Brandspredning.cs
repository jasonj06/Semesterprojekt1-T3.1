//tilføjer en class for røg hvis den nu skulle opdateres senere i stedet for at hardcode den.
//Har bare lavet en bool som checker hvilken turn vi er på, og hvis det er 5 15 30 35 så skriver den med typewriter
public class BrandSpredning
{
    public bool CheckTurn(int turn)
    {
        switch (turn)
        {
            case 5:
                Typewriter.WriteLine("Der kommer en dump lyd fra gangen, og en svag lugt af røg breder sig.");
                break;

            case 15:
                Typewriter.WriteLine("Røg siver nu ind under dørene. Du begynder at hoste.");
                break;

            case 30:
                Typewriter.WriteLine("Røgen er tyk og sort. Det svier i øjnene – du skal ud nu!");
                break;

            case 35:
                Typewriter.WriteLine("Røgen overmander dig, og du besvimer. Game Over!");
                return true; // Signalerer at spillet er tabt
        }

        return false; // Spillet fortsætter
    }
}
