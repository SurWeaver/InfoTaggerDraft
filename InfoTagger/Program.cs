// See https://aka.ms/new-console-template for more information

using Tags;
using UI;
using UI.Manipulators;
using Translation;


var debugTranslation = new DebugTranslationServer();

var menu = new Menu();

var manipulatorStateMachine = new ManipulatorStateMachine<MenuState>.Builder()
    .AddState(MenuState.MainMenu, new MainMenuManipulator(debugTranslation, menu))
    .SetInitialState(MenuState.MainMenu)
    .Build();

menu.Initialize(
    debugTranslation,
    manipulatorStateMachine);

menu.Run();
