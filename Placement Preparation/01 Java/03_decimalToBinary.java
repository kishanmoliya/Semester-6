//Program	to	convert	number	from	Decimal	to	Binary.
import java.util.Scanner;

public class decimalToBinary {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Number: ");
        int n  = sc.nextInt();

        int[] binary = new int[50];
        int i = 0;
        int result = 0;
        while (n != 0) {
            binary[i] = n % 2;
            n = n / 2;
            i++;
        }

        System.out.print("Binary: ");
        for (int j = i-1; j >= 0; j--) {
            System.out.print(binary[j]);
        }

        // int binary = 0;
        // while (result != 0) {
        //     binary = (binary * 10) + result % 10;
        //     result /= 10;
        // }

        //System.out.println(binary);
    }
}
