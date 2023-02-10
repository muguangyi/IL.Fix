/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using System.IO;

namespace IL.Lite.Internal
{
    internal class DomainBuilder : DomainAccessor
    {
        public DomainBuilder() : base(true)
        { }

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

        public void Patch(SerializeMode mode = SerializeMode.Binary)
        {
            // TODO:
            // 1. Differentiate two domains
            // 2. Collect patch info. [DONE]
            // 3. Serialize patch info to patch asset.

            using var stream = new MemoryStream();
            foreach (var t in this.types)
            {
                // TODO: Setup type block.
                var bytes = t.Serialize(mode);
                stream.Write(bytes);
            }
        }
    }
}
