using System;
using System.IO;
using System.Threading.Tasks;

namespace ReadmeGenerator
{
    class Program
    {
        static async Task Main()
        {
            var baseDir = AppContext.BaseDirectory;
            var templatePath = Path.Combine(baseDir, "Readme.template.md");
            var repoRoot = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", ".."));
            var outputPath = Path.Combine(repoRoot, "README.md");

            string markdown = await File.ReadAllTextAsync(templatePath);

            string badges =
                @"![C#](https://img.shields.io/badge/-C%23-239120?style=flat&logo=c%23)
                ![.NET](https://img.shields.io/badge/-.NET-512BD4?style=flat&logo=dotnet)
                ![HTML](https://img.shields.io/badge/-HTML-E34F26?style=flat&logo=html5&logoColor=white)
                ![CSS](https://img.shields.io/badge/-CSS-1572B6?style=flat&logo=css3&logoColor=white)
                ![T-SQL](https://img.shields.io/badge/-T--SQL-CC2927?style=flat&logo=microsoft%20sql%20server)
                ![SSIS](https://img.shields.io/badge/SSIS-CC2927?style=flat&logo=microsoft%20sql%20server&logoColor=white)
                ![Azure](https://img.shields.io/badge/Azure-0089D6?style=flat&logo=microsoft-azure&logoColor=white)
                ![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat&logo=github&logoColor=white)
                ![Entity Framework](https://img.shields.io/badge/Entity%20Framework-5C2D91?style=flat&logo=entity-framework&logoColor=white)
                ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=flat&logo=visual-studio&logoColor=white)
                ".Trim();

            markdown = markdown
                .Replace("{{TechBadges}}", badges)
                .Replace("{{Date}}", DateTime.UtcNow.ToString("yyyy-MM-dd"));

            await File.WriteAllTextAsync(outputPath, markdown);

            Console.WriteLine("README.md generated at " + outputPath);
        }
    }
}
