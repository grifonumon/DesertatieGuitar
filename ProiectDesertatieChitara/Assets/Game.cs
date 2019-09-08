public class Game
{
    public static float Life = 100;
    private static PathsAndConstants.GameDificulty Dificulty;

    public static void NoteMiss()
    {
        out int multyplier;

        Life -= 5 * PathsAndConstants.DictDificulty.TryGetValue(Dificulty, multyplier);
    }
}