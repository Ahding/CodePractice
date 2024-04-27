namespace CodePractice.Model;

public static class SolutionCalculation
{
    public static void Add(Level level) => SolutionCount[level]++;
        
    private static Dictionary<Level, int> SolutionCount = new Dictionary<Level, int>
    {
        { Level.Easy, 0 },
        { Level.Medium, 0 },
        { Level.Hard, 0 }
    };
    
    public static int GetSolutionCount(Level level) => SolutionCount[level];
}

public enum Level
{
    Easy,
    Medium,
    Hard
}