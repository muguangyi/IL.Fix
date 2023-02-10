/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using Mono.Cecil;
using System;

namespace IL.Lite.Internal
{
    internal class FieldDescriptor : IDescriptor
    {
        private FieldDescriptor()
        { }

        public LiteField ToLiteField()
        {
            return null;
        }

        public ArraySegment<byte> Serialize(SerializeMode mode)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(ArraySegment<byte> data, SerializeMode mode)
        {
            throw new NotImplementedException();
        }

        public static FieldDescriptor FromFieldDefinition(FieldDefinition field)
        {
            var desp = new FieldDescriptor();

            return desp;
        }
    }
}
