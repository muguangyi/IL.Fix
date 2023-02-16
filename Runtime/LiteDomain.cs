/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using IL.Lite.Internal;
using System;

namespace IL.Lite
{
    public sealed class LiteDomain
    {
        private static LiteDomain _current = null;

        static LiteDomain()
        {
            _current = new LiteDomain();
        }

        public static LiteDomain Current => _current;

        internal readonly LiteTypeSystem _typeSystem = null;
        internal readonly LiteInterpreter _interp = null;

        private LiteDomain()
        {
            _typeSystem = new LiteTypeSystem(this);
            _interp = new LiteInterpreter(this);
        }

        public void Load(byte[] rawData)
        {
            _typeSystem.Load(rawData);
        }

        public Type GetType(string type)
        {
            return _typeSystem.GetType(type);
        }

        public Type GetType(object obj)
        {
            return _typeSystem.GetType(obj);
        }

        public Type[] GetTypes()
        {
            return _typeSystem.GetTypes();
        }
    }
}
