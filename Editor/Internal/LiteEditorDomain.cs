/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using IL.Lite.Internal;
using Mono.Cecil;
using System.Collections.Generic;
using System.IO;

namespace IL.Lite.Editor
{
    internal class LiteEditorDomain
    {
        private readonly List<AssemblyDefinition> assemblies = new List<AssemblyDefinition>();
        private readonly List<TypeDescriptor> types = new List<TypeDescriptor>();

        public void LoadAssembly(string assembly, bool writable, params string[] searchingPaths)
        {
            var a = AssemblyDefinition.ReadAssembly(assembly, new ReaderParameters { ReadWrite = writable });
            var resolver = a.MainModule.AssemblyResolver as BaseAssemblyResolver;
            foreach (var path in searchingPaths)
            {
                resolver.AddSearchDirectory(path);
            }
            this.assemblies.Add(a);
        }

        public void Inject()
        {
            // TODO:
            // 1. Inject code to types.
            // 2. Save all target assemblies. [DONE]

            foreach (var a in this.assemblies)
            {
                a.Write();
            }
        }

        public void Patch(LiteEditorDomain target, SerializeMode mode = SerializeMode.Binary)
        {
            // TODO:
            // 1. Differentiate two domains
            // 2. Collect patch info. [DONE]
            // 3. Serialize patch info to patch asset.

            using var stream = new MemoryStream();
            foreach (var t in types)
            {
                var bytes = t.Serialize(mode);
                stream.Write(bytes);
            }
        }
    }
}
