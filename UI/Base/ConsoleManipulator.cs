using Translation;

namespace UI.Base;

public abstract class ConsoleManipulator
{
    public TranslationServer Translation = default!;
    public Menu Menu = default!;

    public void Initialize(TranslationServer translation, Menu menu)
    {
        Translation = translation;
        Menu = menu;
    }

    public void WriteLine(LocaleLine line)
    {
        Console.WriteLine(Translation.GetLine(line));
    }

    public abstract void ShowOutputBeforeCommand();
    public abstract bool Do(string command);
}
