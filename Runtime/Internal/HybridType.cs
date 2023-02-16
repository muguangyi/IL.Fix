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
    internal class HybridType : LiteType
    {
        private readonly Type _type = null;
        private VirtualField[] _virtualFields = null;
        private VirtualMethod[] _virtualMethods = null;

        public HybridType(Type type)
        {
            _type = type ?? throw new ArgumentNullException("type");
        }
    }
}
