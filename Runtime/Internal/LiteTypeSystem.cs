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
    internal class LiteTypeSystem
    {
        private readonly LiteDomain domain = null;
        private LiteType[] liteTypes = null;

        public LiteTypeSystem(LiteDomain domain)
        {
            this.domain = domain;
        }

        public void Load(byte[] rawData)
        {

        }

        public Type GetType(string type)
        {
            return null;
        }

        public Type GetType(object obj)
        {
            return null;
        }

        public Type[] GetTypes()
        {
            return null;
        }
    }
}
