using CodePractice.Model;

namespace CodePractice;

[SetUpFixture]
public class GlobalSetup
{
    [OneTimeTearDown]
    public void RunAfterAllTests()
    {
        // calculate the number of solutions
        var easy = SolutionCalculation.GetSolutionCount(Level.Easy);
        var medium = SolutionCalculation.GetSolutionCount(Level.Medium);
        var hard = SolutionCalculation.GetSolutionCount(Level.Hard);
        
        Console.WriteLine($@"Easy: {easy}
Medium: {medium}
Hard: {hard}
----------------
Total: {easy + medium + hard}");

        true.Should().BeTrue();
    }
}