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
using System.Collections.Generic;

namespace IL.Lite.Internal
{
    internal class TypeDescriptor : MetaDescriptor
    {
        private readonly List<FieldDescriptor> fields = new List<FieldDescriptor>();
        private readonly List<MethodDescriptor> methods = new List<MethodDescriptor>();

        private TypeDescriptor()
        { }

        public LiteType ToLiteType()
        {
            if (this.state == MetaState.New)
            {
                return new VirtualType();
            }
            else if (this.state == MetaState.Different)
            {
                return new HybridType(null);
            }
            else
            {
                return new NativeType(null);
            }
        }

        public override ArraySegment<byte> Serialize(SerializeMode mode)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(ArraySegment<byte> data, SerializeMode mode)
        {
            throw new NotImplementedException();
        }

        public static TypeDescriptor FromTypeDefinition(TypeDefinition type)
        {
            var desp = new TypeDescriptor();
            foreach (var f in type.Fields)
            {
                desp.fields.Add(FieldDescriptor.FromFieldDefinition(f));
            }
            foreach (var m in type.Methods)
            {
                desp.methods.Add(MethodDescriptor.FromMethodDefinition(m));
            }

            return desp;
        }
    }
}
