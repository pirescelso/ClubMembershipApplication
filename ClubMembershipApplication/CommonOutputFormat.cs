using System.Drawing;

namespace ClubMembershipApplication;

public enum FontTheme
{
    Default,
    Danger,
    Success
}
public static class CommonOutputFormat
{
    public static void ChangFontColor(FontTheme fontTheme)
    {
        if(fontTheme == FontTheme.Danger)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;   
        }
        else if (fontTheme == FontTheme.Success)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else 
        {
            Console.ResetColor();
        }
    }
}
