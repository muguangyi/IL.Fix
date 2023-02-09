/*
 * This file is part of IL.Lite project.
 *
 * (c) MuGuangyi <muguangyi@hotmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace IL.Lite.Internal
{
    internal class VirtualOperand
    {
        public static long ComposeAddress(int hi, int lo)
        {
            return (long)hi << 32 | (long)lo;
        }

        public static int HiAddress(long composedAddress)
        {
            return (int)(composedAddress >> 32);
        }

        public static int LoAddress(long composedAddress)
        {
            return (int)(composedAddress & 0x00000000ffffffff);
        }
    }
}
