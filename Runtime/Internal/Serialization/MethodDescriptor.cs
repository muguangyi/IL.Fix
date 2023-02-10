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
    internal class MethodDescriptor : MetaDescriptor
    {
        internal MethodDefinition definition = null;

        private MethodDescriptor()
        { }

        public LiteMethod ToLiteMethod()
        {
            if (this.state == MetaState.New)
            {
                return new VirtualMethod();
            }
            else
            {
                return new NativeMethod();
            }
        }

        public MethodDescriptor Diff(MethodDescriptor target)
        {
            var diff = new MethodDescriptor();
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

        public static MethodDescriptor FromMethodDefinition(MethodDefinition definition)
        {
            var desp = new MethodDescriptor();
            desp.token = definition.FullName;
            desp.definition = definition;

            return desp;
        }
    }
}
