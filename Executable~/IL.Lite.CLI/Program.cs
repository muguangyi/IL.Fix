/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using System;
using System.CommandLine;
using System.IO;
using System.Threading.Tasks;

namespace IL.Lite
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Console.WriteLine("/**************************/");
            Console.WriteLine("/*      IL.Lite CLI       */");
            Console.WriteLine("/**************************/");
            Console.WriteLine("");

            var injectCommand = new Command("inject");
            injectCommand.Description = "IL.Lite inject assembly.";
            injectCommand.TreatUnmatchedTokensAsErrors = true;
            injectCommand.AddOption(new Option<string[]>(new string[] { "--assembly", "-a" }) { IsRequired = true });

            // NOTE: CommandHandler parameters' name must be as same as the option name!
            injectCommand.SetHandler<string[]>((assembly) =>
            {
                try
                {
                    foreach (var a in assembly)
                    {
                        var path = Path.IsPathRooted(a) ? a : Path.Combine(Environment.CurrentDirectory, a);
                        if (File.Exists(path))
                        {
                            var rawAssembly = File.ReadAllBytes(path);
                        }
                    }
                }
                finally
                {
                    Console.WriteLine("\nInject finished.");
                }
            }, null);

            var patchCommand = new Command("patch");
            patchCommand.Description = "IL.Lite patch assembly.";
            patchCommand.TreatUnmatchedTokensAsErrors = true;
            patchCommand.AddOption(new Option<string[]>(new string[] { "--assembly", "-a" }) { IsRequired = true });
            patchCommand.SetHandler<string[]>((assembly) =>
            {
                try
                {
                    foreach (var a in assembly)
                    {
                        var path = Path.IsPathRooted(a) ? a : Path.Combine(Environment.CurrentDirectory, a);
                        if (File.Exists(path))
                        {
                            var rawAssembly = File.ReadAllBytes(path);
                        }
                    }
                }
                finally
                {
                    Console.WriteLine("\nPatch finished.");
                }
            }, null);

            var root = new RootCommand();
            root.Description = "IL.Lite CLI.";
            root.TreatUnmatchedTokensAsErrors = true;
            root.AddCommand(injectCommand);

            return await root.InvokeAsync(args);
        }
    }
}
