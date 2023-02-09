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
        private static LiteDomain current = null;

        static LiteDomain()
        {
            current = new LiteDomain();
        }

        public static LiteDomain Current => current;

        private readonly LiteTypeSystem typeSystem = null;
        private readonly LiteInterpreter interp = null;

        private LiteDomain()
        {
            this.typeSystem = new LiteTypeSystem(this);
            this.interp = new LiteInterpreter(this);
        }

        public void Load(byte[] rawData)
        {
            this.typeSystem.Load(rawData);
        }

        public Type GetType(string type)
        {
            return this.typeSystem.GetType(type);
        }

        public Type GetType(object obj)
        {
            return this.typeSystem.GetType(obj);
        }

        public Type[] GetTypes()
        {
            return this.typeSystem.GetTypes();
        }

        internal LiteTypeSystem TypeSystem => this.typeSystem;
        internal LiteInterpreter Interp => this.interp;
    }
}
