namespace GovUkDesignSystemDotNetDemo.Helpers;

public static class CodeFormattingHelper
{
    public static string RemoveUnwantedWhitespace(string inputCode)
    {
        string[] inputCodeLines = inputCode.Split(Environment.NewLine);

        string[] trimmedCodeLines = RemoveWhitespaceLinesAtStartAndEnd(inputCodeLines);
        
        string[] trimmedLines = RemoveEqualWhiteSpaceFromTheStartOfEachLine(trimmedCodeLines);

        string outputCode = string.Join(Environment.NewLine, trimmedLines);
        return outputCode;
    }

    private static string[] RemoveEqualWhiteSpaceFromTheStartOfEachLine(string[] trimmedCodeLines)
    {
        List<int> spacesAtStartOfLines = trimmedCodeLines
            .Select(NumberOfSpacesAtTheStartOfAString)
            .Where(numberOfSpaces => numberOfSpaces > 0)
            .ToList();
        
        int minimumSpacesAtStartOfLine = spacesAtStartOfLines.Any() ? spacesAtStartOfLines.Min() : 0;

        string[] trimmedLines = trimmedCodeLines.Select(
            line => line.Length > minimumSpacesAtStartOfLine ? line.Substring(minimumSpacesAtStartOfLine) : ""
            ).ToArray();
        return trimmedLines;
    }

    private static string[] RemoveWhitespaceLinesAtStartAndEnd(string[] inputCodeLines)
    {
        List<string> codeLines = inputCodeLines.ToList();

        while (codeLines.Count > 0 && string.IsNullOrWhiteSpace(codeLines[0]))
        {
            codeLines.RemoveAt(0);
        }
        
        while (codeLines.Count > 0 && string.IsNullOrWhiteSpace(codeLines[codeLines.Count - 1]))
        {
            codeLines.RemoveAt(codeLines.Count - 1);
        }
        
        return codeLines.ToArray();
    }

    private static int NumberOfSpacesAtTheStartOfAString(string inputLine)
    {
        for (var index = 0; index < inputLine.Length; index++)
        {
            if (inputLine[index] != ' ')
            {
                return index;
            }
        }
        return inputLine.Length;
    }
}