namespace Translation;


public class DebugTranslationServer : TranslationServer
{
    public override string GetLine(LocaleLine item) => Enum.GetName(typeof(LocaleLine), item) ?? string.Empty;
}