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
                ![.NET](https://img.shields.io/badge/-.NET-512BD4?style=flat&logo=dotnet)";

            markdown = markdown
                .Replace("{{TechBadges}}", badges)
                .Replace("{{Date}}", DateTime.UtcNow.ToString("yyyy-MM-dd"));

            await File.WriteAllTextAsync(outputPath, markdown);

            Console.WriteLine("README.md generated at " + outputPath);
        }
    }
}
