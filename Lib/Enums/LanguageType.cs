namespace Playground.Lib.Enums
{
    public enum CodeLanguage
    {
        None,
        CSharp,
        Html,
        Css,
        JavaScript,
        Json,
        TypeScript,
        Xml,
        Markdown,
        Bash,
        Sql,
        Python,
        Java,
        Php,
        Razor,
    }

    public class LanguageType
    {
        public static string GetLanguageClass(CodeLanguage lang) => lang switch
        {
            CodeLanguage.CSharp => "csharp",
            CodeLanguage.Html => "html",
            CodeLanguage.Css => "css",
            CodeLanguage.JavaScript => "javascript",
            CodeLanguage.Json => "json",
            CodeLanguage.TypeScript => "ts",
            CodeLanguage.Xml => "xml",
            CodeLanguage.Markdown => "markdown",
            CodeLanguage.Bash => "bash",
            CodeLanguage.Sql => "sql",
            CodeLanguage.Python => "python",
            CodeLanguage.Java => "java",
            CodeLanguage.Php => "php",
            CodeLanguage.Razor => "razor",
            _ => ""
        };
    }
}

