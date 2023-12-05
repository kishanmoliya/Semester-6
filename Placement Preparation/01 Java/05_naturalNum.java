
//Print	all	natural	numbers	upto	N	without	using	semi-colon.
import java.util.Scanner;

public class naturalNum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Number: ");
        int n = sc.nextInt();
        for (int i = 0; i <= n; i++, System.out.println(i)) {
        }
    }
}
