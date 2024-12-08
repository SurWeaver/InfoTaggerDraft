using UI.Base;
using Translation;

namespace UI.Manipulators;

public class MainMenuManipulator(TranslationServer translation, Menu menu) : ConsoleManipulator(translation, menu)
{
    public override void ShowOutputBeforeCommand()
    {
        Console.Clear();

        WriteLine(LocaleLine.MainMenu);
    }

    public override bool Do(string command)
    {
        if (command.StartsWith("exit"))
        {
            Menu.Stop();
            return true;
        }

        return false;
    }
}
