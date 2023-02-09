/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using System;
using System.Globalization;
using System.Reflection;

namespace IL.Lite.Internal
{
    internal abstract class LiteField : FieldInfo
    {
        public override FieldAttributes Attributes => throw new NotImplementedException();

        public override RuntimeFieldHandle FieldHandle => throw new NotImplementedException();

        public override Type FieldType => throw new NotImplementedException();

        public override Type DeclaringType => throw new NotImplementedException();

        public override string Name => throw new NotImplementedException();

        public override Type ReflectedType => throw new NotImplementedException();

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotImplementedException();
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(object obj)
        {
            throw new NotImplementedException();
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
