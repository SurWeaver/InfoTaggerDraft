using System.Diagnostics;


namespace InfoTagger;


public static class CodeFragmentDrafts
{
    public static void OpenFolder(string folderPath = "/home/")
    {
        ProcessStartInfo processInfo = new(folderPath)
        {
            UseShellExecute = true
        };

        try
        {
            Process.Start(processInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}




/* Пример добавления ссылки
alexander@alexander-HP-Pavilion-Notebook:~/Проекты/InfoTaggerDraft$ cd InfoTagger
alexander@alexander-HP-Pavilion-Notebook:~/Проекты/InfoTaggerDraft/InfoTagger$ dotnet add reference ../Tags/Tags.csproj
Ссылка "..\Tags\Tags.csproj" добавлена в проект.
*/