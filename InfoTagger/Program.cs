using UI;
using UI.Manipulators;
using Translation;


var debugTranslation = new DebugTranslationServer();

var menu = new Menu();

var manipulatorStateMachine = new ManipulatorStateMachine<MenuState>.Builder()
    .SetMenu(menu)
    .SetTranslation(debugTranslation)

    .AddState(MenuState.MainMenu, new MainMenuManipulator())
    .SetInitialState(MenuState.MainMenu)

    .Build();

menu.Initialize(
    debugTranslation,
    manipulatorStateMachine);

menu.Run();
