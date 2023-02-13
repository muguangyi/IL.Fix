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
        internal TypeDefinition definition = null;
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

        public TypeDescriptor Diff(TypeDescriptor target)
        {
            var diff = new TypeDescriptor();
            diff.token = this.token;

            foreach (var f in this.fields)
            {
                FieldDescriptor desp;
                if (target.TryGetField(f.token, out var field))
                {
                    desp = f.Diff(field);
                }
                else
                {
                    desp = FieldDescriptor.FromFieldDefinition(f.definition);
                    desp.state = MetaState.New;
                }
                diff.fields.Add(desp);
            }

            foreach (var m in this.methods)
            {
                MethodDescriptor desp;
                if (target.TryGetMethod(m.token, out var method))
                {
                    desp = m.Diff(method);
                }
                else
                {
                    desp = MethodDescriptor.FromMethodDefinition(m.definition);
                    desp.state = MetaState.New;
                }
                diff.methods.Add(desp);
            }

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

        private bool TryGetField(string token, out FieldDescriptor field)
        {
            foreach (var f in this.fields)
            {
                if (f.token == token)
                {
                    field = f;
                    return true;
                }
            }

            field = null;
            return false;
        }

        private bool TryGetMethod(string token, out MethodDescriptor method)
        {
            foreach (var m in this.methods)
            {
                if (m.token == token)
                {
                    method = m;
                    return true;
                }
            }

            method = null;
            return false;
        }

        public static TypeDescriptor FromTypeDefinition(TypeDefinition definition)
        {
            var desp = new TypeDescriptor();
            desp.token = definition.FullName;
            desp.definition = definition;

            foreach (var f in definition.Fields)
            {
                desp.fields.Add(FieldDescriptor.FromFieldDefinition(f));
            }
            foreach (var m in definition.Methods)
            {
                desp.methods.Add(MethodDescriptor.FromMethodDefinition(m));
            }

            return desp;
        }
    }
}
