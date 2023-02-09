/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

using UnityEditor;

namespace IL.Lite.Editor
{
    public sealed class LiteEditor : EditorWindow
    {
        public static void Publish()
        {
            // TODO:
            // 1. Compile project.
            // 2. Copy target assemblies to publish folder.
        }

        public static void Patch()
        {
            // TODO:
            // 1. Compile project.
            // 2. Compare target assemblies with publish assemblies.
            //  2.1. Setup target domain with loading target assemblies.
            //  2.2. Setup publish domain with loading publish assemblies.
            //  2.2. Compare two domains.
            // 3. Generate patch asset from target domain.
        }

        public static void Inject()
        {
            // TODO:
            // 1. Inject target publish assemblies.
            // 2. Copy the injected assemblies to ScriptAssemblies/PlayerScriptAssemblies folder.
        }
    }
}
