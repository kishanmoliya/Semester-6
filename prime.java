import java.util.Scanner;

public class prime{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Number: ");
        int n  = sc.nextInt();
        
        boolean flag = false;

        for(int i=2; i<n; i++){
            if(n % i == 0){
                flag = true;
                break;
            }
        }

        if(flag){
            System.out.println("Number is not Prime");
        }else{
            System.out.println("Number is Prime");
        }
    }
}