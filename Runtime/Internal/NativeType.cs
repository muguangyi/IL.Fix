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
    internal class NativeType : LiteType
    {
        private readonly Type type = null;

        public NativeType(Type type)
        {
            this.type = type ?? throw new ArgumentNullException("type");
        }
    }
}
