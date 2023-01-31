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
    internal class VirtualType : LiteType
    {
        private VirtualField[] virtualFields = null;
        private VirtualMethod[] virtualMethods = null;

        public override ArraySegment<byte> Serialize()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(ArraySegment<byte> data)
        {
            throw new NotImplementedException();
        }

        public static VirtualType FromNativeType(Type type)
        {
            return new VirtualType();
        }
    }
}
