// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("2Rx6sIplgoVngAyqZqitEYYtd1ti4e/g0GLh6uJi4eHgSSBxJJ98rD2FYQuCfzVKN5a7L3Zjz/C8NWtQxj1OIofajXLm0UL7ks6WYdod2C3f/WfvBl9IaMXjjALtZDsJiA54NIYyNPebi6CPwlAPSixovixYWtsoWDWOvMQwyMn0f0zJ/34GfGZKP6BA+vNjmzf0OHPOVpmxoKPwi+/1nt8Y3OStNHTCcIupXFdO9B6m+wDU0GLhwtDt5unKZqhmF+3h4eHl4OMRfnSzuiGskzko7tf6zwiwedy3BIfgYmk8MAjIgjT6DL+hUMIOunhf5zS916G19IQko/SReXdzWGiHK4BayduwAkhrIUGemTr1xFKphO0pUV59diyrewZY8+Lj4eDh");
        private static int[] order = new int[] { 4,1,6,5,5,13,10,12,9,13,10,12,12,13,14 };
        private static int key = 224;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
