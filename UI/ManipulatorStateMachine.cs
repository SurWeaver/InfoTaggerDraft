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
        private TStateEnum initialState = default!;

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

        public ManipulatorStateMachine<TStateEnum> Build()
        {
            machine.SwitchTo(initialState);
            return machine;
        }
    }
}
