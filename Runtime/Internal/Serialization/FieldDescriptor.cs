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
    internal class FieldDescriptor : MetaDescriptor
    {
        internal FieldDefinition _definition = null;

        private FieldDescriptor()
        { }

        public LiteField ToLiteField()
        {
            if (_state == MetaState.New)
            {
                return new VirtualField();
            }
            else
            {
                return new NativeField();
            }
        }

        public FieldDescriptor Diff(FieldDescriptor target)
        {
            var diff = new FieldDescriptor();
            diff._token = _token;

            return diff;
        }

        public override ArraySegment<byte> Serialize(SerializeMode mode)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(ArraySegment<byte> data, SerializeMode mode)
        {
            throw new NotImplementedException();
        }

        public static FieldDescriptor FromFieldDefinition(FieldDefinition definition)
        {
            var desp = new FieldDescriptor();
            desp._token = definition.FullName;
            desp._definition = definition;

            return desp;
        }
    }
}
