import java.util.Scanner;

class update_num {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Number: ");
        int n = sc.nextInt();

        int count = 1;
        int reverse = 0;
        while(n != 0){
            int temp = n % 10;
            if(temp == 0){
                reverse = count + temp + reverse;
            }else{
                reverse = count * temp + reverse;
            }
            n /= 10;
            count *= 10;
        }
    }
}
