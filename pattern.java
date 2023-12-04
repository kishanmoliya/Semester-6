import java.util.Scanner;

public class pattern {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the Number: ");
        // int n  = sc.nextInt();
        int n  = 5;

        // for(int i=0; i<n; i++){
        //     for(int j=i*5+1; j<=i*5+5; j++){
        //         System.out.print(j + " ");
        //     }
        //     System.out.println();
        // }
         for(int i=0; i<n; i++){
            for(int j=i*5+1; j<=i*5+5; j++){
                System.out.print(j + " ");
            }
            System.out.println();
        }
    }
}
