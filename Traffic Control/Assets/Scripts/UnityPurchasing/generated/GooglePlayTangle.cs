// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("jDY/r1f7OPS/AppVfWxvPEcjOVKWBRd8zoSn7Y1SVfY5CJ5lSCHlna4tIywcri0mLq4tLSyF7L3oU7BgHK4tDhwhKiUGqmSq2yEtLS0pLC8V0LZ8RqlOSatMwGaqZGHdSuG7lwrxgu5LFkG+Kh2ON14CWq0W0RThE9QQKGH4uA68R2WQm4I40mo3zBgr+HEbbXk4SOhvOF21u7+UpEvnTEr++DtXR2xDDpzDhuCkcuCUlhfkSyyupfD8xARO+DbAc22cDsJ2tJPdsrh/du1gX/XkIhs2A8R8tRB7yJT5QnAI/AQFOLOABTOyyrCqhvNsEzGrI8qThKQJL0DOIaj3xUTCtPjxSa3HTrP5hvtad+O6rwM8cPmnnJKxuuBnt8qUPy4vLSwt");
        private static int[] order = new int[] { 12,8,8,12,4,5,9,11,13,11,13,13,12,13,14 };
        private static int key = 44;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
