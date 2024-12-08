using Translation;

namespace UI.Base;

public abstract class ConsoleManipulator(TranslationServer translation, Menu menu)
{
    public TranslationServer Translation = translation;
    public Menu Menu = menu;

    public void WriteLine(LocaleLine line)
    {
        Console.WriteLine(Translation.GetLine(line));
    }

    public abstract void ShowOutputBeforeCommand();
    public abstract bool Do(string command);
}
