import java.util.Scanner;

public class palindrom {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Number: ");
        int n  = sc.nextInt();

        int num = n;
        int palindrom = 0;

        while (n > 0) {
            int temp = n % 10;
            palindrom = (palindrom * 10 + temp);
            n /= 10;
        }

        if(palindrom == num){
            System.out.println("Number is Palindrom");
        }else{
            System.out.println("Number is not Palindrom");
        }
    }
}
