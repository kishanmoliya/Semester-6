// Write	a	program	to	print	following	pattern
// 1 2 3 4 5
// 10 9 8 7 6
// 11 12 13 14 15
// 20 19 18 17 16
// 21 22 23 24 25
import java.util.Scanner;

public class pattern {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Number: ");
        int n = sc.nextInt();

        for(int i=0; i<n; i++){
            if(i % 2 == 0){
                for(int j=i*n+1; j<i*n+(n+1); j++){
                    System.out.print(j + " ");
                }
            }else{
                for(int j=(i+1)*n; j>(i+1)*n-n; j--){
                    System.out.print(j + " ");
                }
            }
            System.out.println("");
        }
    }
}
