using System.Diagnostics;
using Translation;

namespace UI;

public class Menu
{
    private TranslationServer? Translation;
    private ManipulatorStateMachine<MenuState>? ManipulatorStateMachine;

    public void Initialize(TranslationServer translationServer, ManipulatorStateMachine<MenuState> manipulatorStateMachine)
    {
        Translation = translationServer;
        ManipulatorStateMachine = manipulatorStateMachine;
    }

    private bool run = true;

    public void Run()
    {
        run = true;

        while (run)
        {
            ManipulatorStateMachine?.ShowOutputBeforeCommand();

            var command = GetCommand();
            if (command is null)
            {
                WriteLine(LocaleLine.EmptyCommand);
                continue;
            }

            var commandIsParsed = ManipulatorStateMachine?.Do(command) ?? false;
            
            if (!commandIsParsed)
                WriteLine(LocaleLine.CantUnderstandCommand);
        }
    }

    public void Stop() => run = false;

    public void SwitchTo(MenuState state) => ManipulatorStateMachine?.SwitchTo(state);


    private void WriteLine(LocaleLine line)
    {
        Console.WriteLine(Translation?.GetLine(line));
    }

    private static string? GetCommand()
    {
        try
        {
            var command = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(command))
                return null;
            return command;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return null;
    }
}
