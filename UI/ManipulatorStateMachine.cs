using Translation;
using UI.Base;

namespace UI;


public class ManipulatorStateMachine<TStateEnum> where TStateEnum: Enum
{
    private readonly Dictionary<TStateEnum, ConsoleManipulator> manipulators = [];

    private ConsoleManipulator? currentManipulator;


    private ManipulatorStateMachine() { }


    public void SwitchTo(TStateEnum state)
    {
        currentManipulator = manipulators[state];
    }

    public void ShowOutputBeforeCommand()
    {
        currentManipulator?.ShowOutputBeforeCommand();
    }

    public bool Do(string command)
    {
        return currentManipulator?.Do(command) ?? false;
    }

    public class Builder
    {
        private readonly ManipulatorStateMachine<TStateEnum> machine = new();
        private TStateEnum? initialState;
        private TranslationServer? translationServer;
        private Menu? menu;

        public Builder AddState(TStateEnum state, ConsoleManipulator manipulator)
        {
            machine.manipulators.Add(state, manipulator);
            return this;
        }

        public Builder SetInitialState(TStateEnum state)
        {
            initialState = state;
            return this;
        }

        public Builder SetMenu(Menu menu)
        {
            this.menu = menu;
            return this;
        }

        public Builder SetTranslation(TranslationServer translationServer)
        {
            this.translationServer = translationServer;
            return this;
        }

        public ManipulatorStateMachine<TStateEnum> Build()
        {
            if (initialState is null || translationServer is null || menu is null)
                throw new Exception("State machine is not properly initialized");

            machine.SwitchTo(initialState);

            foreach (var item in machine.manipulators.Values)
                item.Initialize(translationServer, menu);
                
            return machine;
        }
    }
}
