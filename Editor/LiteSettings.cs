/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using UnityEngine;

namespace IL.Lite.Editor
{
    public sealed class LiteSettings : ScriptableObject, ISerializationCallbackReceiver
    {
        private static LiteSettings _instance = null;

        public static LiteSettings Fetch()
        {
            return _instance;
        }

        public void OnBeforeSerialize()
        {
            throw new System.NotImplementedException();
        }

        public void OnAfterDeserialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
