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
        internal TypeDefinition _definition = null;
        private readonly List<FieldDescriptor> _fields = new List<FieldDescriptor>();
        private readonly List<MethodDescriptor> _methods = new List<MethodDescriptor>();

        private TypeDescriptor()
        { }

        public LiteType ToLiteType()
        {
            if (_state == MetaState.New)
            {
                return new VirtualType();
            }
            else if (_state == MetaState.Different)
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
            diff._token = _token;

            foreach (var f in _fields)
            {
                FieldDescriptor desp;
                if (target.TryGetField(f._token, out var field))
                {
                    desp = f.Diff(field);
                }
                else
                {
                    desp = FieldDescriptor.FromFieldDefinition(f._definition);
                    desp._state = MetaState.New;
                }
                diff._fields.Add(desp);
            }

            foreach (var m in _methods)
            {
                MethodDescriptor desp;
                if (target.TryGetMethod(m._token, out var method))
                {
                    desp = m.Diff(method);
                }
                else
                {
                    desp = MethodDescriptor.FromMethodDefinition(m._definition);
                    desp._state = MetaState.New;
                }
                diff._methods.Add(desp);
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
            foreach (var f in _fields)
            {
                if (f._token == token)
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
            foreach (var m in _methods)
            {
                if (m._token == token)
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
            desp._token = definition.FullName;
            desp._definition = definition;

            foreach (var f in definition.Fields)
            {
                desp._fields.Add(FieldDescriptor.FromFieldDefinition(f));
            }
            foreach (var m in definition.Methods)
            {
                desp._methods.Add(MethodDescriptor.FromMethodDefinition(m));
            }

            return desp;
        }
    }
}
