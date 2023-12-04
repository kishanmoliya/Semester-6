import java.lang.reflect.Array;
import java.util.Arrays;

public class arrangeArray {
    public static void main(String[] args) {
        int[] arr = { 11, 5, 10, 17 };
        Arrays.sort(arr);

        if (arr.length % 2 == 0) {
            for (int i = (arr.length - 2); i >= 0; i -= 2) {
                System.out.print(arr[i] + " ");
            }
            for (int i = 1; i < arr.length; i += 2) {
                System.out.print(arr[i] + " ");
            }

        } else {
            for (int i = (arr.length - 1); i >= 0; i -= 2) {
                System.out.print(arr[i] + " ");
            }
            for (int i = 1; i < arr.length - 1; i += 2) {
                System.out.print(arr[i] + " ");
            }
        }

    }
}
