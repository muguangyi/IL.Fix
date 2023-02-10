/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using System;

namespace IL.Lite.Internal
{
    internal abstract class MetaDescriptor : IMetaDescriptor
    {
        internal string token = null;
        internal MetaState state = MetaState.Same;

        public abstract ArraySegment<byte> Serialize(SerializeMode mode);
        public abstract void Deserialize(ArraySegment<byte> data, SerializeMode mode);
    }
}
