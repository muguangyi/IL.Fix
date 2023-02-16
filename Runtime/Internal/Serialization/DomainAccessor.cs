/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using Mono.Cecil;
using System.Collections.Generic;

namespace IL.Lite.Internal
{
    internal class DomainAccessor
    {
        private readonly bool _writable = false;
        protected readonly List<AssemblyDefinition> _assemblies = new List<AssemblyDefinition>();
        protected readonly List<TypeDescriptor> _types = new List<TypeDescriptor>();

        public DomainAccessor(bool writable = false)
        {
            _writable = writable;
        }

        public void LoadAssembly(string assembly, params string[] searchingPaths)
        {
            var a = AssemblyDefinition.ReadAssembly(assembly, new ReaderParameters { ReadWrite = this._writable });
            var resolver = a.MainModule.AssemblyResolver as BaseAssemblyResolver;
            foreach (var p in searchingPaths)
            {
                resolver.AddSearchDirectory(p);
            }
            _assemblies.Add(a);

            foreach (var t in a.MainModule.Types)
            {
                _types.Add(TypeDescriptor.FromTypeDefinition(t));
            }
        }
    }
}
