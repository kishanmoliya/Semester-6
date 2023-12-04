import java.util.Scanner;

public class decimalToBinary {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Number: ");
        int n  = sc.nextInt();

        int result = 0;
        while (n != 0) {
            result = (result * 10) + n % 2;
            n /= 2;
        }

        int binary = 0;
        while (result != 0) {
            binary = (binary * 10) + result % 10;
            result /= 10;
        }

        System.out.println(binary);
    }
}
